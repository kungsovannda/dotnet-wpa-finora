using PersonalExpenseTracker.Views.UI;

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
            lbTitle.AutoSize = false;
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = Typography.SectionTitle;
            lbTitle.ForeColor = Colors.Foreground;
            lbTitle.Location = new Point(0, 0);
            lbTitle.Margin = new Padding(0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(955, 28);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Section";
            lbTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbDescription
            // 
            lbDescription.AutoSize = false;
            lbDescription.Dock = DockStyle.Top;
            lbDescription.Font = Typography.Body;
            lbDescription.ForeColor = Colors.SecondaryText;
            lbDescription.Location = new Point(0, 32);
            lbDescription.Margin = new Padding(0, 4, 0, 0);
            lbDescription.Name = "lbDescription";
            lbDescription.Padding = new Padding(0);
            lbDescription.Size = new Size(955, 20);
            lbDescription.TabIndex = 1;
            lbDescription.Text = "Description";
            lbDescription.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Heading
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Colors.Background;
            Controls.Add(lbDescription);
            Controls.Add(lbTitle);
            Name = "Heading";
            Size = new Size(955, 56);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTitle;
        private Label lbDescription;
    }
}
