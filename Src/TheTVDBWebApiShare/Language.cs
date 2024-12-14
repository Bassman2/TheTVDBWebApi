namespace TheTVDBWebApi
{
    /// <summary>
    /// Language record.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Id of the language.
        /// </summary>
        [JsonPropertyName("id")]
        public Languages Id { get; set; }

        /// <summary>
        /// Name of the language.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nativeName")]
        public string? NativeName { get; set; }

        [JsonPropertyName("shortCode")]
        public string? ShortCode { get; set; }
    }
}
