namespace TheTVDBWebApi
{
    /// <summary>
    /// Extended award record.
    /// </summary>
    public class AwardExtendedRecord : AwardBaseRecord
    {
        /// <summary>
        /// Categories of the award.
        /// </summary>
        [JsonPropertyName("categories")]
        public List<AwardCategoryBaseRecord> Categories { get; set; }
                
        /// <summary>
        /// Score of the award.
        /// </summary>
        [JsonPropertyName("score")]
        public long Score { get; set; }
    }
}
