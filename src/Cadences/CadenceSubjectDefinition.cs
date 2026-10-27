namespace Sufficit.Cadences
{
    /// <summary>A kind of subject a module opens cases for (e.g. "sales.contract-period"). The cadence core treats it as opaque.</summary>
    public sealed class CadenceSubjectDefinition
    {
        public string Key { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        /// <summary>Owning module (display name).</summary>
        public string Module { get; set; } = string.Empty;
    }
}
