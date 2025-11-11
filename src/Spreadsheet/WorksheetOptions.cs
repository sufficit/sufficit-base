namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Worksheet display and formatting options
    /// </summary>
    public class WorksheetOptions
    {

        public bool AutoFitColumns { get; set; } = true;

        public double? MinColumnWidth { get; set; } = 30;

        public double? MaxColumnWidth { get; set; } = 200;

        public bool FreezePanes { get; set; } = true;

        public int FreezeRow { get; set; } = 1;

        public int FreezeColumn { get; set; } = 0;

    }
}
