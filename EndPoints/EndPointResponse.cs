using Sufficit.Exceptions;
using System;
using System.Runtime.Serialization;

/// <summary>
/// Namespace no plural para evitar erros de correspondencia de nomes com outras apis
/// </summary>
namespace Sufficit.EndPoints
{
    [DataContract(Name = "Resposta")]
    [Serializable]
    public class EndPointResponse
    {
        [DataMember(EmitDefaultValue = true)]
        public bool Sucesso { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public JsonException Erro { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public dynamic Resultado { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false)]
        public object Teste { get; set; }        
    }
}
