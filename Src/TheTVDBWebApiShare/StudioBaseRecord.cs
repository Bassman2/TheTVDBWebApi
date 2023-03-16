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

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("parentStudio")]
        public int? ParentStudio { get; set; }
    }
}
