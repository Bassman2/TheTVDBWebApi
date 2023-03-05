namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Tag option record.
    /// </summary>
    public class TagOption
    {
        [JsonPropertyName("helpText")]
        public string HelpText { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("tag")]
        public long Tag { get; set; }

        [JsonPropertyName("tagName")]
        public string TagName { get; set; }
    }
}
