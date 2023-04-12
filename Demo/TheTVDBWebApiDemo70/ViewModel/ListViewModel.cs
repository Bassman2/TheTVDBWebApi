namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class ListViewModel : ObservableObject
    {
        public ListViewModel(ListBaseRecord record)
        {
            this.ListListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.ListBaseRecord = await client.GetListAsync(record.Id);
                    this.ListExtendedRecord = await client.GetListExtendedAsync(record.Id);

                    List<Languages> nameLang = this.ListBaseRecord.NameTranslations;
                    List<Languages> overLang = this.ListBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    //this.Translations = lang.Select(l => client.GetListTranslationAsync(record.Id, l).Result).ToList();
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
        private List<Translation> translations;
    }
}
