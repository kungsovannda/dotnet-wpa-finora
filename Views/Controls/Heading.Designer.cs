namespace PersonalExpenseTracker.Views.Controls
{
    partial class Heading
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
            lbDescription = new Label();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Lexend", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(955, 33);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "label1";
            // 
            // lbDescription
            // 
            lbDescription.Dock = DockStyle.Top;
            lbDescription.Font = new Font("Lexend", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDescription.Location = new Point(0, 33);
            lbDescription.Name = "lbDescription";
            lbDescription.Padding = new Padding(3, 0, 0, 0);
            lbDescription.Size = new Size(955, 33);
            lbDescription.TabIndex = 1;
            lbDescription.Text = "label2";
            // 
            // Heading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(lbDescription);
            Controls.Add(lbTitle);
            Name = "Heading";
            Size = new Size(955, 68);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Label lbDescription;
    }
}
