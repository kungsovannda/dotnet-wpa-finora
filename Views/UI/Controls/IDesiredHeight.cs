namespace PersonalExpenseTracker.Views.UI.Controls
{
    /// <summary>
    /// An input that knows how tall it wants to be.
    /// <para>
    /// <see cref="FormField"/> docks its input with <see cref="System.Windows.Forms.DockStyle.Fill"/>,
    /// so the layout engine overwrites the input's <see cref="System.Windows.Forms.Control.Height"/>
    /// with the row height. An input therefore cannot advertise its intended
    /// height through <c>Height</c> - it has to report it separately, otherwise
    /// a multiline field silently collapses back to a single line.
    /// </para>
    /// </summary>
    public interface IDesiredHeight
    {
        /// <summary>Height the input should be given, in pixels.</summary>
        int DesiredHeight { get; }
    }
}
