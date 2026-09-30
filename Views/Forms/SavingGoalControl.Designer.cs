using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class SavingGoalControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            root = new TableLayoutPanel();
            header = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            btnAdd = new Views.UI.Controls.AppButton();
            statRow = new TableLayoutPanel();
            cardSaved = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardProgress = new PersonalExpenseTracker.Views.Controls.StatCard();
            cardActive = new PersonalExpenseTracker.Views.Controls.StatCard();
            contentHost = new Panel();
            empty = new Views.UI.Controls.EmptyState();
            list = new TableLayoutPanel();
            root.SuspendLayout();
            header.SuspendLayout();
            statRow.SuspendLayout();
            contentHost.SuspendLayout();
            SuspendLayout();
            //
            // root
            //
            root.BackColor = Colors.Background;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(statRow, 0, 1);
            root.Controls.Add(contentHost, 0, 2);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 3;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            //
            // header
            //
            header.BackColor = Colors.Background;
            header.ColumnCount = 2;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            // AutoSize lets the column follow the button's caption instead of
            // clipping it; the heading keeps whatever space is left.
            header.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            header.Controls.Add(heading1, 0, 0);
            header.Controls.Add(btnAdd, 1, 0);
            header.Dock = DockStyle.Fill;
            header.Location = new Point(0, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.RowCount = 1;
            header.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            header.Size = new Size(900, 68);
            header.TabIndex = 0;
            //
            // heading1
            //
            heading1.BackColor = Colors.Background;
            heading1.description = "Set a target, watch the bar fill, and add money whenever you can.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(772, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Saving Goals";
            //
            // btnAdd
            //
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.BackColor = Color.Transparent;
            btnAdd.Caption = "Add Goal";
            btnAdd.Icon = Icons.Plus;
            btnAdd.Location = new Point(772, 15);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Goal";
            btnAdd.Click += btnAdd_Click;
            //
            // statRow
            //
            statRow.BackColor = Colors.Background;
            statRow.ColumnCount = 3;
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
            statRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33334F));
            statRow.Controls.Add(cardSaved, 0, 0);
            statRow.Controls.Add(cardProgress, 1, 0);
            statRow.Controls.Add(cardActive, 2, 0);
            statRow.Dock = DockStyle.Fill;
            statRow.Location = new Point(0, 68);
            statRow.Margin = new Padding(0);
            statRow.Name = "statRow";
            statRow.RowCount = 1;
            statRow.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            statRow.Size = new Size(900, 120);
            statRow.TabIndex = 1;
            //
            // cardSaved
            //
            cardSaved.BackColor = Colors.Background;
            cardSaved.Dock = DockStyle.Fill;
            cardSaved.Icon = Icons.Wallet;
            cardSaved.Location = new Point(0, 4);
            cardSaved.Margin = new Padding(0, 4, 16, 12);
            cardSaved.MinimumSize = new Size(150, 99);
            cardSaved.Name = "cardSaved";
            cardSaved.Padding = new Padding(16, 14, 16, 14);
            cardSaved.Size = new Size(284, 104);
            cardSaved.Support = "";
            cardSaved.TabIndex = 0;
            cardSaved.Title = "Total Saved";
            cardSaved.Value = "$0.00";
            //
            // cardProgress
            //
            cardProgress.BackColor = Colors.Background;
            cardProgress.Dock = DockStyle.Fill;
            cardProgress.Icon = Icons.Sparkles;
            cardProgress.Location = new Point(300, 4);
            cardProgress.Margin = new Padding(0, 4, 16, 12);
            cardProgress.MinimumSize = new Size(150, 99);
            cardProgress.Name = "cardProgress";
            cardProgress.Padding = new Padding(16, 14, 16, 14);
            cardProgress.Size = new Size(284, 104);
            cardProgress.Support = "";
            cardProgress.TabIndex = 1;
            cardProgress.Title = "Overall Progress";
            cardProgress.Value = "0%";
            //
            // cardActive
            //
            cardActive.BackColor = Colors.Background;
            cardActive.Dock = DockStyle.Fill;
            cardActive.Icon = Icons.Layers;
            cardActive.Location = new Point(600, 4);
            cardActive.Margin = new Padding(0, 4, 0, 12);
            cardActive.MinimumSize = new Size(150, 99);
            cardActive.Name = "cardActive";
            cardActive.Padding = new Padding(16, 14, 16, 14);
            cardActive.Size = new Size(300, 104);
            cardActive.Support = "";
            cardActive.TabIndex = 2;
            cardActive.Title = "Active Goals";
            cardActive.Value = "0";
            //
            // contentHost
            //
            contentHost.BackColor = Colors.Background;
            contentHost.Controls.Add(empty);
            contentHost.Controls.Add(list);
            contentHost.Dock = DockStyle.Fill;
            contentHost.Location = new Point(0, 188);
            contentHost.Margin = new Padding(0);
            contentHost.Name = "contentHost";
            contentHost.Size = new Size(900, 432);
            contentHost.TabIndex = 2;
            //
            // empty
            //
            empty.ActionText = "Add Goal";
            empty.BackColor = Colors.Background;
            empty.Description = "Create a goal for something you are saving towards and track it here.";
            empty.Dock = DockStyle.Fill;
            empty.Icon = Icons.Sparkles;
            empty.Location = new Point(0, 0);
            empty.Margin = new Padding(0);
            empty.Name = "empty";
            empty.Size = new Size(900, 432);
            empty.TabIndex = 1;
            empty.Text = "No saving goals yet";
            empty.Visible = false;
            empty.Click += btnAdd_Click;
            //
            // list
            //
            // One goal per full-width row: a single percent column lets each card
            // fill the width instead of being wrapped into a grid.
            list.AutoScroll = true;
            list.BackColor = Colors.Background;
            list.ColumnCount = 1;
            list.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            list.Dock = DockStyle.Fill;
            list.Location = new Point(0, 0);
            list.Margin = new Padding(0);
            list.Name = "list";
            list.Padding = new Padding(0, 4, 0, 0);
            list.Size = new Size(900, 432);
            list.TabIndex = 0;
            //
            // SavingGoalControl
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Background;
            Controls.Add(root);
            Name = "SavingGoalControl";
            Size = new Size(900, 620);
            Load += SavingGoalControl_Load;
            root.ResumeLayout(false);
            header.ResumeLayout(false);
            statRow.ResumeLayout(false);
            contentHost.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel header;
        private Controls.Heading heading1;
        private Views.UI.Controls.AppButton btnAdd;
        private TableLayoutPanel statRow;
        private Controls.StatCard cardSaved;
        private Controls.StatCard cardProgress;
        private Controls.StatCard cardActive;
        private Panel contentHost;
        private TableLayoutPanel list;
        private Views.UI.Controls.EmptyState empty;
    }
}
