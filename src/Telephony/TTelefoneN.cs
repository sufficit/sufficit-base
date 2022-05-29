namespace Sufficit.Telephony
{
    /// <summary>
    /// Diferentes formatações para o mesmo Número de Telefone
    /// </summary>
    public enum TTelefoneN
    {
        /// <summary>
        /// Somente números, corrigindo 0800 e 10 dígitos <br/>
        /// Usado no FreePBX para rota de saídas e discagem externas
        /// </summary>
        /// <example>0800 042 0162 -> 558000420162</example>
        /// <example>DID: (21) 4062-7711 -> 552140627711</example>
        Padrao,

        /// <summary>
        /// Somente  números, sem alterações
        /// </summary>
        /// <example>0800 042 0162 -> 08000420162</example>
        /// <example>DID: (21) 4062-7711 -> 2140627711</example>
        SomenteNumeros,

        /// <summary>
        /// Tipo internacional (ITU-T)
        /// </summary>
        /// <example>+552140627711</example>
        E164,

        /// <summary>
        /// Tipo internacional (ITU-T) Formatado para melhor entendimento
        /// </summary>
        /// <example>+55 ( 21 ) 4062 - 7711</example>
        E164Semantic
    }
}
