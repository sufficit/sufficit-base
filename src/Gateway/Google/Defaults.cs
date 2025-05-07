using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Gateway.Google
{
    public static class Defaults
    {
        public static class Buckets
        {
            /// <summary>
            ///    Default bucket for all files
            /// </summary>
            public const string DEFAULT = "suff-storage";

            /// <summary>
            ///     Asterisk PABX playback audios, production mode, mapped /var/asterisk/lib/sounds
            /// </summary>
            public const string SYSTEMAUDIO = "suff-audios";

            /// <summary>
            ///     Context and User saved audio files, portal management
            /// </summary>
            public const string CONTEXTAUDIO = "suff-audio-system";

            public const string AVATARS = "suff-avatars";

            public const string CHATWOOT = "suff-chatwoot";

            public const string PHONECALLS = "suff-chamadas";

            /// <summary>
            ///     Asperisk PABX music on hold audio classes, production mode, mapped /var/asterisk/lib/moh
            /// </summary>
            public const string MUSICONHOLD = "suff-musiconhold";

            public const string BACKUP = "suff-backup";

        }
    }
}
