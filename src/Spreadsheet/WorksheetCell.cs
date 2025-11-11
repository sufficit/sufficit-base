namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Represents a single cell in the worksheet
    /// </summary>
    public class WorksheetCell
    {

        public object? Value { get; set; }

        public WorksheetCellStyle? Style { get; set; }

        /// <summary>
        /// Number format for the cell (e.g., "0.00%", "yyyy-MM-dd", "#,##0.00")
        /// </summary>
        public string? Format { get; set; }

        /// <summary>
        /// Hyperlink URL for the cell
        /// </summary>
        public string? Hyperlink { get; set; }

    }
}
