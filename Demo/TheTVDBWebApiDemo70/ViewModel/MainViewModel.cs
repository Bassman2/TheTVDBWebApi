using System.Collections.ObjectModel;
using TheTVDBWebApi;

namespace TheTVDBWebApiDemo.ViewModel
{
    public sealed partial class MainViewModel : AppViewModel, IDisposable
    {
        public static TVDBWebTokenContainer TokenContainer { get; set; }

        private TVDBWeb client;
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public MainViewModel()
        {
            TokenContainer = new TVDBWebTokenContainer();
            this.client = new TVDBWeb(TokenContainer);
            Task.Run(async () =>
            {
                await client.LoginAsync(apiKey, userKey);
            });
        }

        public void Dispose()
        {
            if (this.client != null) 
            {
                this.client.Dispose();
                this.client = null;
            }
        }

        public override async Task OnStartup()
        {
            Debug.WriteLine("++MainViewModel.OnStartup");

            await Task.WhenAll(
                client.GetArtworkStatusesAsync().ContinueWith(items => this.ArtworkStatuses = items.Result),
                client.GetArtworkTypesAsync().ContinueWith(items => this.ArtworkTypes = items.Result),
                client.GetAwardsAsync().ContinueWith(items => this.Awards = items.Result),
                client.GetCompanyTypesAsync().ContinueWith(items => this.CompanyTypes = items.Result),
                client.GetContentRatingsAsync().ContinueWith(items => this.ContentRatings = items.Result),
                client.GetCountriesAsync().ContinueWith(items => this.Countries = items.Result),
                client.GetEntitiesAsync().ContinueWith(items => this.Entities = items.Result),
                client.GetGendersAsync().ContinueWith(items => this.Genders = items.Result),
                client.GetGenresAsync().ContinueWith(items => this.Genres = items.Result),
                client.GetInspirationTypesAsync().ContinueWith(items => this.InspirationTypes = items.Result),
                client.GetLanguagesAsync().ContinueWith(items => this.Languages = items.Result),
                client.GetMovieStatusesAsync().ContinueWith(items => this.MovieStatuses = items.Result),
                client.GetPeopleTypesAsync().ContinueWith(items => this.PeopleTypes = items.Result),
                client.GetSeasonTypesAsync().ContinueWith(items => this.SeasonTypes = items.Result),
                client.GetSeriesStatusesAsync().ContinueWith(items => this.SeriesStatuses = items.Result),
                client.GetSourceTypesAsync().ContinueWith(items => this.SourceTypes = items.Result),
                client.GetUserInfoAsync().ContinueWith(item => this.UserInfo = item.Result),
                client.GetUserFavoritesAsync().ContinueWith(items => this.UserFavorites = items.Result),

                client.GetCompaniesAsync().ForEachAsync(item => this.Companies.Add(item)),
                client.GetEpisodesAsync().ForEachAsync(item => this.Episodes.Add(item)),
                client.GetListsAsync().ForEachAsync(item => this.Lists.Add(item)),
                client.GetMoviesAsync().ForEachAsync(item => this.Movies.Add(item)),
                client.GetPeopleAsync().ForEachAsync(item => this.People.Add(item)),
                client.GetSeasonsAsync().ForEachAsync(item => this.Seasons.Add(item)),
                client.GetSeriesAsync().ForEachAsync(item => this.Series.Add(item)));

            Debug.WriteLine("--MainViewModel.OnStartup");
        }        

        [ObservableProperty]
        private List<ArtworkStatus> artworkStatuses;

        [ObservableProperty]
        private List<ArtworkType> artworkTypes;

        [ObservableProperty]
        private List<AwardBaseRecord> awards;

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
        private Favorites userFavorites;

        [ObservableProperty]
        private ObservableCollection<Company> companies = new ObservableCollection<Company>();

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
