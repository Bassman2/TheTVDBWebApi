namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class CompanyViewModel : ObservableObject
    {
        public CompanyViewModel(Company record)
        {
            this.CompanyListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb(MainViewModel.TokenContainer))
                {
                    this.CompanyBaseRecord = await client.GetCompanyAsync(record.Id);

                    List<Languages> nameLang = this.CompanyBaseRecord.NameTranslations;
                    List<Languages> overLang = this.CompanyBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    //this.Translations = lang.Select(l => client.GetCompanyTranslationAsync(record.Id, l).Result).ToList();
                }
            });
        }

        [ObservableProperty]
        private Company companyListRecord;

        [ObservableProperty]
        private Company companyBaseRecord;

        [ObservableProperty]
        private List<Translation> translations;
    }
}
