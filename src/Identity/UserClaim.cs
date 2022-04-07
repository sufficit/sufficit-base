using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sufficit.Identity
{
    /// <summary>
    /// Database representation of a user claim
    /// </summary>
    public class UserClaim
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }
    }
}
