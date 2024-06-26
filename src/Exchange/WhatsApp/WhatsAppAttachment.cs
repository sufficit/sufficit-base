﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Exchange.WhatsApp
{
    public class WhatsAppAttachment : MessageAttachment
    {
        public long Length { get; set; }
        public string Base64
        {
            get
            {
                if (Content != null)
                    return Convert.ToBase64String(Content);
                return string.Empty;
            }
            set
            {
                Content = Convert.FromBase64String(value);
            }
        }
    }
}
