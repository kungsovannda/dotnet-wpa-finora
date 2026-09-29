using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sidebar = new PersonalExpenseTracker.Views.Controls.Sidebar();
            panel = new Panel();
            header1 = new PersonalExpenseTracker.Views.Controls.Header();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.FromArgb(255, 255, 255);
            sidebar.Dock = DockStyle.Left;
            sidebar.Location = new Point(0, 0);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(248, 700);
            sidebar.TabIndex = 0;
            // 
            // panel
            // 
            panel.BackColor = Color.FromArgb(248, 248, 247);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(3, 67);
            panel.Name = "panel";
            panel.Padding = new Padding(24, 20, 24, 24);
            panel.Size = new Size(946, 630);
            panel.TabIndex = 1;
            // 
            // header1
            // 
            header1.BackColor = Color.FromArgb(255, 255, 255);
            header1.Context = "Tuesday, 29 September";
            header1.Dock = DockStyle.Top;
            header1.Location = new Point(3, 3);
            header1.Name = "header1";
            header1.Quote = "Spend wiser";
            header1.Size = new Size(946, 58);
            header1.TabIndex = 2;
            header1.UserName = "U";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.FromArgb(248, 248, 247);
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel, 0, 1);
            tableLayoutPanel1.Controls.Add(header1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(248, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(952, 700);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 248, 247);
            ClientSize = new Size(1200, 700);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(sidebar);
            MinimumSize = new Size(988, 700);
            Name = "MainForm";
            Text = "Finora - Expense Tracker";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Controls.Sidebar sidebar;
        private Panel panel;
        private Controls.Header header1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}