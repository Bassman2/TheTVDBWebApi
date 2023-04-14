namespace TheTVDBWebApi
{
    /// <summary>
    /// Base record info.
    /// </summary>
    public class RecordInfo
    {
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("year")]
        public string Year { get; set; }

        public override string ToString()
        {
            return $"{Image}, {Name}, {Year}";
        }
    }
}
