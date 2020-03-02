using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace lab_66_wpf_football_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Player> Players = new List<Player>();
        public MainWindow()
        {
            Initialize();
            InitializeComponent();
        }

        public void Initialize()
        {
            using (var db = new FootballModel())
            {
                Players = db.Player.ToList();
            }
        }

        private void ShowDataButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
