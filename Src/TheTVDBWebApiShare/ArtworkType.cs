namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Artwork type record.
    /// </summary>
    public class ArtworkType
    {
        [JsonPropertyName("height")]
        public long Height { get; set; }

        /// <summary>
        /// Identifier of the artwork type.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("imageFormat")]
        public string ImageFormat { get; set; }

        /// <summary>
        /// Name of the artwork status.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("recordType")]
        public string RecordType { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("thumbHeight")]
        public long ThumbHeight { get; set; }

        [JsonPropertyName("thumbWidth")]
        public long ThumbWidth { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }
    }
}
