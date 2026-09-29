using PersonalExpenseTracker.Views.UI;
using PersonalExpenseTracker.Views.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalExpenseTracker.Views.Forms
{
    /// <summary>
    /// Lightweight, grouped emoji picker. Presentation only: it returns the
    /// chosen glyph through <see cref="SelectedGlyph"/> and never touches a
    /// controller, service or repository.
    /// </summary>
    public class EmojiPickerDialog : Form
    {
        private const int ChipSize = 38;
        private const int ContentWidth = 448;

        private readonly Panel _header;
        private readonly Label _title;
        private readonly IconButton _close;
        private readonly FlowLayoutPanel _groups;

        public EmojiPickerDialog()
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.CenterParent;
            ShowInTaskbar = false;
            KeyPreview = true;
            BackColor = Colors.Surface;
            Font = Typography.Body;
            ClientSize = new Size(ContentWidth, 512);

            _header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Colors.Surface
            };

            _title = new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = Typography.SectionTitle,
                ForeColor = Colors.Foreground,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Text = "Choose an emoji"
            };

            _close = new IconButton
            {
                Icon = Icons.Close,
                Size = new Size(28, 28)
            };
            _close.Click += (_, _) => Cancel();

            _header.Controls.Add(_title);
            _header.Controls.Add(_close);
            _header.Resize += (_, _) => PositionClose();

            _groups = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                BackColor = Colors.Surface,
                Padding = new Padding(20, 8, 20, 20)
            };

            Controls.Add(_groups);
            Controls.Add(_header);

            Load += (_, _) =>
            {
                PositionClose();
                BuildGroups();
            };

            KeyDown += (_, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    Cancel();
            };
        }

        /// <summary>Glyph chosen by the user (empty when the dialog is cancelled).</summary>
        public string SelectedGlyph { get; private set; } = string.Empty;

        private void PositionClose()
        {
            _close.Location = new Point(
                Math.Max(0, _header.Width - _close.Width - 16),
                Math.Max(0, (_header.Height - _close.Height) / 2));
        }

        private void BuildGroups()
        {
            int width = Math.Max(160,
                _groups.ClientSize.Width - _groups.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth - 4);

            foreach (var groupName in Emoji.GroupNames)
                _groups.Controls.Add(CreateGroup(groupName, width));
        }

        private Control CreateGroup(string groupName, int width)
        {
            var glyphs = new List<string>();
            foreach (var entry in Emoji.Entries)
            {
                if (entry.Group == groupName)
                    glyphs.Add(entry.Glyph);
            }

            var panel = new Panel
            {
                Width = width,
                Margin = new Padding(0, 0, 0, 8),
                BackColor = Colors.Surface
            };

            var label = new Label
            {
                Dock = DockStyle.Top,
                Height = 24,
                Text = groupName,
                Font = Typography.CaptionMedium,
                ForeColor = Colors.MutedText,
                TextAlign = ContentAlignment.MiddleLeft
            };

            int perRow = Math.Max(1, width / ChipSize);
            int rows = (glyphs.Count + perRow - 1) / perRow;

            var chips = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                BackColor = Colors.Surface,
                Margin = Padding.Empty,
                Padding = Padding.Empty
            };

            foreach (var glyph in glyphs)
            {
                var chip = new EmojiChip
                {
                    Glyph = glyph,
                    Selected = string.Equals(glyph, SelectedGlyph, StringComparison.Ordinal)
                };
                chip.Click += (_, _) => Choose(glyph);
                chips.Controls.Add(chip);
            }

            panel.Height = label.Height + rows * ChipSize + 4;
            panel.Controls.Add(chips);
            panel.Controls.Add(label);
            return panel;
        }

        private void Choose(string glyph)
        {
            SelectedGlyph = glyph;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            using var path = Theme.RoundedPath(
                new RectangleF(0, 0, Width, Height),
                Theme.Scaled(Theme.RadiusXl, Theme.ScaleOf(this)));
            var region = new Region(path);
            var previous = Region;
            Region = region;
            previous?.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            Theme.SetupQuality(g);
            using var pen = new Pen(Colors.Border, 1f);
            using var path = Theme.RoundedPath(
                new RectangleF(0.5f, 0.5f, Width - 1f, Height - 1f),
                Theme.Scaled(Theme.RadiusXl, Theme.ScaleOf(this)));
            g.DrawPath(pen, path);
        }
    }
}
