namespace Sufficit.Gateway.OpenAI
{
    /// <summary>
    /// OpenAI-compatible model object
    /// </summary>
    public class OpenAIModel
    {

        public string Id { get; set; } = string.Empty;

        public string Object { get; set; } = "model";

        public long Created { get; set; }

        public string OwnedBy { get; set; } = "sufficit";

    }
}
