namespace TheTVDBWebApi
{
    /// <summary>
    /// Companies by type record.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Id of the company.
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }

        /// <summary>
        /// Name of the company.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        /// <summary>
        /// Translated names of the company.
        /// </summary>
        [JsonPropertyName("nameTranslations")]
        public List<Languages> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<Languages> OverviewTranslations { get; set; }

        /// <summary>
        /// An alias model, which can be associated with a series, season, movie, person, or list.
        /// </summary>
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        /// <summary>
        /// Country of the company
        /// </summary>
        [JsonPropertyName("country")]
        public Countries Country { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Can be null.</remarks>
        [JsonPropertyName("primaryCompanyType")]
        public long? PrimaryCompanyType { get; set; }

        [JsonPropertyName("activeDate")]
        public string ActiveDate { get; set; }

        [JsonPropertyName("inactiveDate")]
        public string InactiveDate { get; set; }

        [JsonPropertyName("companyType")]
        public CompanyType CompanyType { get; set; }

        [JsonPropertyName("parentCompany")]
        public ParentCompany ParentCompany { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }
    }
}
