namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended artwork record.
    /// </summary>
    public class ArtworkExtendedRecord
    {
        [JsonPropertyName("episodeId")]
        public int EpisodeId { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("movieId")]
        public int MovieId { get; set; }

        [JsonPropertyName("networkId")]
        public int NetworkId { get; set; }

        [JsonPropertyName("peopleId")]
        public int PeopleId { get; set; }

        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("seriesId")]
        public int SeriesId { get; set; }

        [JsonPropertyName("seriesPeopleId")]
        public int SeriesPeopleId { get; set; }

        [JsonPropertyName("status")]
        public ArtworkStatus Status { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("thumbnailHeight")]
        public long ThumbnailHeight { get; set; }

        [JsonPropertyName("thumbnailWidth")]
        public long ThumbnailWidth { get; set; }

        /// <summary>
        /// Type of the artwork.
        /// </summary>
        /// <remarks>The artwork type corresponds to the ids from the /artwork/types endpoint.</remarks>
        [JsonPropertyName("type")]
        public long Type { get; set; }

        [JsonPropertyName("updatedAt")]
        public long UpdatedAt { get; set; }

        [JsonPropertyName("width")]
        public long Width { get; set; }
    }
}
