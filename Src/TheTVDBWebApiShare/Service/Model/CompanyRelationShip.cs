namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// A company relationship.
/// </summary>
public class CompanyRelationShip
{
    /// <summary>
    /// Id of the company relation ship.
    /// </summary>
    /// <remarks>Can be null if parent company does not exists.</remarks>
    [JsonPropertyName("id")]
    public long? Id { get; set; }

    /// <summary>
    /// Type name of the company relation ship.
    /// </summary>
    [JsonPropertyName("typeName")]
    public string? TypeName { get; set; }
}
