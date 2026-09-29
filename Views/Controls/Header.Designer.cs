using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    partial class Header
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up the resources being used.
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
            layout = new TableLayoutPanel();
            titles = new TableLayoutPanel();
            lbContext = new Label();
            lbGreeting = new Label();
            avatar = new PersonalExpenseTracker.Views.UI.Controls.AvatarView();
            divider = new Panel();
            layout.SuspendLayout();
            titles.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.BackColor = Color.FromArgb(255, 255, 255);
            layout.ColumnCount = 3;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            layout.Controls.Add(titles, 1, 0);
            layout.Controls.Add(avatar, 2, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layout.Size = new Size(1280, 64);
            layout.TabIndex = 0;
            // 
            // titles
            // 
            titles.BackColor = Color.FromArgb(255, 255, 255);
            titles.ColumnCount = 1;
            titles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            titles.Controls.Add(lbContext, 0, 1);
            titles.Controls.Add(lbGreeting, 0, 0);
            titles.Dock = DockStyle.Fill;
            titles.Location = new Point(28, 0);
            titles.Margin = new Padding(0);
            titles.Name = "titles";
            titles.RowCount = 2;
            titles.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            titles.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            titles.Size = new Size(1224, 64);
            titles.TabIndex = 0;
            // 
            // lbContext
            // 
            lbContext.BackColor = Color.FromArgb(255, 255, 255);
            lbContext.Dock = DockStyle.Fill;
            lbContext.Font = new Font("Lexend", 9.5F);
            lbContext.ForeColor = Color.FromArgb(113, 113, 122);
            lbContext.Location = new Point(0, 32);
            lbContext.Margin = new Padding(0, 2, 0, 0);
            lbContext.Name = "lbContext";
            lbContext.Size = new Size(1224, 32);
            lbContext.TabIndex = 1;
            lbContext.Text = "Today";
            // 
            // lbGreeting
            // 
            lbGreeting.BackColor = Color.FromArgb(255, 255, 255);
            lbGreeting.Dock = DockStyle.Fill;
            lbGreeting.Font = new Font("Lexend", 15F, FontStyle.Bold);
            lbGreeting.ForeColor = Color.FromArgb(24, 24, 27);
            lbGreeting.Location = new Point(0, 0);
            lbGreeting.Margin = new Padding(0);
            lbGreeting.Name = "lbGreeting";
            lbGreeting.Size = new Size(1224, 30);
            lbGreeting.TabIndex = 0;
            lbGreeting.Text = "Good day";
            lbGreeting.TextAlign = ContentAlignment.BottomLeft;
            // 
            // avatar
            // 
            avatar.Anchor = AnchorStyles.None;
            avatar.BackColor = Color.Transparent;
            avatar.Fill = Color.FromArgb(245, 158, 11);
            avatar.Fill2 = Color.FromArgb(217, 119, 6);
            avatar.Font = new Font("Lexend SemiBold", 9F);
            avatar.Foreground = Color.FromArgb(255, 255, 255);
            avatar.Initials = "U";
            avatar.Location = new Point(1252, 14);
            avatar.Margin = new Padding(0);
            avatar.Name = "avatar";
            avatar.Size = new Size(28, 36);
            avatar.TabIndex = 1;
            // 
            // divider
            // 
            divider.BackColor = Color.FromArgb(237, 237, 239);
            divider.Dock = DockStyle.Bottom;
            divider.Location = new Point(0, 63);
            divider.Margin = new Padding(0);
            divider.Name = "divider";
            divider.Size = new Size(1280, 1);
            divider.TabIndex = 2;
            // 
            // Header
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 255, 255);
            Controls.Add(divider);
            Controls.Add(layout);
            Name = "Header";
            Size = new Size(1280, 64);
            layout.ResumeLayout(false);
            titles.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layout;
        private TableLayoutPanel titles;
        private Label lbGreeting;
        private Label lbContext;
        private Views.UI.Controls.AvatarView avatar;
        private Panel divider;
    }
}
