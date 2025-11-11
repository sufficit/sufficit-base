using Sufficit.Spreadsheet;

namespace Sufficit.Reports
{
    /// <summary>
    /// Interface for reports that can be exported to spreadsheet format
    /// </summary>
    public interface ISpreadsheetExportable
    {

        /// <summary>
        /// Converts the report to spreadsheet document metadata
        /// </summary>
        /// <returns>Spreadsheet document with report data and formatting</returns>
        SpreadsheetDocument ToSpreadsheet();

    }
}
