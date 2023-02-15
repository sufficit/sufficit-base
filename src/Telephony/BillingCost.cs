using System;
using System.Collections.Generic;
using System.Text;

namespace Sufficit.Telephony
{
    public class BillingCost
    {
        public Guid IDContext   { get; set; }
        public Guid IDProvider { get; set; }
        public string Extension { get; set; } = string.Empty;
        public decimal Cost { get; set; }
        public int Discard { get; set; }
        public int Minimum { get; set; }
        public int Cadence { get; set; }

        /// <summary>
        /// Calcular o Valor com as informações atuais
        /// </summary>
        /// <returns></returns>
        public decimal Calculate(long duration) => Calculate(this.Discard, this.Minimum, this.Cadence, this.Cost, duration);

        /// <summary>
        /// Caluculo genérico de valores para chamadas
        /// </summary>
        /// <param name="Descarte"></param>
        /// <param name="Minimo"></param>
        /// <param name="Cadencia"></param>
        /// <param name="Custo"></param>
        /// <param name="Tempo"></param>
        /// <returns></returns>
        public static decimal Calculate(int Descarte, int Minimo, int Cadencia, decimal Custo, long Tempo)
        {
            decimal valor = 0;
            if (Tempo > Descarte)
            {
                if (Tempo > Minimo)
                {
                    int cadencia = (int)Math.Ceiling((double)Tempo / (double)Cadencia);
                    valor = (Custo / (60 / Cadencia)) * cadencia;
                }
                else { valor = Custo / (60 / Minimo); }
            }
            return valor;
        }
    }
}
