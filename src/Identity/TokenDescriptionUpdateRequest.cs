namespace Sufficit.Identity
{
    public class TokenDescriptionUpdateRequest
    {
        public string Key { get; set; } = default!;

        /// <summary>
        /// Gets or sets the description associated with the object.
        /// </summary>
        public string? Description { get; set; }
    }
}
