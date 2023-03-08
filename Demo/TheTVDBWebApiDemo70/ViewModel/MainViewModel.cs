namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MainViewModel : AppViewModel
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public override void OnStartup()
        {
            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(apiKey, userKey))
                {
                    this.Countries = await client.GetCountriesAsync();
                    this.ArtworkStatuses = await client.GetArtworkStatusesAsync();
                    this.MovieStatuses = await client.GetMovieStatusesAsync();
                    this.PeopleTypes = await client.GetPeopleTypesAsync();
                    this.SeriesStatuses = await client.GetSeriesStatusesAsync();

                    this.UserInfo = await client.GetUserInfoAsync();
                }
            });
        }

        [ObservableProperty]
        private List<Country> countries;

        [ObservableProperty]
        private List<ArtworkStatus> artworkStatuses;

        [ObservableProperty]
        private List<Status> movieStatuses;

        [ObservableProperty]
        private List<PeopleType> peopleTypes;

        [ObservableProperty]
        private List<Status> seriesStatuses;

        [ObservableProperty]
        private UserInfo userInfo;
    }
}
