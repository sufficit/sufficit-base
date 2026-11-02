namespace Sufficit.Telephony
{
    /// <summary>Destination chosen for a legacy announcement, guarded by the version the editor read.</summary>
    public sealed class LegacyAnnouncementDestinationSelection
    {
        public LegacyAnnouncementDestinationSelection() { }

        public LegacyAnnouncementDestinationSelection(string destination, string expectedVersion)
        {
            Destination = destination;
            ExpectedVersion = expectedVersion;
        }

        // Null when absent, not empty: the API's implicit [Required] must reject a missing field.
        public string Destination { get; set; } = null!;
        public string ExpectedVersion { get; set; } = null!;
    }
}
