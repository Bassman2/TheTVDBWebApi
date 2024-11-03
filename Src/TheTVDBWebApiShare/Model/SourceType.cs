namespace TheTVDBWebApi
{
    /// <summary>
    /// Source type record.
    /// </summary>
    public class SourceType
    {
        /// <summary>
        /// Id of the source type.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the source type.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("prefix")]
        public string? Prefix { get; set; }

        [JsonPropertyName("postfix")]
        public string? Postfix { get; set; }

        [JsonPropertyName("sort")]
        public long Sort { get; set; }
    }
}
