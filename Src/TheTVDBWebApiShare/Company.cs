namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Companies by type record.
    /// </summary>
    public class Company
    {
        [JsonPropertyName("activeDate")]
        public string ActiveDate { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        /// <summary>
        /// Country of the company
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }

        /// <summary>
        /// Id of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("inactiveDate")]
        public string InactiveDate { get; set; }

        /// <summary>
        /// Name of the company.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Translated names of the company.
        /// </summary>
        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("primaryCompanyType")]
        public long? PrimaryCompanyType { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("parentCompany")]
        public ParentCompany ParentCompany { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }
    }
}
