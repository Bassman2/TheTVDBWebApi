namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Entity record.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("movieId")]
        public int? MovieId { get; set; }

        [JsonPropertyName("order")]
        public long Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("seriesId")]
        public int? SeriesId { get; set; }
    }
}
