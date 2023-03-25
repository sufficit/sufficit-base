using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaNet
{
    public class RNOptions : IRNOptions
    {
        /// <summary>
        /// ID do aplicativo no sistema <br />
        /// Identificador para diferenciar nos relatórios
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <inheritdoc cref="IRNOptions.ContextId" />
        public Guid ContextId { get; set; }

        /// <inheritdoc cref="IRNOptions.Title" />
        [StringLength(40)]
        public string Title { get; set; } = string.Empty;

        /// <inheritdoc cref="IRNOptions.Enabled" />
        public bool Enabled { get; set; }

        /// <inheritdoc cref="IRNOptions.Tokens" />
        [StringLength(200)]
        public string[] Tokens { get; set; } = Array.Empty<string>();

        /// <inheritdoc cref="IRNOptions.Protocol" />
        public bool Protocol { get; set; }

        /// <inheritdoc cref="IRNOptions.Procedures" />
        public bool Procedures { get; set; }

        /// <inheritdoc cref="IRNOptions.ForceBilling" />
        public bool ForceBilling { get; set; }

        /// <inheritdoc cref="IRNOptions.Announcer" />
        public RNAnnouncer Announcer { get; set; }

        /// <inheritdoc cref="IRNOptions.Announcement" />
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]        
        public Guid? Announcement { get; set; }


        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated { get; }
    }
}
