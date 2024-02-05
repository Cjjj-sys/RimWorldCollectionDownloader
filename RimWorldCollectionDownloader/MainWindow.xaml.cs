using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RimWorldCollectionDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Publishedfiledetails _publishedfiledetails;
        public Publishedfiledetails publishedfiledetails
        {
            get
            {
                return _publishedfiledetails;
            }
            set
            {
                _publishedfiledetails = value;
                this.RefreshWorkshopItemsListView();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public void RefreshWorkshopItemsListView()
        {
            WorkshopItemsListView.ItemsSource = null;
            WorkshopItemsListView.Items.Clear();
            WorkshopItemsListView.ItemsSource = publishedfiledetails;
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var testPublishedfiles = new Publishedfiledetails {
                new Publishedfiledetail { title = "test"} ,
            new Publishedfiledetail {title = "test2"} };
            publishedfiledetails = testPublishedfiles;
        }
    }
}