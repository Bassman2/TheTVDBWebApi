namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Biography record.
    /// </summary>
    public class Biography
    {
        [JsonPropertyName("biography")]
        public string BiographyName { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
