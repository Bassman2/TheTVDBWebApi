namespace TheTVDBWebApi;

/// <summary>
/// Tag option record.
/// </summary>
public class TagOption
{
    internal TagOption(TagOptionModel model)
    {
        Id = model.Id;
        Tag = model.Tag;
        TagName = model.TagName;
        Name = model.Name;
        HelpText = model.HelpText;
    }

    public long Id { get; set; }       

    public long Tag { get; set; }

    public string? TagName { get; set; }

    public string? Name { get; set; }

    public string? HelpText { get; set; }
}
