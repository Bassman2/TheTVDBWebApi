namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Translation simple record.
    /// </summary>
    public class TranslationSimple
    {
        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
