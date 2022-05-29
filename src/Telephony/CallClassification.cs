using System.Linq;

namespace Sufficit.Telephony
{
    public class CallClassification
    {
        /// <summary>
        /// Resume a classificação da chamada em INTERNA, ENTRADA ou SAIDA
        /// </summary>
        public CallDirection Direction { get; set; }

        /// <summary>
        /// Serve para diferentes tipos de tarifação <br />
        /// MOVEL, FIXO, ANONIMO, INTERNACIONAL
        /// </summary>
        public ExtensionClassificationModel Model { get; set; }

        public bool HasFlag(TChamada flag)
        {
            switch (flag)
            {
                case TChamada.Entrada:                    
                        return Direction.HasFlag(CallDirection.INCOMING);
                                        
                default: return false;
            }
        }

        public bool HasFlag(CallDirection flag) =>
            Direction.HasFlag(flag);

        public bool HasFlag(ExtensionClassificationModel flag) =>
            Model.HasFlag(flag);


        #region OVERRIDES

        public override string ToString()
        {
            string[] resultado = new string[2];
            if(Direction != CallDirection.UNKNOWN)            
                resultado[0] = Direction.ToString();
            
            if(Model != ExtensionClassificationModel.UNKNOWN)
                resultado[1] = Model.ToString();

            return string.Join(",", resultado.Where(s => !string.IsNullOrEmpty(s)));
        }

        #endregion
    }
}
