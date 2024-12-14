namespace TheTVDBWebApi
{
    /// <summary>
    /// People type record.
    /// </summary>
    public class PeopleType
    {
        /// <summary>
        /// Id of the people type record.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the people type record.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
