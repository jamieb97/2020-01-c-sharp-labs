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

namespace lab_38_rabbits_advanced
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<rabbittable> rabbits = new List<rabbittable>();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        void Initialize()
        {

        }

        private void ListViewRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
