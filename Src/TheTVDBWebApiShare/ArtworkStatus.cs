namespace TheTVDBWebApi;

/// <summary>
/// artwork status record
/// </summary>
public class ArtworkStatus
{
    internal ArtworkStatus(ArtworkStatusModel model)
    {
        Id = model.Id;
        Name = model.Name;
    }

    /// <summary>
    /// Identifier of the artwork status.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Name of the artwork status.
    /// </summary>
    public string? Name { get; }
}
