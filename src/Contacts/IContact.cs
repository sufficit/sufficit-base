using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    public interface IContact : IIdTitlePair
    {
        /// <summary>
        /// Last update timestamp
        /// </summary>
        DateTime Update { get; }
    }
}
