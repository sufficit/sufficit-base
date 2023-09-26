using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Telephony.Asterisk.PJSIP
{
    public class PJSIPAuth
    {
        [JsonPropertyName("id")]
        public virtual string id { get; set; } = default!;

        /// <summary>
        ///     Authentication type
        /// </summary>
        [JsonPropertyName("auth_type")]
        [Column("auth_type")]
        public virtual string? auth_type { get; set; }

        /// <summary>
        ///     Lifetime of a nonce associated with this authentication config
        /// </summary>
        [JsonPropertyName("nonce_lifetime")]
        [Column("nonce_lifetime")]
        public virtual string? nonce_lifetime { get; set; }

        /// <summary>
        ///     MD5 Hash used for authentication
        /// </summary>
        [JsonPropertyName("md5_cred")]
        [Column("md5_cred")]
        public virtual string? md5_cred { get; set; }

        /// <summary>
        ///     Plain text password used for authentication
        /// </summary>
        [JsonPropertyName("password")]
        [Column("password")]
        public virtual string? password { get; set; }

        /// <summary>
        ///     OAuth 2.0 refresh token
        /// </summary>
        [JsonPropertyName("refresh_token")]
        [Column("refresh_token")]
        [NotMapped]
        public virtual string? refresh_token { get; set; }

        /// <summary>
        ///     OAuth 2.0 application's client id
        /// </summary>
        [JsonPropertyName("oauth_clientid")]
        [Column("oauth_clientid")]
        [NotMapped]
        public virtual string? oauth_clientid { get; set; }

        /// <summary>
        ///     OAuth 2.0 application's secret
        /// </summary>
        [JsonPropertyName("oauth_secret")]
        [Column("oauth_secret")]
        [NotMapped]
        public virtual string? oauth_secret { get; set; }

        /// <summary>
        ///     SIP realm for endpoint
        /// </summary>
        [JsonPropertyName("realm")]
        [Column("realm")]
        public virtual string? realm { get; set; }

        /// <summary>
        ///     Username to use for account
        /// </summary>
        [JsonPropertyName("username")]
        [Column("username")]
        public virtual string? username { get; set; }
    }
}
