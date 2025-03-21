﻿namespace TheTVDBWebApiDemo.ViewModel
{
    public partial class SeriesViewModel : ObservableObject
    {
        public SeriesViewModel(SeriesBaseRecord record)
        {
            this.SeriesListRecord = record;

            Task.Run(async () =>
            {
                using (var client = new TVDBWeb("tvdb", "TheTVDBWebApiDemo"))
                {
                    this.SeriesBaseRecord = await client.GetSeriesAsync(record.Id);
                    this.SeriesExtendedRecord = await client.GetSeriesExtendedAsync(record.Id, MetaSeries.Episodes, false);

                    List<Languages> nameLang = this.SeriesBaseRecord.NameTranslations;
                    List<Languages> overLang = this.SeriesBaseRecord.OverviewTranslations;
                    List<Languages> lang = nameLang.Concat(overLang).Distinct().ToList();
                    this.Translations = lang.Select(l => client.GetSeriesTranslationAsync(record.Id, l).Result).ToList();
                }
            });
        }

        [ObservableProperty]
        private SeriesBaseRecord seriesListRecord;

        [ObservableProperty]
        private SeriesBaseRecord seriesBaseRecord;

        [ObservableProperty]
        private SeriesExtendedRecord seriesExtendedRecord;

        [ObservableProperty]
        private List<Translation> translations;
    }
}
