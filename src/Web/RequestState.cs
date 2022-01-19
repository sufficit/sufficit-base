using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Web
{
    /// <summary>
    /// Basic trackable informations to improve requests
    /// </summary>
    public class RequestState
    {
        public Guid IDMember { get; set; }
        public Uri RequestUri { get; set; }
    }
}
