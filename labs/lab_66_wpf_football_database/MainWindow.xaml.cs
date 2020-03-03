using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace lab_66_wpf_football_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Player> players = new List<Player>();
        static Uri url = new Uri("https://localhost:44377/api/players");
        static HttpClient httpClient = new HttpClient();
        public MainWindow()
        {
            Initialize();
            InitializeComponent();
        }

        public void Initialize()
        {
            
        }

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Dispatcher.BeginInvoke(
                    new Action(() =>
                    {
                        GetPlayers();
                    })
                );
            
            }).Start();
        }


        private async void GetPlayers()
        {
            using (var client = new HttpClient())
            {
                var jsonString = await GetPlayersData(url.ToString());
                players = JsonConvert.DeserializeObject<List<Player>>(jsonString);
                ListViewPlayers.ItemsSource = players;
            }
        }

        private async Task<string> GetPlayersData(string url)
        {
            string jsonString = null;
            using (var client = new HttpClient())
            {
                jsonString = await client.GetStringAsync(url);
            }
            return jsonString;
        }

        private void ListViewPlayers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            //use data input to make new player

        }
    }
}
