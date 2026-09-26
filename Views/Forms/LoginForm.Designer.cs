namespace PersonalExpenseTracker.Views.Forms
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnExit = new Button();
            btnLogin = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            label4 = new Label();
            panel2 = new Panel();
            txtPassword = new TextBox();
            splitter3 = new Splitter();
            label3 = new Label();
            splitter1 = new Splitter();
            txtUsername = new TextBox();
            splitter2 = new Splitter();
            label2 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Franklin Gothic Medium", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(43, 0);
            label1.Name = "label1";
            label1.Size = new Size(314, 138);
            label1.TabIndex = 0;
            label1.Text = "Login";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            btnExit.Dock = DockStyle.Top;
            btnExit.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExit.Location = new Point(0, 30);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(314, 30);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.Window;
            btnLogin.Dock = DockStyle.Top;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.Location = new Point(0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(314, 30);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(panel2, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 0, 2);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(40, 0, 40, 0);
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 39.48438F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 150F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.6261024F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.8895149F));
            tableLayoutPanel1.Size = new Size(400, 500);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Silver;
            label4.Location = new Point(43, 440);
            label4.Name = "label4";
            label4.Size = new Size(314, 17);
            label4.TabIndex = 6;
            label4.Text = "@ 2026 - Finora";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtPassword);
            panel2.Controls.Add(splitter3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(splitter1);
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(splitter2);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(43, 141);
            panel2.Name = "panel2";
            panel2.Size = new Size(314, 144);
            panel2.TabIndex = 5;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Top;
            txtPassword.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(0, 95);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(314, 33);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // splitter3
            // 
            splitter3.Dock = DockStyle.Top;
            splitter3.Enabled = false;
            splitter3.Location = new Point(0, 90);
            splitter3.Name = "splitter3";
            splitter3.Size = new Size(314, 5);
            splitter3.TabIndex = 6;
            splitter3.TabStop = false;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 69);
            label3.Name = "label3";
            label3.Size = new Size(314, 21);
            label3.TabIndex = 3;
            label3.Text = "Password";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // splitter1
            // 
            splitter1.Dock = DockStyle.Top;
            splitter1.Enabled = false;
            splitter1.Location = new Point(0, 59);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(314, 10);
            splitter1.TabIndex = 4;
            splitter1.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Top;
            txtUsername.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.Location = new Point(0, 26);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(314, 33);
            txtUsername.TabIndex = 1;
            // 
            // splitter2
            // 
            splitter2.Dock = DockStyle.Top;
            splitter2.Enabled = false;
            splitter2.Location = new Point(0, 21);
            splitter2.Name = "splitter2";
            splitter2.Size = new Size(314, 5);
            splitter2.TabIndex = 5;
            splitter2.TabStop = false;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(314, 21);
            label2.TabIndex = 2;
            label2.Text = "Username";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnLogin);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(43, 291);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 146);
            panel1.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 500);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button btnExit;
        private Button btnLogin;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label4;
        private Panel panel2;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsername;
        private Label label2;
        private Splitter splitter3;
        private Splitter splitter1;
        private Splitter splitter2;
    }
}
