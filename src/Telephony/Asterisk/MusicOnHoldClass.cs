using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk
{
    public class MusicOnHoldClass
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = default!;

        /// <summary>
        ///     <list type="bullet">
        ///         <item><term>files</term> read files from a directory in any Asterisk supported media format</item>
        ///         <item><term>playlist</term> provide a fixed list of filenames or HTTP(S) URLs to play</item>
        ///         <item><term>quietmp3</term> default</item>
        ///         <item><term>mp3</term> loud</item>
        ///         <item><term>mp3nb</term> unbuffered</item>
        ///         <item><term>quietmp3nb</term> quiet unbuffered</item>
        ///         <item><term>custom</term> run a custom application</item>
        ///     </list>
        /// </summary>
        [JsonPropertyName("mode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string Mode { get; set; } = default!;

        [JsonPropertyName("directory")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Directory { get; set; }

        [JsonPropertyName("application")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Application { get; set; }

        /// <summary>
        /// If this option is set for a class, then when callers are
        /// listening to music on hold, they can press this digit, 
        /// and they will switch to listening to this music class
        /// </summary>
        [JsonPropertyName("digit")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public char? Digit { get; set; }

        /// <summary>
        ///     If this option is set for a class, then when callers get put on hold, the specified sound will be played to them. Also, if using modes that Asterisk controls the playlist for (files, mp3, etc), the same sound will also be played between MOH songs
        /// </summary>
        [JsonPropertyName("announcement")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Announcement { get; set; }

        /// <summary>
        /// Sort the files in random order. Other sort options are:
        ///     <list type="bullet">
        ///         <item><term>alpha</term> the files are sorted in alphabetical order</item>
        ///         <item><term>randstart</term> the files are sorted in alphabetical order as well, but the first file is chosen at random</item>
        ///         <item><term>random</term> Sort the files in random order</item>
        ///     </list>
        /// </summary>
        [JsonPropertyName("sort")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Sort { get; set; }

        /// <summary>
        /// If enabled, once the end of the directory is reached, the last file played will be looped perpetually, rather than starting over at the beginning again. 
        /// Can be used with sort=alpha or randstart so you can control which file gets looped(the last one sorted alphabetically).
        /// (If sort=alpha, all files will be played at least once, but this may not be true with sort = randstart.)
        /// Default is no
        /// </summary>
        [JsonPropertyName("loop_last")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? LoopLast { get; set; }

        /// <summary>
        /// Only allow answered channels to have music on hold.
        /// Enabling this will prevent MOH on unanswered channels.
        /// (default: "no")
        /// </summary>
        [JsonPropertyName("answeredonly")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public bool? AnsweredOnly { get; set; }

        [JsonPropertyName("format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Format { get; set; }

        [JsonPropertyName("stamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }
    }
}
