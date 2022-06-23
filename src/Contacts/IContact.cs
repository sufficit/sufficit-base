using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    public interface IContact
    {
        /// <summary>
        /// Identificador exclusivo deste contato
        /// </summary>         
        Guid ID { get; }

        string? Title { get; }

        DateTime Update { get; }
    }
}
