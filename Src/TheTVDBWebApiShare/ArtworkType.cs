namespace TheTVDBWebApi;

/// <summary>
/// Artwork type record.
/// </summary>
public class ArtworkType
{
    internal ArtworkType(ArtworkTypeModel model) 
    {
        Id = model.Id;
        Name = model.Name;
        RecordType = model.RecordType;
        Slug = model.Slug;
        ImageFormat = model.ImageFormat;
        Width = model.Width;
        Height = model.Height;
        ThumbWidth = model.ThumbWidth;
        ThumbHeight = model.ThumbHeight;
    }

    /// <summary>
    /// Identifier of the artwork type.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Name of the artwork type.
    /// </summary>
    public string? Name { get; }

    public RecordType RecordType { get; }

    public string? Slug { get; }

    public string? ImageFormat { get; }

    public long Width { get; }

    public long Height { get; }

    public long ThumbWidth { get; }

    public long ThumbHeight { get; }
}
