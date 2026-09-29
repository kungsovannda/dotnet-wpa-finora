using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class SettingControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            card = new Views.UI.Controls.SectionCard();
            empty = new Views.UI.Controls.EmptyState();
            root.SuspendLayout();
            card.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Colors.Background;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(heading1, 0, 0);
            root.Controls.Add(card, 0, 1);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 2;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 68F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(900, 620);
            root.TabIndex = 0;
            // 
            // heading1
            // 
            heading1.BackColor = Colors.Background;
            heading1.description = "Preferences and account options for Finora.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(900, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Settings";
            // 
            // card
            // 
            card.Border = Colors.Border;
            card.Dock = DockStyle.Fill;
            card.Location = new Point(0, 72);
            card.Margin = new Padding(0, 4, 0, 0);
            card.Name = "card";
            card.Padding = new Padding(24);
            card.Radius = Theme.RadiusLg;
            card.ShowShadow = true;
            card.Size = new Size(900, 544);
            card.Surface = Colors.Surface;
            card.TabIndex = 1;
            card.Controls.Add(empty);
            // 
            // empty
            // 
            empty.ActionText = "";
            empty.BackColor = Colors.Surface;
            empty.Description = "There is nothing to configure yet. Your account details and preferences will appear here.";
            empty.Dock = DockStyle.Fill;
            empty.Icon = Icons.Settings;
            empty.Location = new Point(24, 24);
            empty.Margin = new Padding(0);
            empty.Name = "empty";
            empty.Size = new Size(852, 496);
            empty.TabIndex = 0;
            empty.Text = "Settings are on the way";
            // 
            // SettingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Background;
            Controls.Add(root);
            Name = "SettingControl";
            Size = new Size(900, 620);
            root.ResumeLayout(false);
            card.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private Controls.Heading heading1;
        private Views.UI.Controls.SectionCard card;
        private Views.UI.Controls.EmptyState empty;
    }
}
