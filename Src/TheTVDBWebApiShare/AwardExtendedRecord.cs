namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended award record.
    /// </summary>
    public class AwardExtendedRecord
    {
        [JsonPropertyName("categories")]
        public List<AwardCategoryBaseRecord> categories { get; set; }

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

        [JsonPropertyName("score")]
        public long Score { get; set; }
    }
}
