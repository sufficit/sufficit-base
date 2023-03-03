using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Contacts
{
    public class ContactsOptions
    {
        public const string SECTIONNAME = "Sufficit:Contacts";

        public Uri AvatarPath { get; set; } = new Uri("https://www.sufficit.com.br/relacionamento/avatar.ashx");

        public override bool Equals(object? other) 
            => other is ContactsOptions p && (p.AvatarPath).Equals(AvatarPath);

        public override int GetHashCode() 
            => (AvatarPath).GetHashCode();
    }
}
