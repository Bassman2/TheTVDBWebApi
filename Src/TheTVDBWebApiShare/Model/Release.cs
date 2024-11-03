namespace TheTVDBWebApi
{
    /// <summary>
    /// Release record.
    /// </summary>
    public class Release
    {
        [JsonPropertyName("country")]
        public Countries Country { get; set; }

        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("detail")]
        public string? Detail { get; set; }
    }
}
