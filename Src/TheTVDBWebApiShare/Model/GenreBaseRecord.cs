namespace TheTVDBWebApi
{
    /// <summary>
    /// Base genre record.
    /// </summary>
    public class GenreBaseRecord
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }
    }
}
