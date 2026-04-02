namespace Sufficit.Telephony
{
    public class InterconnectionTestCallRequest
    {
        public Interconnection Interconnection { get; set; } = new Interconnection();

        public string Destination { get; set; } = string.Empty;
    }
}
