namespace TheTVDBWebApi
{
    /// <summary>
    /// Search result
    /// </summary>
    public class SearchResult
    {
        [JsonPropertyName("aliases")]
        public List<Alias>? Aliases { get; set; }

        [JsonPropertyName("companies")]
        public Companies? Companies { get; set; }

        [JsonPropertyName("companyType")]
        public string? CompanyType { get; set; }

        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("director")]
        public string? Director { get; set; }

        [JsonPropertyName("first_air_time")]
        public string? FirstAirTime { get; set; }

        [JsonPropertyName("genres")]
        public List<string>? Genres { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("is_official")]
        public bool IsOfficial { get; set; }

        [JsonPropertyName("name_translated")]
        public string? NameTranslated { get; set; }

        [JsonPropertyName("network")]
        public string? Network { get; set; }

        [JsonPropertyName("objectID")]
        public string? ObjectID { get; set; }

        [JsonPropertyName("officialList")]
        public string? OfficialList { get; set; }

        [JsonPropertyName("overview")]
        public string? Overview { get; set; }

        [JsonPropertyName("overviews")]
        public TranslationSimple? Overviews { get; set; }

        [JsonPropertyName("overview_translated")]
        public List<string>? OverviewTranslated { get; set; }

        [JsonPropertyName("poster")]
        public string? Poster { get; set; }

        [JsonPropertyName("posters")]
        public List<string>? Posters { get; set; }

        [JsonPropertyName("primary_language")]
        public string? PrimaryLanguage { get; set; }

        [JsonPropertyName("remote_ids")]
        public List<RemoteID>? RemoteIds { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        [JsonPropertyName("studios")]
        public List<string>? Studios { get; set; }

        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }

        [JsonPropertyName("translations")]
        public TranslationSimple? Translations { get; set; }

        [JsonPropertyName("translationsWithLang")]
        public List<string>? TranslationsWithLang { get; set; }

        [JsonPropertyName("tvdb_id")]
        public string? TVDBId { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("year")]
        public string? Year { get; set; }
    }
}
