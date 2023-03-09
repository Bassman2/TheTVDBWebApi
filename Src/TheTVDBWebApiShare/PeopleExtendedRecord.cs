namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Extended people record.
    /// </summary>
    public class PeopleExtendedRecord
    {
        [JsonPropertyName("aliases")]
        public List<Alias> Aliases { get; set; }

        [JsonPropertyName("awards")]
        public List<AwardBaseRecord> Awards { get; set; }

        [JsonPropertyName("biographies")]
        public List<Biography> Biographies { get; set; }

        [JsonPropertyName("birth")]
        public string Birth { get; set; }

        [JsonPropertyName("birthPlace")]
        public string BirthPlace { get; set; }

        [JsonPropertyName("characters")]
        public List<Character> Characters { get; set; }

        [JsonPropertyName("death")]
        public string Death { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("lastUpdated")]
        public string LastUpdated { get; set; }

        /// <summary>
        /// Name of the artwork status.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nameTranslations")]
        public List<string> NameTranslations { get; set; }

        [JsonPropertyName("overviewTranslations")]
        public List<string> OverviewTranslations { get; set; }

        [JsonPropertyName("races")]
        public List<Race> Races { get; set; }

        [JsonPropertyName("remoteIds")]
        public List<RemoteID> RemoteIds { get; set; }
        
        [JsonPropertyName("score")]
        public long Score { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("tagOptions")]
        public List<TagOption> TagOptions { get; set; }

        [JsonPropertyName("translations")]
        public TranslationExtended translations { get; set; }
    }
}

