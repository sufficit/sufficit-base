using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    public class AttributeMonitor : Attribute
    {
        private readonly Attribute _attribute;

        public AttributeMonitor() => _attribute = new Attribute();

        public AttributeMonitor (Attribute attribute) { 
            _attribute = attribute;
            Key = _attribute.Key;
            Value = _attribute.Value;
            Description = _attribute.Description;
        }

        public bool HasChanged =>
            _attribute.Value != Value || _attribute.Description != Description;
    }
}
