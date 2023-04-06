namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class PeopleViewModel : ObservableObject
    {
        public PeopleViewModel(PeopleBaseRecord record)
        {
            this.PeopleListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.PeopleBaseRecord = await client.GetPeopleAsync(record.Id);
                    this.PeopleExtendedRecord = await client.GetPeopleExtendedAsync(record.Id, Meta.Translations);

                    List<string> nameLang = this.PeopleBaseRecord.NameTranslations;
                    List<string> overLang = this.PeopleBaseRecord.OverviewTranslations;
                    List<string> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.Select(l => client.GetPeopleTranslationAsync(record.Id, l).Result).ToList();
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
        private List<Translation> translations;
    }
}
