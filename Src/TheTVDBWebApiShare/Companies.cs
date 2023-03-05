namespace TheTVDBWebApiShare
{
    /// <summary>
    /// Companies by type record.
    /// </summary>
    internal class Companies
    {
        /// <summary>
        /// Studio company.
        /// </summary>
        [JsonPropertyName("studio")]
        public Company Studio { get; set; }

        /// <summary>
        /// Network company.
        /// </summary>
        [JsonPropertyName("network")]
        public Company Network { get; set; }

        /// <summary>
        /// Production company.
        /// </summary>
        [JsonPropertyName("production")]
        public Company Production { get; set; }

        /// <summary>
        /// Distributor company.
        /// </summary>
        [JsonPropertyName("distributor")]
        public Company Distributor { get; set; }

        /// <summary>
        /// Special effects company.
        /// </summary>
        [JsonPropertyName("special_effects")]
        public Company SpecialEffects { get; set; }

    }
}
