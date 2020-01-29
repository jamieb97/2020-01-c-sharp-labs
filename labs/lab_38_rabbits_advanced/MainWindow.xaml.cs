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
        static rabbittable Rabbit = new rabbittable();
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }
        void Initialize()
        {
            //CLEAN CODE WRAPPER - BETTER 
            using (var db = new newrabbitdatabaseEntities())
            {
                rabbits = db.rabbittables.ToList();
                //foreach (var item in rabbits)
                //{
                //    ListViewRabbits.Items.Add($"ID: {item.RabbitTableID} Name: {item.RabbitName} DOB: {item.RabbitDOB} Age: {item.RabbitAge} Type: {item.RabbitType} Is Active: {item.RabbitIsActive}");
                //}
            }
            // db not valid here
        }

        private void ListViewRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewRabbits.SelectedItem != null)
            {
                Rabbit = (rabbittable)ListViewRabbits.SelectedItem;
                TextBoxRabbitID.Text = Rabbit.RabbitTableID.ToString();
                TextBoxRabbitName.Text = Rabbit.RabbitName.ToString();
                TextBoxRabbitAge.Text = Rabbit.RabbitAge.ToString();
            }
        }

        private void ButtonShowRabbits_Click(object sender, RoutedEventArgs e)
        {
            ListViewRabbits.ItemsSource = rabbits;
            
        }

        private void ListViewRabbits_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(Rabbit != null)
            {
                using (var db = new newrabbitdatabaseEntities())
                {
                    var rabbitToDelete = db.rabbittables.Find(Rabbit.RabbitTableID);
                    var result = MessageBox.Show($"Delete {Rabbit.RabbitName}? Are you sure?");
                    if(result == MessageBoxResult.OK)
                    {
                        db.rabbittables.Remove(rabbitToDelete);
                        db.SaveChanges();
                        ListViewRabbits.ItemsSource = null;
                        rabbits = db.rabbittables.ToList();
                        ListViewRabbits.ItemsSource = rabbits;
                    }
                }
            }
        }
    }
}
