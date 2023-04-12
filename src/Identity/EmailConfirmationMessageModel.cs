﻿using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Identity
{
    public struct EmailConfirmationMessageModel : IMessageModel
    {
        public const string UniqueID = "68951610-03b6-4b6c-9a25-c24b4e76f79f";

        public Guid Id => Guid.Parse(UniqueID);

        public string Name => "E-Mail Confirmation";
    }
}
