using TheTVDBWebApi;

namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class MovieViewModel : ObservableObject
    {
        public MovieViewModel(MovieBaseRecord record)
        {
            this.MovieListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.MovieBaseRecord = await client.GetMovieAsync(record.Id);
                    this.MovieExtendedRecord = await client.GetMovieExtendedAsync(record.Id, Meta.Translations, false);

                    List<Languages> nameLang = this.MovieBaseRecord.NameTranslations;
                    List<Languages> overLang = this.MovieBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.Select(l => client.GetMovieTranslationAsync(record.Id, l).Result).ToList();
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
        private List<Translation> translations;
    }
}
