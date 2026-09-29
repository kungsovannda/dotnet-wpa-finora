using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PersonalExpenseTracker.Views.UI;

namespace PersonalExpenseTracker.Views.Controls
{
    partial class StatCard
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
            content = new TableLayoutPanel();
            lbTitle = new Label();
            iconHost = new Panel();
            lbValue = new Label();
            lbSupport = new Label();
            content.SuspendLayout();
            SuspendLayout();
            // 
            // content
            // 
            content.BackColor = Color.Transparent;
            content.ColumnCount = 2;
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            content.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 30F));
            content.Controls.Add(lbTitle, 0, 0);
            content.Controls.Add(iconHost, 1, 0);
            content.Controls.Add(lbValue, 0, 1);
            content.Controls.Add(lbSupport, 0, 3);
            content.Dock = DockStyle.Fill;
            content.Location = new Point(16, 14);
            content.Margin = new Padding(0);
            content.Name = "content";
            content.RowCount = 4;
            // 28 = title + icon tile, then amount / slack / support (set in code).
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            content.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            content.RowStyles.Add(new RowStyle(SizeType.Absolute, 0F));
            content.SetColumnSpan(lbValue, 2);
            content.SetColumnSpan(lbSupport, 2);
            content.Size = new Size(208, 92);
            content.TabIndex = 0;
            // 
            // lbTitle
            // 
            lbTitle.AutoEllipsis = true;
            lbTitle.Dock = DockStyle.Fill;
            lbTitle.Font = Typography.BodySmallMedium;
            lbTitle.ForeColor = Colors.MutedText;
            lbTitle.Location = new Point(0, 0);
            lbTitle.Margin = new Padding(0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(178, 28);
            lbTitle.TabIndex = 0;
            lbTitle.Text = "Metric";
            lbTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // iconHost
            // 
            iconHost.BackColor = Color.Transparent;
            iconHost.Dock = DockStyle.Fill;
            iconHost.Location = new Point(178, 0);
            iconHost.Margin = new Padding(0);
            iconHost.Name = "iconHost";
            iconHost.Size = new Size(30, 28);
            iconHost.TabIndex = 1;
            // 
            // lbValue
            // 
            lbValue.AutoEllipsis = true;
            lbValue.Dock = DockStyle.Fill;
            lbValue.Font = Typography.Amount;
            lbValue.ForeColor = Colors.Foreground;
            lbValue.Location = new Point(0, 28);
            lbValue.Margin = new Padding(0);
            lbValue.Name = "lbValue";
            lbValue.Size = new Size(208, 34);
            lbValue.TabIndex = 2;
            lbValue.Text = "$0.00";
            lbValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbSupport
            // 
            lbSupport.AutoEllipsis = true;
            lbSupport.Dock = DockStyle.Fill;
            lbSupport.Font = Typography.Caption;
            lbSupport.ForeColor = Colors.FaintText;
            lbSupport.Location = new Point(0, 78);
            // No margin: a margin inside a fixed row would shrink the label
            // below its preferred height and clip the text. The gap below the
            // amount is added to the row height in FitRows instead.
            lbSupport.Margin = new Padding(0);
            lbSupport.Name = "lbSupport";
            lbSupport.Size = new Size(208, 17);
            lbSupport.TabIndex = 3;
            lbSupport.Text = "";
            lbSupport.TextAlign = ContentAlignment.MiddleLeft;
            lbSupport.Visible = false;
            // 
            // StatCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Colors.Surface;
            Controls.Add(content);
            // 28 (title) + 33 (amount) + 21 (support) + 2 x 14 padding
            MinimumSize = new Size(150, 110);
            Name = "StatCard";
            Padding = new Padding(16, 14, 16, 14);
            Size = new Size(240, 120);
            content.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel content;
        private Label lbTitle;
        private Panel iconHost;
        private Label lbValue;
        private Label lbSupport;
    }
}
