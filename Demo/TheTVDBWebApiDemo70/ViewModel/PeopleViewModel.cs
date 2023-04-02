namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class PeopleViewModel : ObservableObject
    {
        private string apiKey => Environment.GetEnvironmentVariable("API_KEY");
        private string userKey => null; // Environment.GetEnvironmentVariable("USER_KEY");

        public PeopleViewModel(PeopleBaseRecord record)
        {
            this.PeopleListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb())
                {
                    await client.LoginAsync(apiKey, userKey);
                    this.PeopleBaseRecord = await client.GetPeopleAsync(record.Id);
                    this.PeopleExtendedRecord = await client.GetPeopleExtendedAsync(record.Id, Meta.Translations);
                    this.Translations = this.PeopleBaseRecord.NameTranslations.Concat(this.PeopleBaseRecord.OverviewTranslations).Distinct().ToDictionary(l => l, l => client.GetMovieTranslationAsync(record.Id, l).Result);
                }
            });
        }

        [ObservableProperty]
        private PeopleBaseRecord peopleListRecord;

        [ObservableProperty]
        private PeopleBaseRecord peopleBaseRecord;

        [ObservableProperty]
        private PeopleExtendedRecord peopleExtendedRecord;

        [ObservableProperty]
        private Dictionary<string, Translation> translations;

    }
}
