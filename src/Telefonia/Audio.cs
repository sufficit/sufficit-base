using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Sufficit.Telefonia
{
    public class Audio
    {
        public Guid ID { get; set; }
        public Guid IDContexto { get; set; }
        public Guid IDArquivo { get; set; }
        public string Titulo { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do áudio para facilitar a identificação e uso, sem qualquer efeito técnico
        /// </summary>
        public string Descricao
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Titulo))
                {
                    switch (Titulo.Trim().ToLowerInvariant())
                    {
                        case "suporte": return "Utilizado para informar sobre a Caixa Postal, EX: { No momento não há atendentes disponíveis, deixe seu recado que entraremos em contato }";
                        case "expediente": return "Utilizado para informar que o cliente ligou em horário inválido, EX: { Nosso horário de expediênte é ..... }";
                        case "manutencao": return "Utilizado na URA Integrada, após encontrar cadastro do cliente, EX: { Houve um rompimento de fibra na região ...... a previsão de retorno é as ........ }";
                        case "preatendimento": return "Utilizado na URA Integrada, antes de transferirmos a chamada para um atendente (ramal), Normalmente para anúncios de falta de atendimento pessoal, EX: { Devido ao feriado de carnaval, não temos expediente administrativo hoje, voltamos normalmente no dia .... }";
                        case "atendimento": return "Normalmente utilizado para apresentar opções ou encaminhar o cliente, EX: { Olá, você ligou para Sufficit Soluções. Aguarde que estamos transferindo a sua chamada para um de nossos atendentes. }";
                        case "saudacao": return "Normalmente utilizado para identificar a empresa, EX: { Olá, você ligou para Sufficit Soluções. }";
                        default: return string.Empty;
                    }
                }
                else return string.Empty;
            }
        }

        public string URL { get { return IDArquivo.ToString(); } }

        #region FREEPBX

        public int FPBXid { get; set; }
        public string FPBXdisplayname { get; set; } = string.Empty;
        public string FPBXfilename { get; set; } = string.Empty;
        public string FPBXdescription { get; set; } = string.Empty;

        #endregion
    }
}
