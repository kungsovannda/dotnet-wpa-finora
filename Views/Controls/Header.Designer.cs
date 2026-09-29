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
            lbQuote = new Label();
            lbContext = new Label();
            avatar = new PersonalExpenseTracker.Views.UI.Controls.AvatarView();
            divider = new Panel();
            layout.SuspendLayout();
            titles.SuspendLayout();
            SuspendLayout();
            // 
            // layout
            // 
            layout.BackColor = Color.Transparent;
            layout.ColumnCount = 4;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 28F));
            layout.Controls.Add(titles, 1, 0);
            layout.Controls.Add(avatar, 2, 0);
            layout.Dock = DockStyle.Fill;
            layout.Location = new Point(0, 0);
            layout.Margin = new Padding(0);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.Size = new Size(1280, 64);
            layout.TabIndex = 0;
            // 
            // titles
            // 
            // Two 50% spacers around the two text rows, so the quote and the
            // date form one optically centred block instead of hanging from
            // the top. The row heights themselves are set from the fonts'
            // preferred heights by FitTitles.
            titles.BackColor = Color.Transparent;
            titles.ColumnCount = 1;
            titles.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            titles.Controls.Add(lbQuote, 0, 1);
            titles.Controls.Add(lbContext, 0, 2);
            titles.Dock = DockStyle.Fill;
            titles.Location = new Point(28, 0);
            titles.Margin = new Padding(0);
            titles.Name = "titles";
            titles.RowCount = 4;
            titles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            titles.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            titles.RowStyles.Add(new RowStyle(SizeType.Absolute, 21F));
            titles.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            titles.Size = new Size(1190, 64);
            titles.TabIndex = 0;
            // 
            // lbQuote
            // 
            lbQuote.AutoEllipsis = true;
            lbQuote.BackColor = Color.Transparent;
            lbQuote.Dock = DockStyle.Fill;
            lbQuote.Font = new Font("Lexend", 13F, FontStyle.Bold);
            lbQuote.ForeColor = Color.FromArgb(24, 24, 27);
            lbQuote.Location = new Point(0, 12);
            lbQuote.Margin = new Padding(0);
            lbQuote.Name = "lbQuote";
            lbQuote.Size = new Size(1190, 24);
            lbQuote.TabIndex = 0;
            lbQuote.Text = "Spend what is left after saving.";
            lbQuote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbContext
            // 
            lbContext.AutoEllipsis = true;
            lbContext.BackColor = Color.Transparent;
            lbContext.Dock = DockStyle.Fill;
            lbContext.Font = new Font("Lexend", 9.5F);
            lbContext.ForeColor = Color.FromArgb(113, 113, 122);
            lbContext.Location = new Point(0, 36);
            lbContext.Margin = new Padding(0);
            lbContext.Name = "lbContext";
            lbContext.Size = new Size(1190, 15);
            lbContext.TabIndex = 1;
            lbContext.Text = "Today";
            lbContext.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // avatar
            // 
            // Square and self-pinned, so the circle fills the control exactly.
            // Anchor None centres it inside its AutoSize column.
            avatar.Anchor = AnchorStyles.None;
            avatar.BackColor = Color.Transparent;
            avatar.Diameter = 34;
            avatar.Fill = Color.FromArgb(245, 158, 11);
            avatar.Fill2 = Color.FromArgb(217, 119, 6);
            avatar.Font = new Font("Lexend SemiBold", 10F);
            avatar.Foreground = Color.FromArgb(255, 255, 255);
            avatar.Initials = "U";
            avatar.Location = new Point(1222, 15);
            avatar.Margin = new Padding(0);
            avatar.Name = "avatar";
            avatar.Size = new Size(34, 34);
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
        private Label lbQuote;
        private Label lbContext;
        private Views.UI.Controls.AvatarView avatar;
        private Panel divider;
    }
}
