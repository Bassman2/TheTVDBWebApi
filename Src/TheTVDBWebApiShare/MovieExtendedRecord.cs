namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended movie record.
    /// </summary>
    public class MovieExtendedRecord
    {
        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        /// <summary>
        /// Base artwork record.
        /// </summary>
        [JsonPropertyName("artworks")]
        public List<ArtworkBaseRecord> Artworks { get; set; }

        [JsonPropertyName("audioLanguages")]
        public List<string> AudioLanguages { get; set; }

        [JsonPropertyName("awards")]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonPropertyName("boxOffice")]
        public string BoxOffice { get; set; }

        [JsonPropertyName("boxOfficeUS")]
        public string BoxOfficeUS { get; set; }

        [JsonPropertyName("budget")]
        public string Budget { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }

        [JsonPropertyName("companies")]
        public Companies Companies { get; set; }

        [JsonPropertyName("contentRatings")]
        public List<ContentRating> contentRatings { get; set; }

        [JsonPropertyName("first_release")]
        public Release FirstRelease { get; set; }

        [JsonPropertyName("genres")]
        public List<GenreBaseRecord> Genres { get; set; }

        /// <summary>
        /// Id of the movie.
        /// </summary>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Uri of a movie image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("inspirations")]
        public List<Inspiration> Inspirations { get; set; }

        /// <summary>
        /// Last updated date.
        /// </summary>
        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        [JsonPropertyName("lists")]
        public List<ListBaseRecord> Lists { get; set; }

        /// <summary>
        /// Name of the movie.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("originalCountry")]
        public string OriginalCountry { get; set; }

        [JsonPropertyName("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonPropertyName("releases")]
        public List<Release> Releases { get; set; }

        [JsonPropertyName("remoteIds")]
        public List<RemoteID> RemoteIds { get; set; }

        /// <summary>
        /// Runtime of the movie.
        /// </summary>
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        /// <summary>
        /// Score of the movie.
        /// </summary>
        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<string> SpokenLanguages { get; set; }

        /// <summary>
        /// Status of the movie
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("studios")]
        public List<StudioBaseRecord> Studios { get; set; }

        [JsonPropertyName("subtitleLanguages")]
        public List<string> SubtitleLanguages { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonPropertyName("translations")]
        public List<TranslationExtended> Translations { get; set; }

        /// <summary>
        /// Year of the movie.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}

