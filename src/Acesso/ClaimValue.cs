﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Acesso
{
    public class ClaimValue
    {
        public ClaimValue()
        {

        }

        public ClaimValue(string type, string value)
        {
            Type = type;
            Value = value;
        }

        public string Type { get; set; } = default!;

        public string Value { get; set; } = default!;
    }
}
