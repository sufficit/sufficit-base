using System.Collections.Generic;

namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Represents a single worksheet (tab) in a spreadsheet
    /// </summary>
    public class Worksheet
    {

        public string Name { get; set; } = "Dados";

        public List<WorksheetRow> Rows { get; set; } = new();

        public WorksheetOptions Options { get; set; } = new();

    }
}
