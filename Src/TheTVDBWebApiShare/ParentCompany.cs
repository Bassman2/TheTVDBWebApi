namespace TheTVDBWebApiShare
{
    /// <summary>
    /// A parent company recor.
    /// </summary>
    public class ParentCompany
    {
        /// <summary>
        /// Id of the parent company.
        /// </summary>
        /// <remarks>Can be null if no parent company exists.</remarks>
        [JsonPropertyName("id")]
        public long? Id { get; set; }

        /// <summary>
        /// Name of the parent company.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Relationship of the parent company.
        /// </summary>
        [JsonPropertyName("relation")]
        public CompanyRelationShip Relation { get; set; }
    }
}
