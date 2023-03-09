namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Base artwork record.
    /// </summary>
    public class ArtworkBaseRecord
    {
        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("thumbnail")]
        public string thumbnail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>The artwork type corresponds to the ids from the /artwork/types endpoint.</remarks>
        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }
    }
}
