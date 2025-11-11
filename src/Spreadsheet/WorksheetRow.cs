using System.Collections.Generic;

namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Represents a row in the worksheet
    /// </summary>
    public class WorksheetRow
    {

        public List<WorksheetCell> Cells { get; set; } = new();

        public WorksheetRowStyle? Style { get; set; }

    }
}
