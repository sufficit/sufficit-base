using System;

namespace Sufficit.Telephony.Portability
{
    /// <summary>
    /// Search parameters for portability notes.
    /// Designed to be bound from query string where all filters are optional.
    /// </summary>
    public class PortabilityNotesSearchParameters
    {
        /// <summary>
        /// Optional portability process identifier.
        /// When empty, notes are not filtered by process.
        /// Query parameter: id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Optional visibility filter.
        /// - true: public notes only
        /// - false: internal notes only
        /// - null: no visibility filter
        /// Query parameter: public
        /// </summary>
        public bool? Public { get; set; }

        /// <summary>
        /// Optional author filter (notes created by the given user).
        /// Query parameter: userid
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// Optional note text filter.
        /// Matches against <see cref="PortabilityNote.Text"/>.
        /// Query parameter: text (complex)
        /// Examples:
        /// - text.text=hello
        /// - text.text=hello (and set text.exactmatch=true)
        /// </summary>
        public global::Sufficit.TextFilter? Text { get; set; }

        /// <summary>
        /// Optional timestamp range filter.
        /// Matches against <see cref="PortabilityNote.Timestamp"/>.
        /// Query parameter: timestamp (complex)
        /// Examples:
        /// - timestamp.start=2026-02-01T00:00:00Z (and set timestamp.end=2026-02-29T23:59:59Z)
        /// - timestamp.exact=2026-02-20T10:00:00Z
        /// </summary>
        public global::Sufficit.DateTimeRangeNew? Timestamp { get; set; }
    }
}
