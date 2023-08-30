using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telefonia.Asterisk
{
    /// <summary>
    ///     Modo como o Asterisk costuma gerenciar os codecs <br />
    ///     Primeiro Bloqueados e Depois Permitidos
    /// </summary>
    public class AsteriskCodecConfiguration
    {
        IEnumerable<string>? disallowed;
        IEnumerable<string>? allowed;

        /// <summary>
        ///     Disallowed codecs. <br />
        ///     Set this to all to remove all codecs defined in the general settings and then specify specific codecs on the 'allow' setting, or just disallow specific codecs.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string> Disallowed { 
            get { return disallowed ?? Array.Empty<string>(); }
            set { disallowed = value; }
        }

        /// <summary>
        ///     Allow specific codecs, sign and in priority order. E.g. 'ulaw | g729'. Codecs allowed in the general settings will also be allowed unless removed with the 'disallow' directive.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public IEnumerable<string> Allowed
        {
            get { return allowed ?? Array.Empty<string>(); }
            set { allowed = value; }
        }
    }
}
