using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sufficit.Exchange.Templates
{
    /// <summary>
    /// Message Template with Entity Framework support
    /// Consolidated class serving both as Entity and DTO following Sufficit standards
    /// Stores approved templates for different message types (email, SMS, WhatsApp, etc.)
    /// </summary>
    [Table("exch_message_templates")]
    public class MessageTemplate
    {
        #region Properties

        /// <summary>
        /// Database primary key - Guid following Sufficit standards
        /// </summary>
        [Key]
        [Column("id", TypeName = "BINARY(16)")]
        [JsonPropertyName("id")]
        [JsonPropertyOrder(1)]
        public Guid Id { get; set; }

        /// <summary>
        /// Business identifier (VARCHAR(255), unique) following Sufficit Title standard
        /// Used as natural key for template identification
        /// </summary>
        [Column("title")]
        [MaxLength(255)]
        [Required]
        [JsonPropertyName("title")]
        [JsonPropertyOrder(2)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Human-readable name (VARCHAR(500)) following Sufficit Description standard
        /// </summary>
        [Column("description")]
        [MaxLength(500)]
        [Required]
        [JsonPropertyName("description")]
        [JsonPropertyOrder(3)]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Context/organization ID that owns this template
        /// </summary>
        [Column("context_id", TypeName = "BINARY(16)")]
        [JsonPropertyName("contextId")]
        [JsonPropertyOrder(4)]
        public Guid ContextId { get; set; }

        /// <summary>
        /// Template approval status
        /// </summary>
        [Column("is_approved")]
        [JsonPropertyName("isApproved")]
        [JsonPropertyOrder(5)]
        public bool IsApproved { get; set; }

        /// <summary>
        /// Template contents by message type (email, sms, whatsapp, etc.)
        /// Not stored directly in database - use ContentsJson for persistence
        /// </summary>
        [NotMapped]
        [JsonPropertyName("contents")]
        [JsonPropertyOrder(6)]
        public Dictionary<string, MessageTemplateContent> Contents { get; set; } = new();

        /// <summary>
        /// Template variables for dynamic content replacement
        /// Not stored directly in database - use VariablesJson for persistence
        /// </summary>
        [NotMapped]
        [JsonPropertyName("variables")]
        [JsonPropertyOrder(7)]
        public Dictionary<string, TemplateVariable> Variables { get; set; } = new();

        /// <summary>
        /// JSON storage for template contents by message type
        /// Serialized to JSON string for database storage
        /// </summary>
        [Column("contents", TypeName = "LONGTEXT CHARACTER SET utf8mb4")]
        [JsonIgnore]
        public string ContentsJson 
        { 
            get => JsonSerializer.Serialize(Contents);
            set => Contents = string.IsNullOrEmpty(value) 
                ? new Dictionary<string, MessageTemplateContent>() 
                : JsonSerializer.Deserialize<Dictionary<string, MessageTemplateContent>>(value) ?? new();
        }

        /// <summary>
        /// JSON storage for template variables
        /// Serialized to JSON string for database storage
        /// </summary>
        [Column("variables", TypeName = "LONGTEXT CHARACTER SET utf8mb4")]
        [JsonIgnore]
        public string VariablesJson 
        { 
            get => JsonSerializer.Serialize(Variables);
            set => Variables = string.IsNullOrEmpty(value) 
                ? new Dictionary<string, TemplateVariable>() 
                : JsonSerializer.Deserialize<Dictionary<string, TemplateVariable>>(value) ?? new();
        }

        /// <summary>
        /// Timestamp for versioning only - no audit fields following Sufficit standards
        /// </summary>
        [Column("timestamp")]
        [JsonPropertyName("timestamp")]
        [JsonPropertyOrder(8)]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new message template instance
        /// </summary>
        public MessageTemplate()
        {
        }

        /// <summary>
        /// Creates a new message template with basic information
        /// </summary>
        /// <param name="title">Template title (business identifier)</param>
        /// <param name="description">Template description (human-readable name)</param>
        public MessageTemplate(string title, string? description = null)
        {
            Title = title ?? string.Empty;
            Description = description ?? string.Empty;
        }

        #endregion
    }
}
