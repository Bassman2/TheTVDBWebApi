namespace TheTVDBWebApi
{
    /// <summary>
    /// Trailer record.
    /// </summary>
    public class Trailer
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
 
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("language")]
        public Languages Language { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
    }
}
