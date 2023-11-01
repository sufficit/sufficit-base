using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    public class ContactsOptions
    {
        public const string SECTIONNAME = nameof(Sufficit) + ":" + nameof(Contacts);

        public Uri AvatarPath { get; set; } = new Uri($"{EndPoints.Constants.SERVERURL}/contact/avatar");

        public override bool Equals(object? other) 
            => other is ContactsOptions p && (p.AvatarPath).Equals(AvatarPath);

        public override int GetHashCode() 
            => (AvatarPath).GetHashCode();
    }
}
