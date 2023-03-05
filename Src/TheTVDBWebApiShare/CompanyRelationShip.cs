namespace TheTVDBWebApiShare
{
    /// <summary>
    /// A company relationship.
    /// </summary>
    public class CompanyRelationShip
    {
        /// <summary>
        /// Id of the company relation ship.
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        /// <summary>
        /// Type name of the company relation ship.
        /// </summary>
        [JsonPropertyName("typeName")]
        public string TypeName { get; set; }
    }
}
