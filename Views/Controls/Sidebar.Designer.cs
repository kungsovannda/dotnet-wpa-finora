using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    partial class Sidebar
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
            brandPanel = new TableLayoutPanel();
            brandMark = new Views.UI.Controls.AvatarView();
            lbBrand = new Label();
            navHost = new Panel();
            nav = new TableLayoutPanel();
            navSectionLabel = new Label();
            navSpacer = new Panel();
            btnDashboard = new Views.UI.Controls.NavItem();
            btnTransaction = new Views.UI.Controls.NavItem();
            btnCategory = new Views.UI.Controls.NavItem();
            btnSetting = new Views.UI.Controls.NavItem();
            edge = new Panel();
            root.SuspendLayout();
            brandPanel.SuspendLayout();
            navHost.SuspendLayout();
            nav.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Colors.Surface;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(brandPanel, 0, 0);
            root.Controls.Add(navHost, 0, 1);
            root.Dock = DockStyle.Fill;
            root.Location = new Point(0, 0);
            root.Margin = new Padding(0);
            root.Name = "root";
            root.RowCount = 2;
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.Size = new Size(248, 700);
            root.TabIndex = 0;
            // 
            // brandPanel
            // 
            brandPanel.BackColor = Colors.Surface;
            brandPanel.ColumnCount = 3;
            brandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            brandPanel.ColumnStyles.Add(new ColumnStyle());
            brandPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            brandPanel.Controls.Add(brandMark, 1, 0);
            brandPanel.Controls.Add(lbBrand, 2, 0);
            brandPanel.Dock = DockStyle.Fill;
            brandPanel.Location = new Point(0, 0);
            brandPanel.Margin = new Padding(0);
            brandPanel.Name = "brandPanel";
            brandPanel.RowCount = 1;
            brandPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            brandPanel.Size = new Size(248, 64);
            brandPanel.TabIndex = 0;
            // 
            // brandMark
            // 
            brandMark.Anchor = AnchorStyles.None;
            brandMark.Fill = Colors.PrimaryOrange;
            brandMark.Fill2 = Colors.PrimaryHover;
            brandMark.Foreground = Colors.OnPrimary;
            brandMark.Initials = "F";
            brandMark.Location = new Point(20, 17);
            brandMark.Margin = new Padding(0, 0, 10, 0);
            brandMark.Name = "brandMark";
            brandMark.Size = new Size(30, 30);
            brandMark.TabIndex = 0;
            // 
            // lbBrand
            // 
            lbBrand.Dock = DockStyle.Fill;
            lbBrand.Font = Typography.HeadingSmall;
            lbBrand.ForeColor = Colors.Foreground;
            lbBrand.Location = new Point(60, 0);
            lbBrand.Margin = new Padding(0);
            lbBrand.Name = "lbBrand";
            lbBrand.Size = new Size(188, 64);
            lbBrand.TabIndex = 1;
            lbBrand.Text = "Finora";
            lbBrand.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // navHost
            // 
            navHost.BackColor = Colors.Surface;
            navHost.Controls.Add(nav);
            navHost.Dock = DockStyle.Fill;
            navHost.Location = new Point(0, 64);
            navHost.Margin = new Padding(0);
            navHost.Name = "navHost";
            navHost.Padding = new Padding(12, 4, 12, 12);
            navHost.Size = new Size(248, 636);
            navHost.TabIndex = 1;
            // 
            // nav
            // 
            nav.BackColor = Colors.Surface;
            nav.ColumnCount = 1;
            nav.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            nav.Controls.Add(navSectionLabel, 0, 0);
            nav.Controls.Add(btnDashboard, 0, 1);
            nav.Controls.Add(btnTransaction, 0, 2);
            nav.Controls.Add(btnCategory, 0, 3);
            nav.Controls.Add(btnSetting, 0, 4);
            nav.Controls.Add(navSpacer, 0, 5);
            nav.Dock = DockStyle.Fill;
            nav.Location = new Point(12, 4);
            nav.Margin = new Padding(0);
            nav.Name = "nav";
            nav.RowCount = 6;
            nav.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            nav.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            nav.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            nav.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            nav.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            nav.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            nav.Size = new Size(224, 620);
            nav.TabIndex = 0;
            // 
            // navSectionLabel
            // 
            navSectionLabel.Dock = DockStyle.Fill;
            navSectionLabel.Font = Typography.Overline;
            navSectionLabel.ForeColor = Colors.FaintText;
            navSectionLabel.Location = new Point(0, 0);
            navSectionLabel.Margin = new Padding(4, 0, 0, 0);
            navSectionLabel.Name = "navSectionLabel";
            navSectionLabel.Size = new Size(220, 32);
            navSectionLabel.TabIndex = 0;
            navSectionLabel.Text = "MENU";
            navSectionLabel.TextAlign = ContentAlignment.BottomLeft;
            // 
            // btnDashboard
            // 
            btnDashboard.Caption = "Dashboard";
            btnDashboard.Dock = DockStyle.Fill;
            btnDashboard.Font = Typography.Label;
            btnDashboard.Icon = Icons.Dashboard;
            btnDashboard.Location = new Point(0, 32);
            btnDashboard.Margin = new Padding(0, 2, 0, 2);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Selected = true;
            btnDashboard.Size = new Size(224, 40);
            btnDashboard.TabIndex = 1;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnTransaction
            // 
            btnTransaction.Caption = "Transactions";
            btnTransaction.Dock = DockStyle.Fill;
            btnTransaction.Font = Typography.Label;
            btnTransaction.Icon = Icons.Transactions;
            btnTransaction.Location = new Point(0, 76);
            btnTransaction.Margin = new Padding(0, 2, 0, 2);
            btnTransaction.Name = "btnTransaction";
            btnTransaction.Size = new Size(224, 40);
            btnTransaction.TabIndex = 2;
            btnTransaction.Click += btnTransaction_Click;
            // 
            // btnCategory
            // 
            btnCategory.Caption = "Categories";
            btnCategory.Dock = DockStyle.Fill;
            btnCategory.Font = Typography.Label;
            btnCategory.Icon = Icons.Categories;
            btnCategory.Location = new Point(0, 120);
            btnCategory.Margin = new Padding(0, 2, 0, 2);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(224, 40);
            btnCategory.TabIndex = 3;
            btnCategory.Click += btnCategory_Click;
            // 
            // btnSetting
            // 
            btnSetting.Caption = "Settings";
            btnSetting.Dock = DockStyle.Fill;
            btnSetting.Font = Typography.Label;
            btnSetting.Icon = Icons.Settings;
            btnSetting.Location = new Point(0, 164);
            btnSetting.Margin = new Padding(0, 2, 0, 2);
            btnSetting.Name = "btnSetting";
            btnSetting.Size = new Size(224, 40);
            btnSetting.TabIndex = 4;
            btnSetting.Click += btnSetting_Click;
            // 
            // navSpacer
            // 
            navSpacer.BackColor = Colors.Surface;
            navSpacer.Dock = DockStyle.Fill;
            navSpacer.Location = new Point(0, 208);
            navSpacer.Margin = new Padding(0);
            navSpacer.Name = "navSpacer";
            navSpacer.Size = new Size(224, 412);
            navSpacer.TabIndex = 5;
            // 
            // edge
            // 
            edge.BackColor = Colors.Border;
            edge.Dock = DockStyle.Right;
            edge.Location = new Point(247, 0);
            edge.Margin = new Padding(0);
            edge.Name = "edge";
            edge.Size = new Size(1, 700);
            edge.TabIndex = 1;
            // 
            // Sidebar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            Controls.Add(edge);
            Controls.Add(root);
            Name = "Sidebar";
            Size = new Size(248, 700);
            root.ResumeLayout(false);
            brandPanel.ResumeLayout(false);
            navHost.ResumeLayout(false);
            nav.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel brandPanel;
        private Views.UI.Controls.AvatarView brandMark;
        private Label lbBrand;
        private Panel navHost;
        private TableLayoutPanel nav;
        private Label navSectionLabel;
        private Panel navSpacer;
        private Views.UI.Controls.NavItem btnDashboard;
        private Views.UI.Controls.NavItem btnTransaction;
        private Views.UI.Controls.NavItem btnCategory;
        private Views.UI.Controls.NavItem btnSetting;
        private Panel edge;
    }
}
