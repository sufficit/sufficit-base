using Sufficit.Telephony;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.PhoneVox
{
    public class PhoneVoxDestination
    {
        #region DESTINATIONS TITLEs

        public const string OTHER = "other";
        public const string COMERCIAL = "comercial";
        public const string FINANCE = "finance";
        public const string SUPPORT = "support";

        #endregion

        public string Title { get; set; } = default!;

        public string Asterisk { get; set; } = default!;
    }
}
