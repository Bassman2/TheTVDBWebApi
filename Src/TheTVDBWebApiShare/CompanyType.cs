namespace TheTVDBWebApi
{
    /// <summary>
    /// A company type record.
    /// </summary>
    public class CompanyType
    {
        [JsonPropertyName("companyTypeId")]
        public long Id { get; set; }

        [JsonPropertyName("companyTypeName")]
        public string Name { get; set; }
    }
}
