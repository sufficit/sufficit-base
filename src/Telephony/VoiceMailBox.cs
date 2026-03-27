using System.Text.Json.Serialization;
using System;

namespace Sufficit.Telephony
{
    public class VoiceMailBox : MailBox
    {
        public new const string FRIENDLYNAME = "Caixa Postal de Voz";
        public const string ASTERISKCONTEXT = "sufficit-app-voicemail";

        [JsonPropertyName("id")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public new Guid Id
        {
            get => base.Id ?? Guid.Empty;
            set => base.Id = value;
        }

        [JsonPropertyName("contextid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public new Guid ContextId
        {
            get => base.ContextId ?? Guid.Empty;
            set => base.ContextId = value;
        }

        [JsonPropertyName("asterisk")]
        public override string Asterisk =>  $"{ASTERISKCONTEXT},{Id:N},1";
        
        [JsonPropertyName("destination")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public string? Destination { get; set; }

        [JsonPropertyName("greetingaudioid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? GreetingAudioId { get; set; }

        [JsonPropertyName("farewellaudioid")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
        public Guid? FarewellAudioId { get; set; }

        [JsonPropertyName("beep")]
        public bool Beep { get; set; } = true;

        [JsonPropertyName("answermode")]
        public AnswerMode AnswerMode { get; set; } = AnswerMode.ForceAnswer;

        [JsonPropertyName("timestamp")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public DateTime Timestamp { get; set; }

        [JsonIgnore]
        public override string TypeName => typeof(VoiceMailBox).Name;
    }
}