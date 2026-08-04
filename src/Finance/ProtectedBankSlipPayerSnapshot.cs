namespace Sufficit.Finance
{
    /// <summary>
    /// Represents an encrypted payer snapshot and the key reference required to decrypt it.
    /// </summary>
    public class ProtectedBankSlipPayerSnapshot
    {
        public byte[] Payload { get; set; } = System.Array.Empty<byte>();
        public string KeyId { get; set; } = string.Empty;
    }
}
