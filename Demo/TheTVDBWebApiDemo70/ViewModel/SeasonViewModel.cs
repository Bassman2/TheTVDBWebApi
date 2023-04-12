namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class SeasonViewModel : ObservableObject
    {
        public SeasonViewModel(SeasonBaseRecord record)
        {
            this.SeasonListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.SeasonBaseRecord = await client.GetSeasonAsync(record.Id);
                    this.SeasonExtendedRecord = await client.GetSeasonExtendedAsync(record.Id);

                    List<Languages> nameLang = this.SeasonBaseRecord.NameTranslations;
                    List<Languages> overLang = this.SeasonBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.Select(l => client.GetSeasonTranslationAsync(record.Id, l).Result).ToList();
                }
            });
        }

        [ObservableProperty]
        private SeasonBaseRecord seasonListRecord;

        [ObservableProperty]
        private SeasonBaseRecord seasonBaseRecord;

        [ObservableProperty]
        private SeasonExtendedRecord seasonExtendedRecord;

        [ObservableProperty]
        private List<Translation> translations;
    }
}
