using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Forms
{
    partial class CategoryControl
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
            header = new TableLayoutPanel();
            heading1 = new PersonalExpenseTracker.Views.Controls.Heading();
            btnAdd = new Views.UI.Controls.AppButton();
            contentHost = new Panel();
            empty = new Views.UI.Controls.EmptyState();
            grid = new TableLayoutPanel();
            root.SuspendLayout();
            header.SuspendLayout();
            contentHost.SuspendLayout();
            grid.SuspendLayout();
            SuspendLayout();
            // 
            // root
            // 
            root.BackColor = Colors.Background;
            root.ColumnCount = 1;
            root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            root.Controls.Add(header, 0, 0);
            root.Controls.Add(contentHost, 0, 1);
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
            heading1.description = "Organise your income and expenses with a little colour.";
            heading1.Dock = DockStyle.Fill;
            heading1.Location = new Point(0, 0);
            heading1.Margin = new Padding(0);
            heading1.Name = "heading1";
            heading1.Size = new Size(772, 68);
            heading1.TabIndex = 0;
            heading1.Title = "Categories";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Right;
            btnAdd.BackColor = Color.Transparent;
            btnAdd.Caption = "Add Category";
            btnAdd.Icon = Icons.Plus;
            btnAdd.Location = new Point(772, 15);
            btnAdd.Margin = new Padding(0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(128, 38);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Category";
            btnAdd.Click += button1_Click;
            // 
            // contentHost
            // 
            // The host, not the grid, does the scrolling: the grid is exactly as
            // tall as its cards, so a scrollbar appearing can never feed back into
            // the column count and leave the grid in a layout that never settles.
            contentHost.AutoScroll = true;
            contentHost.BackColor = Colors.Background;
            contentHost.Controls.Add(empty);
            contentHost.Controls.Add(grid);
            contentHost.Dock = DockStyle.Fill;
            contentHost.Location = new Point(0, 68);
            contentHost.Margin = new Padding(0);
            contentHost.Name = "contentHost";
            contentHost.Size = new Size(900, 552);
            contentHost.TabIndex = 1;
            // 
            // empty
            // 
            empty.ActionText = "Add Category";
            empty.BackColor = Colors.Background;
            empty.Description = "Create your first category to start grouping your transactions.";
            empty.Dock = DockStyle.Fill;
            empty.Icon = Icons.Categories;
            empty.Location = new Point(0, 0);
            empty.Margin = new Padding(0);
            empty.Name = "empty";
            empty.Size = new Size(900, 552);
            empty.TabIndex = 1;
            empty.Text = "No categories yet";
            empty.Visible = false;
            empty.Click += button1_Click;
            // 
            // grid
            // 
            // A responsive grid rather than a wrapping flow: the page decides how
            // many columns fit and the cards take an exact share of the width, so
            // the last column ends flush with the edge instead of leaving a gap.
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grid.BackColor = Colors.Background;
            grid.ColumnCount = 1;
            grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            grid.Location = new Point(0, 0);
            grid.Margin = new Padding(0);
            grid.Name = "grid";
            grid.RowCount = 0;
            grid.Size = new Size(900, 156);
            grid.TabIndex = 0;
            // 
            // CategoryControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Background;
            Controls.Add(root);
            Name = "CategoryControl";
            Size = new Size(900, 620);
            Load += CategoryControl_Load;
            root.ResumeLayout(false);
            header.ResumeLayout(false);
            contentHost.ResumeLayout(false);
            grid.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel root;
        private TableLayoutPanel header;
        private Controls.Heading heading1;
        private Views.UI.Controls.AppButton btnAdd;
        private Panel contentHost;
        private TableLayoutPanel grid;
        private Views.UI.Controls.EmptyState empty;
    }
}
