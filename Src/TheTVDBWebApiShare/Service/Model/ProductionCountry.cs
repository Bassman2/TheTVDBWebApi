namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Production country record.
/// </summary>
public class ProductionCountry
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("country")]
    public Countries Country { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
