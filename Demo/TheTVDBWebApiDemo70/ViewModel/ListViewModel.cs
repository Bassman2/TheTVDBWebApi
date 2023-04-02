namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class ListViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public ListViewModel(ListBaseRecord record)
        {
            this.ListListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.ListBaseRecord = await client.GetListAsync(record.Id);
                    this.ListExtendedRecord = await client.GetListExtendedAsync(record.Id);
                    this.Translations = this.ListBaseRecord.NameTranslations.Concat(this.ListBaseRecord.OverviewTranslations).Distinct().ToDictionary(l => l, l => client.GetMovieTranslationAsync(record.Id, l).Result);
                }
            });
        }

        [ObservableProperty]
        private ListBaseRecord listListRecord;

        [ObservableProperty]
        private ListBaseRecord listBaseRecord;

        [ObservableProperty]
        private ListExtendedRecord listExtendedRecord;

        [ObservableProperty]
        private Dictionary<string, Translation> translations;

    }
}
