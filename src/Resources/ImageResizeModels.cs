namespace Sufficit.Resources
{
    public sealed class ImageResizeRequest
    {
        public string? ImageDataUrl { get; set; }

        public int CropWidth { get; set; }

        public int CropHeight { get; set; }

        public int OffsetX { get; set; }

        public int OffsetY { get; set; }
    }

    public sealed class ImageResizeResult
    {
        public string ImageDataUrl { get; set; } = string.Empty;
    }
}
