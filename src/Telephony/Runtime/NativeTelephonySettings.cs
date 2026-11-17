#nullable enable
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony.Runtime
{
    /// <summary>One global, coherent audio/announcement policy. Never contains node credentials.</summary>
    public sealed class NativeTelephonySettings
    {
        public const string Section = "native-telephony";
        [JsonRequired] public NativeAudioSettings Audio { get; set; } = new NativeAudioSettings();
        [JsonRequired] public NativeAnnouncementSettings Announcements { get; set; } = new NativeAnnouncementSettings();

        public static NativeTelephonySettings Parse(string document)
        {
            if (string.IsNullOrWhiteSpace(document) || document.Length > 1000000)
                throw new ArgumentException("A bounded complete settings document is required.");
            var value = JsonSerializer.Deserialize<NativeTelephonySettings>(document,
                new JsonSerializerOptions { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow, PropertyNameCaseInsensitive = true, MaxDepth = 12 })
                ?? throw new ArgumentException("Settings are required.");
            value.Validate();
            return value;
        }
        public string Document() { Validate(); return JsonSerializer.Serialize(this); }
        public void Validate()
        {
            if (Audio == null || Announcements == null) throw new ArgumentException("Both settings sections are required.");
            Ids(Audio.ContextIds); Ids(Audio.AudioIds); Ids(Announcements.ContextIds);
            Ids(Announcements.AnnouncementIds); Ids(Announcements.AutomaticContextIds);
            if (Audio.RequiredNodeIds == null || Audio.RequiredNodeIds.Length > 100 ||
                Audio.RequiredNodeIds.Any(n => n == null || !Regex.IsMatch(n, "\\A[a-zA-Z0-9_-]{1,64}\\z")) ||
                Audio.RequiredNodeIds.Distinct(StringComparer.Ordinal).Count() != Audio.RequiredNodeIds.Length)
                throw new ArgumentException("Invalid required node identities.");
            if (!string.IsNullOrEmpty(Audio.SoundsPrefix) && !Regex.IsMatch(Audio.SoundsPrefix,
                "\\A/?[a-zA-Z0-9_-]+(?:/[a-zA-Z0-9_-]+)*/\\z"))
                throw new ArgumentException("Invalid canonical native sounds prefix.");
            if (Audio.Enabled && (Audio.ContextIds.Length == 0 || Audio.RequiredNodeIds.Length == 0 || string.IsNullOrEmpty(Audio.SoundsPrefix)))
                throw new ArgumentException("Enabled audio requires explicit customers, nodes and sounds prefix.");
            if (Announcements.Enabled && !Audio.Enabled)
                throw new ArgumentException("Active announcements require audio playback.");
            if (Announcements.CustomerControlsOnly && Announcements.AvailableByDefault)
                throw new ArgumentException("Choose one native announcement availability mode.");
            if (Announcements.CustomerControlsOnly || Announcements.AvailableByDefault)
            {
                if (Announcements.ContextIds.Length != 0 || Announcements.AnnouncementIds.Length != 0 ||
                    Announcements.AutomaticContextIds.Length != 0)
                    throw new ArgumentException("Native-only announcements cannot include pilot scopes.");
            }
            else if (Announcements.AutomaticContextIds.Except(Announcements.ContextIds).Any() ||
                (Announcements.Enabled && Announcements.ContextIds.Length == 0))
                throw new ArgumentException("The legacy pilot requires an explicit announcement scope.");
        }
        private static void Ids(Guid[] values)
        {
            if (values == null || values.Length > 20000 || values.Contains(Guid.Empty) || values.Distinct().Count() != values.Length)
                throw new ArgumentException("Invalid or duplicate scope identities.");
        }
    }
    public sealed class NativeAudioSettings
    {
        [JsonRequired] public bool Enabled { get; set; }
        [JsonRequired] public string[] RequiredNodeIds { get; set; } = Array.Empty<string>();
        [JsonRequired] public string SoundsPrefix { get; set; } = string.Empty;
        [JsonRequired] public Guid[] ContextIds { get; set; } = Array.Empty<Guid>();
        [JsonRequired] public Guid[] AudioIds { get; set; } = Array.Empty<Guid>();
    }
    public sealed class NativeAnnouncementSettings
    {
        [JsonRequired] public bool Enabled { get; set; }
        /// <summary>Use the persisted customer enablement and discover all active native announcements for that customer.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool CustomerControlsOnly { get; set; }
        /// <summary>Announcements are available unless the customer has an explicit disablement.</summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool AvailableByDefault { get; set; }
        public Guid[] ContextIds { get; set; } = Array.Empty<Guid>();
        public Guid[] AnnouncementIds { get; set; } = Array.Empty<Guid>();
        public Guid[] AutomaticContextIds { get; set; } = Array.Empty<Guid>();
    }
}
