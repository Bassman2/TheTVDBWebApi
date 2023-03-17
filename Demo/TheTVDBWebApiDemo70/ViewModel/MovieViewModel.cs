﻿namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MovieViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");
         
        public MovieViewModel(MovieBaseRecord movieBaseRecord)
        {
            this.MovieBaseRecord = movieBaseRecord;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.MovieExtendedRecord = await client.GetMovieExtendedAsync(movieBaseRecord.Id);
                }
            });
        }

        [ObservableProperty]
        private MovieBaseRecord movieBaseRecord;

        [ObservableProperty]
        private MovieExtendedRecord movieExtendedRecord;
    }
}
