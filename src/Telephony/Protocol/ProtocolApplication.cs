using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Sufficit.Telephony.Protocol
{
    /// <summary>A native protocol instance with its own mode and downstream route.</summary>
    [Table("telp_protocol_applications")]
    public sealed class ProtocolApplication : IDestination, IFriendly
    {
        public const string ASTERISKCONTEXT = "sufficit-app-protocol";
        [Key, Column("id"), JsonPropertyName("id")] public Guid Id { get; set; }
        [Column("contextid"), JsonPropertyName("contextid")] public Guid ContextId { get; set; }
        [Required, MaxLength(255), Column("title"), JsonPropertyName("title")] public string Title { get; set; } = string.Empty;
        [Column("direct"), JsonPropertyName("direct")] public bool Direct { get; set; }
        [MaxLength(250), Column("destination"), JsonPropertyName("destination")] public string Destination { get; set; } = string.Empty;
        [ConcurrencyCheck, Column("revision"), JsonPropertyName("revision")] public Guid Revision { get; set; }
        [Column("updatedatutc"), JsonPropertyName("updatedatutc")] public DateTime UpdatedAtUtc { get; set; }
        [Column("deletedatutc"), JsonPropertyName("deletedatutc")] public DateTime? DeletedAtUtc { get; set; }

        Guid? IDestination.Id => Id;
        Guid? IDestination.ContextId => ContextId;
        string IDestination.TypeName => nameof(ProtocolApplication);
        string IDestination.Asterisk => $"{ASTERISKCONTEXT},{Id:N},1";
        string? IDestination.Title => Title;
        string? IDestination.Description => Direct ? "Protocolo direto" : "Oferecer protocolo";
        string IFriendly.ToFriendly() => "Protocolo";

        /// <summary>Only literal Asterisk routes, never channel expansion or executable expressions.</summary>
        public static bool IsDestinationValid(string? destination)
            => destination == string.Empty || (destination != null && destination.Length <= 250 &&
                Regex.IsMatch(destination, @"\A[A-Za-z0-9_-]+,[A-Za-z0-9_+*#.-]+,[1-9][0-9]*\z"));

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title) || Title.Length > 255 || !IsDestinationValid(Destination))
                throw new ArgumentException("Invalid protocol title or destination.");
            if (ContextId == Guid.Empty && Destination.Length != 0)
                throw new ArgumentException("Global protocol utilities cannot have a tenant destination.");
            if (Id != Guid.Empty && Destination == $"{ASTERISKCONTEXT},{Id:N},1")
                throw new ArgumentException("A protocol application cannot target itself.");
        }
    }
}
