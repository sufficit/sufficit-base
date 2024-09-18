using Sufficit.Telephony;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Sufficit.Gateway.ReceitaNet
{
    public class RNOptions : IDestination, IFriendly
    {
        public const string FREEPBXCONTEXT = "sufficit-freepbx-gateway-receitanet";
        public const string FRIENDLYNAME = "ReceitaNet";

        #region IMPLEMENT INTERFACE IFRIENDLY

        string IFriendly.ToFriendly() => FRIENDLYNAME;

        #endregion
        #region IMPLEMENT INTERFACE IDESTINATION

        Guid? IDestination.Id => this.Id;

        string IDestination.TypeName => this.GetType().Name;

        Guid? IDestination.ContextId => this.ContextId;

        string IDestination.Asterisk => $"{FREEPBXCONTEXT},{Id:N},1";

        string? IDestination.Title => this.Title;

        string? IDestination.Description => null;

        #endregion

        /// <summary>
        /// ID do aplicativo no sistema <br />
        /// Identificador para diferenciar nos relatórios
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// ID do cliente ao qual se aplica 
        /// </summary>
        public Guid ContextId { get; set; }

        /// <summary>
        /// Titulo para identificação no portal, caso haja mais de um (improvavel)
        /// </summary>
        [StringLength(40)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Habilitado ?
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Fichas de acesso <br />
        /// </summary>
        /// <example>"5e876bd7-d242-4aec-a72c-abeaab2f2817" -> default token</example>        
        public string[] Tokens { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Falar o protocolo sempre que disponível ?
        /// </summary>
        public bool Protocol { get; set; }

        /// <summary>
        /// Announce support procedures before continue
        /// </summary>
        public bool Procedures { get; set; }

        /// <summary>
        /// Processar etapa de envio de fatura mesmo ainda dentro do vencimento
        /// </summary>
        public bool ForceBilling { get; set; }

        /// <summary>
        /// Should ask for document event if the contract was identified by source phone
        /// </summary>
        [JsonPropertyName("ask_for_document")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool AskForDocument { get; set; } = false;

        /// <summary>
        ///     Should continue script on get connection status error ?
        /// </summary>
        [JsonPropertyName("continue_on_status_error")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public bool ContinueOnStatusError { get; set; } = true;

        /// <summary>
        ///     Should open a new ticket everytime that the call was sended to an attendant ?   
        /// </summary>
        /// <remarks>See ReceitaNet.TicketEnum for diferent types</remarks>
        [JsonPropertyName("ticket_on_attendant")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int? TicketOnAttendant { get; set; } = 1;

        /// <summary>
        /// Locutor a ser usado como principal para as falas
        /// </summary>
        [JsonPropertyName("announcer")]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public RNAnnouncer Announcer { get; set; }

        /// <summary>
        /// Plays before starting
        /// </summary>
        [JsonPropertyName("announcement")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault | JsonIgnoreCondition.WhenWritingNull)]        
        public Guid? Announcement { get; set; }

        /// <summary>
        /// Data / Hora da ultima atualização
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Updated { get; }
    }
}
