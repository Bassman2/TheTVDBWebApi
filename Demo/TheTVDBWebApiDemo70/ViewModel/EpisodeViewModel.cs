namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class EpisodeViewModel : ObservableObject
    {
        public EpisodeViewModel(EpisodeBaseRecord record)
        {
            this.EpisodeListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.EpisodeBaseRecord = await client.GetEpisodeAsync(record.Id);
                    this.EpisodeExtendedRecord = await client.GetEpisodeExtendedAsync(record.Id, Meta.Translations);

                    List<Languages> nameLang = this.EpisodeBaseRecord.NameTranslations;
                    List<Languages> overLang = this.EpisodeBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.Select(l => client.GetEpisodeTranslationAsync(record.Id, l).Result).ToList();
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
        private List<Translation> translations;
    }
}
