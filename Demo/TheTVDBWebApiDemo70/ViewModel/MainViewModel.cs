using System.Collections.ObjectModel;
using TheTVDBWebApiShare;

namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MainViewModel : AppViewModel
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public override async Task OnStartup()
        {
            Debug.WriteLine("++MainViewModel.OnStartup");

            using (var client = new TVDBWeb())
            {
                await client.LoginAsync(apiKey, userKey);

                this.ArtworkStatuses = await client.GetArtworkStatusesAsync();
                this.ArtworkTypes = await client.GetArtworkTypesAsync();
                this.Awards = await client.GetAwardsAsync();
                this.Companies = await client.GetCompaniesAsync();  
                this.CompanyTypes = await client.GetCompanyTypesAsync();
                this.ContentRatings = await client.GetContentRatingsAsync();
                this.Countries = await client.GetCountriesAsync();
                this.Entities = await client.GetEntitiesAsync();
                this.Genders = await client.GetGendersAsync();
                this.Genres = await client.GetGenresAsync();
                this.InspirationTypes = await client.GetInspirationTypesAsync();
                this.Languages = await client.GetLanguagesAsync();
                this.MovieStatuses = await client.GetMovieStatusesAsync();
                this.PeopleTypes = await client.GetPeopleTypesAsync();
                this.SeasonTypes = await client.GetSeasonTypesAsync();
                this.SeriesStatuses = await client.GetSeriesStatusesAsync();
                this.SourceTypes = await client.GetSourceTypesAsync();
                this.UserInfo = await client.GetUserInfoAsync();
                this.UserFavorites = await client.GetUserFavoritesAsync();

                var episodes = client.GetEpisodesAsync();
                await foreach (var item in episodes)
                {
                    this.Episodes.Add(item);
                }

                var lists = client.GetListsAsync();
                await foreach (var item in lists)
                {
                    this.Lists.Add(item);
                }

                var movies = client.GetMoviesAsync();
                await foreach (var item in movies)
                {
                    this.Movies.Add(item);
                }

                var people = client.GetPeopleAsync();
                await foreach (var item in people)
                {
                    this.People.Add(item);
                }

                var seasons = client.GetSeasonsAsync();
                await foreach (var item in seasons)
                {
                    this.Seasons.Add(item);
                }

                var series = client.GetSeriesAsync();
                await foreach (var item in series)
                {
                    this.Series.Add(item);
                }
            }

            Debug.WriteLine("--MainViewModel.OnStartup");
        }

        [ObservableProperty]
        private List<ArtworkStatus> artworkStatuses;

        [ObservableProperty]
        private List<ArtworkType> artworkTypes;

        [ObservableProperty]
        private List<AwardBaseRecord> awards;

        [ObservableProperty]
        private List<Company> companies;

        [ObservableProperty]
        private List<CompanyType> companyTypes;

        [ObservableProperty]
        private List<ContentRating> contentRatings;

        [ObservableProperty]
        private List<Country> countries;

        [ObservableProperty]
        private List<EntityType> entities;
        
        [ObservableProperty]
        private List<Gender> genders;

        [ObservableProperty]
        private List<GenreBaseRecord> genres;

        [ObservableProperty]
        private List<InspirationType> inspirationTypes;

        [ObservableProperty]
        private List<Language> languages;

        [ObservableProperty]
        private List<Status> movieStatuses;

        [ObservableProperty]
        private List<PeopleType> peopleTypes;

        [ObservableProperty]
        private List<SeasonType> seasonTypes;

        [ObservableProperty]
        private List<Status> seriesStatuses;

        [ObservableProperty]
        private List<SourceType> sourceTypes;
        
        [ObservableProperty]
        private UserInfo userInfo;

        [ObservableProperty]
        private List<Favorites> userFavorites;

        [ObservableProperty]
        private ObservableCollection<EpisodeBaseRecord> episodes = new ObservableCollection<EpisodeBaseRecord>();

        [ObservableProperty]
        private ObservableCollection<ListBaseRecord> lists = new ObservableCollection<ListBaseRecord>();

        [ObservableProperty]
        private ObservableCollection<MovieBaseRecord> movies = new ObservableCollection<MovieBaseRecord>();

        [ObservableProperty]
        private ObservableCollection<PeopleBaseRecord> people = new ObservableCollection<PeopleBaseRecord>();

        [ObservableProperty]
        private ObservableCollection<SeasonBaseRecord> seasons = new ObservableCollection<SeasonBaseRecord>();

        [ObservableProperty]
        private ObservableCollection<SeriesBaseRecord> series = new ObservableCollection<SeriesBaseRecord>();
    }
}
