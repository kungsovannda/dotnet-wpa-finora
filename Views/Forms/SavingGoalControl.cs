using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using PersonalExpenseTracker.Dtos;
using PersonalExpenseTracker.Features.SavingGoals;
using PersonalExpenseTracker.Views.Data;
using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// The Saving Goals page. Cards only: the control asks the controller for
    /// goal responses and renders them, and every action on a card is routed
    /// back through the controller before the shared notifier is told that
    /// something changed.
    /// </summary>
    public partial class SavingGoalControl : UserControl, IRefreshablePage
    {
        private readonly SavingGoalController _controller;
        private readonly DataChangeNotifier _changes;

        private bool _refreshing;

        public SavingGoalControl(SavingGoalController controller, DataChangeNotifier changes)
        {
            _controller = controller;
            _changes = changes;
            InitializeComponent();
            BackColor = Colors.Background;

            _changes.Changed += Changes_Changed;
            Disposed += SavingGoalControl_Disposed;
        }

        private void SavingGoalControl_Disposed(object? sender, EventArgs e)
        {
            _changes.Changed -= Changes_Changed;
        }

        private void Changes_Changed(object? sender, DataChangedEventArgs e)
        {
            if (IsDisposed || Disposing)
                return;

            if (!e.Includes(DataChange.SavingGoals) && !e.Includes(DataChange.Transactions))
                return;

            if (Visible)
                RefreshData();
        }

        /// <summary>
        /// Rebuilds the card grid and the summary row. Single load path: the
        /// first show, a revisit and the page's own writes all come through here.
        /// </summary>
        public void RefreshData()
        {
            if (_refreshing || IsDisposed || !IsHandleCreated)
                return;

            _refreshing = true;
            try
            {
                LoadGoals();
            }
            finally
            {
                _refreshing = false;
            }
        }

        private void SavingGoalControl_Load(object sender, EventArgs e)
        {
            // Load fires once per instance, so this is only the first show.
            // Every later visit goes through MainForm -> RefreshData.
            RefreshData();
        }

        private void LoadGoals()
        {
            List<SavingGoalResponseDto> goals;
            SavingGoalOverviewDto overview;
            try
            {
                goals = _controller.GetAllSavingGoals();
                overview = _controller.GetOverview();
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return;
            }

            LoadSummary(overview);

            list.SuspendLayout();

            // Disposing removes each card from the panel.
            while (list.Controls.Count > 0)
                list.Controls[0].Dispose();

            // The rows are rebuilt from scratch, otherwise every refresh would
            // leave the empty rows of the previous list behind.
            list.RowStyles.Clear();

            // One row per goal, in a single percent column so every card takes the
            // full width of the page.
            int pitch = Theme.Scaled(SavingGoalCard.RowPitch, Theme.ScaleOf(this));
            for (int i = 0; i < goals.Count; i++)
            {
                var card = new SavingGoalCard();
                card.Bind(goals[i]);
                card.ActionRequested += Card_ActionRequested;
                list.RowStyles.Add(new RowStyle(SizeType.Absolute, pitch));
                list.Controls.Add(card, 0, i);
            }

            // The list is exactly as tall as its rows, so the page - which is the
            // scrolling host - decides whether a scrollbar is needed. A list that
            // scrolled itself would hand every card a width taken from a stale
            // scroll extent, and the row would end past the edge of the page.
            int height = goals.Count * pitch;
            if (list.Height != height)
                list.Height = height;

            list.ResumeLayout(true);

            bool hasItems = goals.Count > 0;
            list.Visible = hasItems;
            empty.Visible = !hasItems;
        }

        private void LoadSummary(SavingGoalOverviewDto overview)
        {
            cardSaved.Value = overview.TotalSavedAmount.ToString("C", CultureInfo.CurrentCulture);
            cardSaved.Support = overview.TotalTargetAmount <= 0m
                ? "No targets set"
                : "of " + overview.TotalTargetAmount.ToString("C", CultureInfo.CurrentCulture) + " targeted";

            cardProgress.Value = string.Format(CultureInfo.CurrentCulture, "{0:0.#}%", overview.OverallProgressPercentage);
            cardProgress.Support = overview.CompletedGoals == 1
                ? "1 goal completed"
                : string.Format(CultureInfo.CurrentCulture, "{0} goals completed", overview.CompletedGoals);

            cardActive.Value = overview.ActiveGoals.ToString(CultureInfo.CurrentCulture);
            cardActive.Support = overview.OverdueGoals == 0
                ? "Nothing overdue"
                : overview.OverdueGoals == 1
                    ? "1 goal overdue"
                    : string.Format(CultureInfo.CurrentCulture, "{0} goals overdue", overview.OverdueGoals);
        }

        private void Card_ActionRequested(object? sender, GoalActionEventArgs e)
        {
            if (sender is not SavingGoalCard card)
                return;

            switch (e.Action)
            {
                case GoalAction.Contribute:
                    Contribute(e.Id);
                    break;

                case GoalAction.Details:
                    ShowActionsMenu(card, e.Id);
                    break;

                default:
                    ShowActionsMenu(card, e.Id);
                    break;
            }
        }

        private void btnAdd_Click(object? sender, EventArgs e)
        {
            using var dialog = new SavingGoalDialog();
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _controller.CreateSavingGoal(dialog.GetData());
                _changes.Notify(DataChange.SavingGoals);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowActionsMenu(SavingGoalCard card, long id)
        {
            SavingGoalResponseDto goal;
            try
            {
                goal = _controller.GetSavingGoal(id);
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return;
            }

            var menu = new ContextMenuStrip();

            var addItem = new ToolStripMenuItem("Add money");
            var editItem = new ToolStripMenuItem("Edit", Resources.Resources.edit);
            var archiveItem = new ToolStripMenuItem(goal.IsArchived ? "Unarchive" : "Archive");
            var deleteItem = new ToolStripMenuItem("Delete", Resources.Resources.trash);

            addItem.Click += (_, _) => Contribute(id);
            editItem.Click += (_, _) => EditGoal(id);
            archiveItem.Click += (_, _) => ToggleArchive(goal);
            deleteItem.Click += (_, _) => DeleteGoal(goal);

            menu.Items.Add(addItem);
            menu.Items.Add(editItem);
            menu.Items.Add(archiveItem);
            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add(deleteItem);

            // Anchored under the row's menu button at the top-right of the card.
            var location = new Point(card.Width - Theme.Space5, Theme.Space4);
            menu.Show(card, location);
        }

        private void Contribute(long id)
        {
            var goal = _controller.GetSavingGoal(id);

            if (goal.IsArchived)
            {
                MessageBox.Show(this,
                    "This goal is archived, so it no longer accepts contributions.",
                    "Add money", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var dialog = new ContributionDialog(goal);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                _controller.AddContribution(dialog.GetData(id));
                _changes.Notify(DataChange.SavingGoals);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void EditGoal(long id)
        {
            var goal = _controller.GetSavingGoal(id);

            using var dialog = new SavingGoalDialog(goal);
            if (dialog.ShowDialog(this) != DialogResult.OK)
                return;

            try
            {
                var update = dialog.GetUpdateData();
                update.Id = id;
                _controller.UpdateSavingGoal(update);
                _changes.Notify(DataChange.SavingGoals);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ToggleArchive(SavingGoalResponseDto goal)
        {
            try
            {
                _controller.UpdateSavingGoal(new UpdateSavingGoalDto
                {
                    Id = goal.Id,
                    Name = goal.Name,
                    Description = goal.Description,
                    Emoji = goal.Emoji,
                    TargetAmount = goal.TargetAmount,
                    TargetDate = goal.TargetDate,
                    IsArchived = !goal.IsArchived
                });

                _changes.Notify(DataChange.SavingGoals);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void DeleteGoal(SavingGoalResponseDto goal)
        {
            try
            {
                _controller.DeleteSavingGoal(goal.Id);
                _changes.Notify(DataChange.SavingGoals);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Owner only when this page has a window handle: a modal dialog raised
        /// without one can appear behind the form that spawned it.
        /// </summary>
        private void ShowError(Exception ex)
        {
            MessageBox.Show(
                IsHandleCreated ? this : null,
                ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
