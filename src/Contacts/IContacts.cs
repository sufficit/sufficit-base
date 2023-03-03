using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    /// <summary>
    /// Static Contacts, reserved ids
    /// </summary>
    public static class IContacts
    {
        /// <summary>
        /// Empty, unknown contact
        /// </summary>
        public const string Unknown = "00000000-0000-0000-0000-000000000000";
    }
}
