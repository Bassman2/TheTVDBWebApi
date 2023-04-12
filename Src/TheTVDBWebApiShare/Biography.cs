namespace TheTVDBWebApi
{
    /// <summary>
    /// Biography record.
    /// </summary>
    public class Biography
    {
        [JsonPropertyName("biography")]
        public string BiographyName { get; set; }

        [JsonPropertyName("language")]
        public Languages Language { get; set; }
    }
}
