using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony.FreePBX
{
    public class FreePBXUser
    {
        public string extension { get; set; } = default!;
        public string? password { get; set; } 
        public string? name { get; set; } 
        public string? voicemail { get; set; }
        public int? ringtimer { get; set; }
        public string? noanswer { get; set; }
        public string? outboundcid { get; set; }
        public string? recording { get; set; }
        public string? sipname { get; set; }
        public string noanswer_cid { get; set; } = string.Empty;
        public string busy_cid { get; set; } = string.Empty;
        public string chanunavail_cid { get; set; } = string.Empty;
        public string noanswer_dest { get; set; } = string.Empty;
        public string busy_dest { get; set; } = string.Empty;
        public string chanunavail_dest { get; set; } = string.Empty;
        public string mohclass { get; set; } = "default";
    }
}
