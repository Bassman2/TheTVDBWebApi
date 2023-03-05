namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Trailer record.
    /// </summary>
    public class Trailer
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
    }
}
