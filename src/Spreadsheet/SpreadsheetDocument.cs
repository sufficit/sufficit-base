using System.Collections.Generic;

namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Represents a spreadsheet document with one or more worksheets
    /// </summary>
    public class SpreadsheetDocument
    {

        public string Title { get; set; } = "Relatório";

        public List<Worksheet> Worksheets { get; set; } = new();

    }
}
