using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sufficit.Gateway.PhoneVox
{
    public static class PhoneVoxExtensions
    {
        public static PhoneVoxGateway ToGateway (this PhoneVoxOptions source, ICollection<PhoneVoxDestination>? destinations = null)
        {
            return new PhoneVoxGateway()
            {
                 Id = source.Id,
                 ContextId = source.ContextId,
                 App = source.App,
                 IdOccurrence = source.IdOccurrence,
                 IdOS = source.IdOS,
                 IdSection = source.IdSection,
                 Server = source.Server,
                 System = source.System,
                 Destinations = destinations ?? Array.Empty<PhoneVoxDestination>()
            };
        }
    }
}
