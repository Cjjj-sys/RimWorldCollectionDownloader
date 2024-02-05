using System;
using System.Text;
using System.Text.Json;
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
        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchButton.IsEnabled = false;
            var testPublishedfiles = new Publishedfiledetails {
                new Publishedfiledetail { title = "test"} ,
            new Publishedfiledetail {title = "test2"} };
            var id = CollectionIdTextBox.Text;
            if (id == null || id == "")
            {
                MessageBox.Show($"id is null", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                if (!SearchButton.IsEnabled)
                {
                    SearchButton.IsEnabled = true;
                }
                return;
            }
            try
            {
                var testCollection = await Utils.GetWorkShopCollectionAsync(id);
                var testItems = (await Utils.GetWorkShopItemsAsync(testCollection)).ToList();
                testPublishedfiles = new Publishedfiledetails(testItems);
                publishedfiledetails = testPublishedfiles;
            }
            catch (Exception exception)
            {
                MessageBox.Show($"id is invalid\n{exception.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            finally
            {
                if (!SearchButton.IsEnabled)
                {
                    SearchButton.IsEnabled = true;
                }
            }
        }

        private void WorkshopItemsListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = WorkshopItemsListView.SelectedItem as Publishedfiledetail;
            if (item != null)
            {
                ItemDetailsTextBox.Text = item.description;
            }

            if (!SearchButton.IsEnabled)
            {
                SearchButton.IsEnabled = true;
            }
        }
    }
}