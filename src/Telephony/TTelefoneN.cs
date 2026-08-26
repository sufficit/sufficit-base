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
        Padrao,

        /// <summary>
        /// Somente  números, sem alterações
        /// </summary>
        SomenteNumeros,

        /// <summary>
        /// Tipo internacional (ITU-T)
        /// </summary>
        /// <example>"+552140627711"</example>
        E164,

        /// <summary>
        /// Tipo internacional (ITU-T) Formatado para melhor entendimento
        /// </summary>
        E164Semantic
    }
}
