namespace TheTVDBWebApi
{
    /// <summary>
    /// Base artwork record.
    /// </summary>
    public class ArtworkBaseRecord
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("language")]
        public Languages Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>The artwork type corresponds to the ids from the /artwork/types endpoint.</remarks>
        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }
    }
}
