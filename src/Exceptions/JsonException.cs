using System;
using System.Runtime.Serialization;

/// <summary>
/// Namespace no plural para evitar erros de correspondencia de nomes com outras apis
/// </summary>
namespace Sufficit
{
    [DataContract(Name = "Exception")]
    [Serializable]
    public class JsonException
    {
        [DataMember(EmitDefaultValue = false)]
        public string? Type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string? InnerException { get; set; }

        public static implicit operator JsonException (System.Exception Ex)
        {
            var item = new JsonException();
            item.Type = Ex.GetType().ToString();
            item.InnerException = Ex.InnerException?.ToString();
            item.Message = Ex.Message;
            return item;
        }

        public static implicit operator System.Exception (JsonException Ex)
            => new Exception(Ex.Message, new Exception(Ex.InnerException));          
    }
}
