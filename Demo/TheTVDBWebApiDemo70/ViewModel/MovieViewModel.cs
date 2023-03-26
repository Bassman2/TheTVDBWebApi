namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MovieViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");
         
        public MovieViewModel(MovieBaseRecord record)
        {
            this.MovieListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.MovieBaseRecord = await client.GetMovieAsync(record.Id);
                    this.MovieExtendedRecord = await client.GetMovieExtendedAsync(record.Id, Meta.Translations, false);
                }
            });
        }

        [ObservableProperty]
        private MovieBaseRecord movieListRecord;

        [ObservableProperty]
        private MovieBaseRecord movieBaseRecord;

        [ObservableProperty]
        private MovieExtendedRecord movieExtendedRecord;
    }
}
