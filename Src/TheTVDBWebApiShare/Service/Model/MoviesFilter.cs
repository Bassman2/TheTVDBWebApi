namespace TheTVDBWebApi.Service.Model;


/// <summary>
/// Movies filter class.
/// </summary>
public class MoviesFilter
{
    /// <summary>
    /// Id of the production company.
    /// </summary>
    public int? Company { get; set; } = null;

    /// <summary>
    /// Content rating id base on a country.
    /// </summary>
    public int? ContentRating { get; set; } = null;

    /// <summary>
    /// Country of origin. 
    /// </summary>
    /// <example>usa</example>
    public Countries Country { get; set; }

    /// <summary>
    /// Id of the genre.
    /// </summary>
    public int? Genre { get; set; } = null;

    /// <summary>
    /// Original language.
    /// </summary>
    /// <example>eng</example>
    public Languages Language { get; set; }

    /// <summary>
    /// Sort by result.
    /// </summary>
    /// <value>score, firstAired, name</value>
    public string? Sort { get; set; } = null;

    /// <summary>
    /// Id of status.
    /// </summary>
    public int? Status { get; set; } = null;

    /// <summary>
    /// Release year.
    /// </summary>
    public int? Year { get; set; } = null;

    internal string Parameter
    {
        get
        {
            //if (string.IsNullOrEmpty(this.Language))
            //{
            //    throw new ArgumentNullException(nameof(Language));
            //}
            //if (string.IsNullOrEmpty(this.Country))
            //{
            //    throw new ArgumentNullException(nameof(Country));
            //}
            var sb = new StringBuilder();
            if (this.Company != null)
            {
                sb.Append($"&company={this.Company}");
            }
            if (this.ContentRating != null)
            {
                sb.Append($"&contentRating={this.ContentRating}");
            }
            //if (this.Country != null)
            {
                sb.Append($"&country={this.Country.Value()}");
            }
            if (this.Genre != null)
            {
                sb.Append($"&genre={this.Genre}");
            }
            //if (this.Language != null)
            {
                sb.Append($"&lang={this.Language.Value()}");
            }
            if (this.Sort != null)
            {
                sb.Append($"&sort={this.Sort}");
            }
            if (this.Status != null)
            {
                sb.Append($"&status={this.Status}");
            }
            if (this.Year != null)
            {
                sb.Append($"&year={this.Year}");
            }
            return sb.ToString().TrimStart('&');
        }
    }
}
