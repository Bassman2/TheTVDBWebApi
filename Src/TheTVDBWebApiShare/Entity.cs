namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Entity record.
    /// </summary>
    public class Entity
    {
        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("order")]
        public long Order { get; set; }

        [JsonPropertyName("seriesId")]
        public int SeriesId { get; set; }
    }
}
