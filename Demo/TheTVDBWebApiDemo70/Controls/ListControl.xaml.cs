namespace TheTVDBWebApiDemo.Controls
{
    /// <summary>
    /// Interaction logic for ListControl.xaml
    /// </summary>
    public partial class ListControl : UserControl
    {
        public ListControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty TitleProperty =
          DependencyProperty.Register("Title", typeof(string), typeof(ListControl),
              new FrameworkPropertyMetadata(null));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty ItemsProperty =
           DependencyProperty.Register("Items", typeof(System.Collections.IEnumerable), typeof(ListControl),
               new FrameworkPropertyMetadata(null));

        public System.Collections.IEnumerable Items
        {
            get => (System.Collections.IEnumerable)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
    }
}
