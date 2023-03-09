namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Base award category record:
    /// </summary>
    public class AwardCategoryBaseRecord
    {
        [JsonPropertyName("allowCoNominees")]
        public bool AllowCoNominees { get; set; }

        [JsonPropertyName("award")]
        public AwardBaseRecord Award { get; set; }

        [JsonPropertyName("forMovies")]
        public bool ForMovies { get; set; }

        [JsonPropertyName("forSeries")]
        public bool ForSeries { get; set; }

        /// <summary>
        /// Id of the award category.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the award category.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
