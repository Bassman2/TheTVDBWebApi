using System.Windows.Controls;

namespace TheTVDBWebApiDemo.View
{
    /// <summary>
    /// Interaction logic for DetailTranslationsView.xaml
    /// </summary>
    public partial class DetailTranslationsView : UserControl
    {
        public DetailTranslationsView()
        {
            InitializeComponent();

            SetBinding(NameTranslationsProperty, new Binding("NameTranslations"));
            SetBinding(OverviewTranslationsProperty, new Binding("OverviewTranslations"));
            SetBinding(TranslationsProperty, new Binding("DataContext.Translations")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ScrollViewer), 1)
            });
        }

        public static readonly DependencyProperty NameTranslationsProperty =
            DependencyProperty.Register("NameTranslations", typeof(List<string>), typeof(DetailTranslationsView), 
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnNameTranslationsChanged)));

        public List<string> NameTranslations
        {
            get => (List<string>)GetValue(NameTranslationsProperty);
            set => SetValue(NameTranslationsProperty, value);
        }

        public static readonly DependencyProperty OverviewTranslationsProperty =
            DependencyProperty.Register("OverviewTranslations", typeof(List<string>), typeof(DetailTranslationsView),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnOverviewTranslationsChanged)));

        public List<string> OverviewTranslations
        {
            get => (List<string>)GetValue(OverviewTranslationsProperty);
            set => SetValue(OverviewTranslationsProperty, value);
        }

        public static readonly DependencyProperty TranslationsProperty =
            DependencyProperty.Register("Translations", typeof(Dictionary<string, Translation>), typeof(DetailTranslationsView), 
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnTranslationsChanged)));

        public Dictionary<string, Translation> Translations
        {
            get => (Dictionary<string, Translation>)GetValue(TranslationsProperty);
            set => SetValue(TranslationsProperty, value);
        }

         
        private static void OnNameTranslationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DetailTranslationsView view = (DetailTranslationsView)d;
            if (e.NewValue != null)
            {
                view.Update();
            }
        }

        private static void OnOverviewTranslationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DetailTranslationsView view = (DetailTranslationsView)d;
            if (e.NewValue != null)
            {
                view.Update();
            }
        }

        private static void OnTranslationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DetailTranslationsView view = (DetailTranslationsView)d;
            if (e.NewValue != null) 
            {
                view.Update();
            }
        }

        private void Update()
        {
            if (this.Translations != null)
            {
                if (this.NameTranslations != null)
                {
                    this.NameItems = this.NameTranslations.Select(l => this.Translations[l]).ToList();
                }

                if (this.OverviewTranslations != null)
                {
                    this.OverviewItems = this.OverviewTranslations.Select(l => this.Translations[l]).ToList();
                }
            }
        }

        public static readonly DependencyProperty NameItemsProperty =
            DependencyProperty.Register("NameItems", typeof(List<Translation>), typeof(DetailTranslationsView),
                new FrameworkPropertyMetadata(null));

        public List<Translation> NameItems
        {
            get => (List<Translation>)GetValue(NameItemsProperty);
            set => SetValue(NameItemsProperty, value);
        }

        public static readonly DependencyProperty OverviewItemsProperty =
            DependencyProperty.Register("OverviewItems", typeof(List<Translation>), typeof(DetailTranslationsView),
                new FrameworkPropertyMetadata(null));

        public List<Translation> OverviewItems
        {
            get => (List<Translation>)GetValue(OverviewItemsProperty);
            set => SetValue(OverviewItemsProperty, value);
        }
    }
}
