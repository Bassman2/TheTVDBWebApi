using System.Collections.ObjectModel;
using TheTVDBWebApi;

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

                //this.ArtworkStatuses = await client.GetArtworkStatusesAsync();
                //this.ArtworkTypes = await client.GetArtworkTypesAsync();
                //this.Awards = await client.GetAwardsAsync();
                ////this.Companies = await client.GetCompaniesAsync();  
                //this.CompanyTypes = await client.GetCompanyTypesAsync();
                //this.ContentRatings = await client.GetContentRatingsAsync();
                //this.Countries = await client.GetCountriesAsync();
                //this.Entities = await client.GetEntitiesAsync();
                //this.Genders = await client.GetGendersAsync();
                //this.Genres = await client.GetGenresAsync();
                //this.InspirationTypes = await client.GetInspirationTypesAsync();
                //this.Languages = await client.GetLanguagesAsync();
                //this.MovieStatuses = await client.GetMovieStatusesAsync();
                //this.PeopleTypes = await client.GetPeopleTypesAsync();
                //this.SeasonTypes = await client.GetSeasonTypesAsync();
                //this.SeriesStatuses = await client.GetSeriesStatusesAsync();
                //this.SourceTypes = await client.GetSourceTypesAsync();
                //this.UserInfo = await client.GetUserInfoAsync();
                ////this.UserFavorites = await client.GetUserFavoritesAsync();

                await Task.WhenAll(
                    client.GetArtworkStatusesAsync().ContinueWith(items => this.ArtworkStatuses = items.Result),
                    client.GetArtworkTypesAsync().ContinueWith(items => this.ArtworkTypes = items.Result),
                    client.GetAwardsAsync().ContinueWith(items => this.Awards = items.Result),
                    client.GetCompaniesAsync().ContinueWith(items => this.Companies = items.Result),
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
                    client.GetEpisodesAsync().ForEachAsync(item => this.Episodes.Add(item)),
                    client.GetListsAsync().ForEachAsync(item => this.Lists.Add(item)),
                    client.GetMoviesAsync().ForEachAsync(item => this.Movies.Add(item)),
                    client.GetPeopleAsync().ForEachAsync(item => this.People.Add(item)),
                    client.GetSeasonsAsync().ForEachAsync(item => this.Seasons.Add(item)),
                    client.GetSeriesAsync().ForEachAsync(item => this.Series.Add(item)));
                



                //var episodes = client.GetEpisodesAsync();
                //await foreach (var item in episodes)
                //{
                //    this.Episodes.Add(item);
                //}

                //var lists = client.GetListsAsync();
                //await foreach (var item in lists)
                //{
                //    this.Lists.Add(item);
                //}

                //await Task.WhenAll(
                //await foreach (var item in movies)
                //{
                //    this.Movies.Add(item);
                //}

                //var people = client.GetPeopleAsync();
                //await foreach (var item in people)
                //{
                //    this.People.Add(item);
                //}

                //var seasons = client.GetSeasonsAsync();
                //await foreach (var item in seasons)
                //{
                //    this.Seasons.Add(item);
                //}

                //var series = client.GetSeriesAsync();
                //await foreach (var item in series)
                //{
                //    this.Series.Add(item);
                //}
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
        private Favorites userFavorites;

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
