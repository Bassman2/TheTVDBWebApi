using TheTVDBWebApi;

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

                    List<string> nameLang = this.MovieBaseRecord.NameTranslations;
                    List<string> overLang = this.MovieBaseRecord.OverviewTranslations;
                    List<string> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.ToDictionary(l => l, l => client.GetMovieTranslationAsync(record.Id, l).Result);

                    //this.NameTranslations = nameLang.Select(l => Translations[l]).ToList();
                    //this.OverviewTranslations = overLang.Select(l => Translations[l]).ToList();
                }
            });
        }

        [ObservableProperty]
        private MovieBaseRecord movieListRecord;

        [ObservableProperty]
        private MovieBaseRecord movieBaseRecord;

        [ObservableProperty]
        private MovieExtendedRecord movieExtendedRecord;

        [ObservableProperty]
        private Dictionary<string, Translation> translations;

        //[ObservableProperty]
        //private List<Translation> nameTranslations;

        //[ObservableProperty]
        //private List<Translation> overviewTranslations;
    }
}
