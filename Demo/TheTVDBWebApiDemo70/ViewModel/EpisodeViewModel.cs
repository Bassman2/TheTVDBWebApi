namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class EpisodeViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public EpisodeViewModel(EpisodeBaseRecord record)
        {
            this.EpisodeListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.EpisodeBaseRecord = await client.GetEpisodeAsync(record.Id);
                    this.EpisodeExtendedRecord = await client.GetEpisodeExtendedAsync(record.Id, Meta.Translations);
                    this.Translations = this.EpisodeBaseRecord.NameTranslations.Concat(this.EpisodeBaseRecord.OverviewTranslations).Distinct().ToDictionary(l => l, l => client.GetMovieTranslationAsync(record.Id, l).Result);

                }
            });
        }

        [ObservableProperty]
        private EpisodeBaseRecord episodeListRecord;

        [ObservableProperty]
        private EpisodeBaseRecord episodeBaseRecord;

        [ObservableProperty]
        private EpisodeExtendedRecord episodeExtendedRecord;

        [ObservableProperty]
        private Dictionary<string, Translation> translations;

    }
}
