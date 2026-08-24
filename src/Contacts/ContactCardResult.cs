using System;

namespace Sufficit.Contacts
{
    public sealed class ContactCardResult
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? Update { get; set; }
    }
}
