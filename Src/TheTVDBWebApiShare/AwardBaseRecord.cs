namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Base award record.
    /// </summary>
    public class AwardBaseRecord
    {
        /// <summary>
        /// Id of the award.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the award.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
