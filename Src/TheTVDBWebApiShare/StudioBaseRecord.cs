namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Studio record.
    /// </summary>
    public class StudioBaseRecord
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("parentStudio")]
        public int ParentStudio { get; set; }
    }
}
