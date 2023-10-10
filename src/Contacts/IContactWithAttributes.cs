﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Sufficit.Contacts
{
    public interface IContactWithAttributes : IContact
    {
        public HashSet<Attribute> Attributes { get; }
    }
}
