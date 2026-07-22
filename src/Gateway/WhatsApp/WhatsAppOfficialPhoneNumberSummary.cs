namespace Sufficit.Gateway.WhatsApp
{
    /// <summary>
    /// One phone number a token can see, for autocomplete in the manual connect flow.
    /// </summary>
    public class WhatsAppOfficialPhoneNumberSummary
    {
        public string PhoneNumberId { get; set; } = string.Empty;

        public string DisplayPhoneNumber { get; set; } = string.Empty;

        public string? VerifiedName { get; set; }
    }
}
