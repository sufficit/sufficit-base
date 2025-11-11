namespace Sufficit.Spreadsheet
{
    /// <summary>
    /// Interface for spreadsheet renderers
    /// </summary>
    public interface ISpreadsheetRenderer
    {
        byte[] Render(SpreadsheetDocument document);
    }

    /// <summary>
    /// Service for exporting spreadsheet documents to various formats
    /// </summary>
    public interface ISpreadsheetExporter
    {
        /// <summary>
        /// Exports a spreadsheet document to bytes (default format: Excel)
        /// </summary>
        byte[] ToBytes(SpreadsheetDocument document);

        /// <summary>
        /// Exports a spreadsheet document using a specific renderer
        /// </summary>
        byte[] Export(SpreadsheetDocument document, ISpreadsheetRenderer renderer);
    }

    /// <summary>
    /// Default implementation of spreadsheet exporter service
    /// </summary>
    public class SpreadsheetExporter : ISpreadsheetExporter
    {
        private readonly ISpreadsheetRenderer _defaultRenderer;

        /// <summary>
        /// Constructor for dependency injection
        /// </summary>
        public SpreadsheetExporter(ISpreadsheetRenderer defaultRenderer)
        {
            _defaultRenderer = defaultRenderer ?? throw new System.ArgumentNullException(nameof(defaultRenderer));
        }

        /// <summary>
        /// Exports a spreadsheet document to bytes using the default renderer
        /// </summary>
        public byte[] ToBytes(SpreadsheetDocument document)
        {
            return _defaultRenderer.Render(document);
        }

        /// <summary>
        /// Exports a spreadsheet document using a specific renderer
        /// </summary>
        public byte[] Export(SpreadsheetDocument document, ISpreadsheetRenderer renderer)
        {
            if (renderer == null)
                throw new System.ArgumentNullException(nameof(renderer));

            return renderer.Render(document);
        }
    }
}
