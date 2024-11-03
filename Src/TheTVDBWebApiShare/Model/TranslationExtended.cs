namespace TheTVDBWebApi
{
    /// <summary>
    /// Translation extended record.
    /// </summary>
    public class TranslationExtended
    {
        [JsonPropertyName("nameTranslations")]
        public List<Translation>? NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Translation>? OverviewTranslations { get; set; }

        [JsonPropertyName("aliases")]
        public List<string>? Aliases { get; set; }
    }
}
