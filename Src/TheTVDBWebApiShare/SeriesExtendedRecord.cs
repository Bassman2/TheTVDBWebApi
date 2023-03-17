namespace TheTVDBWebApiShare
{
    /// <summary>
    /// The extended record for a series. 
    /// </summary>
    /// <Remark>All series airs time like firstAired, lastAired, nextAired, etc. are in US EST for US series, and for all non-US series, the time of the show’s country capital or most populous city. For streaming services, is the official release time. See https://support.thetvdb.com/kb/faq.php?id=29.</Remark>
    public class SeriesExtendedRecord
    {
        [JsonPropertyName("abbreviation")]
        public string Abbreviation { get; set; }

        [JsonPropertyName("airsDays")]
        public SeriesAirsDays AirsDays { get; set; }

        [JsonPropertyName("airsTime")]
        public string AirsTime { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("artworks")]
        public List<ArtworkExtendedRecord> Artworks { get; set; }

        /// <summary>
        /// Average runtime of the serie.
        /// </summary>
        [JsonPropertyName("averageRuntime")]
        public int AverageRuntime { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }

        [JsonPropertyName("contentRatings")]
        public List<ContentRating> ContentRatings { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("defaultSeasonType")]
        public long DefaultSeasonType { get; set; }

        [JsonPropertyName("episodes")]
        public List<EpisodeBaseRecord> Episodes { get; set; }

        [JsonPropertyName("firstAired")]
        public string FirstAired { get; set; }

        [JsonPropertyName("lists")]
        public List<object> Lists { get; set; }

        [JsonPropertyName("genres")]
        public List<GenreBaseRecord> Genres { get; set; }

        /// <summary>
        /// Id of the serie.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Uri of a serie image.
        /// </summary>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("isOrderRandomized")]
        public bool IsOrderRandomized { get; set; }

        [JsonPropertyName("lastAired")]
        public string LastAired { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Name of the serie.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("companies")]
        public List<Company> Companies { get; set; }

        [JsonPropertyName("nextAired")]
        public string NextAired { get; set; }

        [JsonPropertyName("originalCountry")]
        public string OriginalCountry { get; set; }

        [JsonPropertyName("originalLanguage")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("originalNetwork")]
        public Company originalNetwork { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("latestNetwork")]
        public Company LatestNetwork { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("remoteIds")]
        public List<RemoteID> RemoteIds { get; set; }

        /// <summary>
        /// Score of the serie.
        /// </summary>
        [JsonPropertyName("score")]
        public double Score { get; set; }

        [JsonPropertyName("seasons")]
        public List<SeasonBaseRecord> Seasons { get; set; }

        [JsonPropertyName("seasonTypes")]
        public List<SeasonType> SeasonTypes { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Status of the serie.
        /// </summary>
        [JsonPropertyName("status")]
        public Status Status { get; set; }

        [JsonPropertyName("tags")]
        public List<TagOption> Tags { get; set; }

        [JsonPropertyName("trailers")]
        public List<Trailer> Trailers { get; set; }

        [JsonPropertyName("translations")]
        public List<TranslationExtended> Translations { get; set; }

        /// <summary>
        /// Year of the serie.
        /// </summary>
        [JsonPropertyName("year")]
        public string Year { get; set; }
    }
}
