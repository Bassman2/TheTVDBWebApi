namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Extended list record.
/// </summary>
public class ListExtendedRecord : ListBaseRecord
{
    
    [JsonPropertyName("entities")]
    public List<Entity>? Entities { get; set; }
}
