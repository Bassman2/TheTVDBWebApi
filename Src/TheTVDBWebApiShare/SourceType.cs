namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Source type record.
    /// </summary>
    public class SourceType
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("postfix")]
        public string Postfix { get; set; }

        [JsonPropertyName("prefix")]
        public string Prefix { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("sort")]
        public long Sort { get; set; }
    }
}
