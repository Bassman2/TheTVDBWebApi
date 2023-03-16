namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Companies by type record.
    /// </summary>
    public class Companies
    {
        /// <summary>
        /// Studio company.
        /// </summary>
        [JsonPropertyName("studio")]
        public List<Company> Studio { get; set; }

        /// <summary>
        /// Network company.
        /// </summary>
        [JsonPropertyName("network")]
        public List<Company> Network { get; set; }

        /// <summary>
        /// Production company.
        /// </summary>
        [JsonPropertyName("production")]
        public List<Company> Production { get; set; }

        /// <summary>
        /// Distributor company.
        /// </summary>
        [JsonPropertyName("distributor")]
        public List<Company> Distributor { get; set; }

        /// <summary>
        /// Special effects company.
        /// </summary>
        [JsonPropertyName("special_effects")]
        public List<Company> SpecialEffects { get; set; }

    }
}
