using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sufficit.Gateway.ReceitaNet
{
    public class RNDestination : IRNDestination
    {
        #region DESTINATIONS TITLEs

        public const string FAIL = "fail";
        public const string CONNECTED = "connected";
        public const string HANGUP = "hangup";
        public const string SOLICITED = "solicited";
        public const string UNKNOWN = "unknown";

        #endregion

        [Key]
        public Guid ID { get; set; }

        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(200)]
        public string Asterisk { get; set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; }
    }
}
