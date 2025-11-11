namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Style options for cells
    /// </summary>
    public class WorksheetCellStyle
    {

        public bool Bold { get; set; }

        public bool Italic { get; set; }

        /// <summary>
        /// Background color in hexadecimal format (e.g., "#FF0000" for red)
        /// </summary>
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// Foreground (text) color in hexadecimal format (e.g., "#FFFFFF" for white)
        /// </summary>
        public string? ForegroundColor { get; set; }

        public HorizontalAlignment Alignment { get; set; }

    }
}
