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

namespace lab_40_wpf_database
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        static List<gametable> game = new List<gametable>();
        static gametable gameTable = new gametable();

        static List<baskettable> basket = new List<baskettable>();
        static baskettable basketTable = new baskettable();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            using (var db = new gamedatabaseEntities())
            {
                game = db.gametables.ToList();
            }
            using (var db2 = new basketdatabaseEntities())
            {
                basket = db2.baskettables.ToList();
            }
        }

        private void ShowGames_Click(object sender, RoutedEventArgs e)
        {
            GameView.ItemsSource = game;
        }

        private void ButtonPurchase_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
