namespace TheTVDBWebApiDemo.Controls
{
    /// <summary>
    /// Interaction logic for TranslationsControl.xaml
    /// </summary>
    public partial class TranslationsControl : UserControl
    {
        public TranslationsControl()
        {
            InitializeComponent();

            SetBinding(TranslationsProperty, new Binding("DataContext.Translations")
            {
                RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(ScrollViewer), 1)
            });
        }

        public static readonly DependencyProperty TitleProperty =
           DependencyProperty.Register("Title", typeof(string), typeof(TranslationsControl),
               new FrameworkPropertyMetadata(null));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty LanguagesProperty =
           DependencyProperty.Register("Languages", typeof(List<Languages>), typeof(TranslationsControl),
               new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnLanguagesChanged)));

        public List<Languages> Languages
        {
            get => (List<Languages>)GetValue(LanguagesProperty);
            set => SetValue(LanguagesProperty, value);
        }

        private static void OnLanguagesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TranslationsControl).Update();
        }

        public static readonly DependencyProperty TranslationsProperty =
            DependencyProperty.Register("Translations", typeof(List<Translation>), typeof(TranslationsControl),
                new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnTranslationsChanged)));

        public List<Translation> Translations
        {
            get => (List<Translation>)GetValue(TranslationsProperty);
            set => SetValue(TranslationsProperty, value);
        }

        private static void OnTranslationsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as TranslationsControl).Update();
        }

        private void Update()
        {
            if (this.Languages != null && this.Translations != null)
            {
                this.TranslationList = this.Languages.Select(l => this.Translations.FirstOrDefault(t => t.Language == l)).ToList();
            }
            else
            {
                this.TranslationList = null;
            }
        }

        public static readonly DependencyProperty TranslationListProperty =
            DependencyProperty.Register("TranslationList", typeof(List<Translation>), typeof(TranslationsControl),
                new FrameworkPropertyMetadata(null));

        public List<Translation> TranslationList
        {
            get => (List<Translation>)GetValue(TranslationListProperty);
            set => SetValue(TranslationListProperty, value);
        }

    }
}
