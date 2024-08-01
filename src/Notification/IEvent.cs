﻿using Sufficit.Exchange;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sufficit.Notification
{
    public interface IEvent : IIdTitlePair
    {
        string? GetKey();

        Guid? GetContextId();

        Guid? GetReferenceId();
        
        ValueTask<string> GetBody(string? extra = null, TChannel channel = default);

        [JsonPropertyName("method")]
        SubscribeMethod Method { get; }
    }
}
