namespace PersonalExpenseTracker.Views.Controls
{
    partial class StatCard
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
            lbTitle = new Label();
            lbValue = new Label();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Lexend", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(8, 8);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(182, 30);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "label1";
            lbTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbValue
            // 
            lbValue.Dock = DockStyle.Fill;
            lbValue.Font = new Font("Lexend", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbValue.Location = new Point(8, 38);
            lbValue.Name = "lbValue";
            lbValue.Size = new Size(182, 44);
            lbValue.TabIndex = 1;
            lbValue.Text = "label2";
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbValue);
            Controls.Add(lbTitle);
            MinimumSize = new Size(200, 90);
            Name = "StatCard";
            Padding = new Padding(8);
            Size = new Size(198, 90);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label lbValue;
    }
}
