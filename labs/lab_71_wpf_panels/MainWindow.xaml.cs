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

namespace lab_71_wpf_panels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            ListBoxCustomer.Items.Add("Customer List");
            ListBoxCustomer.Items.Add("OoOoOoOoOoOoOoOoOo");
            for(int i = 0; i < 15; i++)
            {
                ListBoxCustomer.Items.Add("Customer" + i);
            }
        }

        private void ButtonTest1_Click(object sender, RoutedEventArgs e)
        {
            Label01.Content = "hey you clicked 1";
        }

        private void ButtonTest2_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewerCustomer.Visibility = Visibility.Visible;
        }

        private void ButtonTest4_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Window();
            newWindow.Show();
        }

        private void ButtonTest5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTest6_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
