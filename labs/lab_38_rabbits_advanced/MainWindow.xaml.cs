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
            TextBoxRabbitID.IsReadOnly = true;
            TextBoxRabbitName.IsReadOnly = true;
            TextBoxRabbitAge.IsReadOnly = true;
            ButtonEdit.IsEnabled = false;
        }

        private void ListViewRabbits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListViewRabbits.SelectedItem != null)
            {
                Rabbit = (rabbittable)ListViewRabbits.SelectedItem;
                TextBoxRabbitID.Text = Rabbit.RabbitTableID.ToString();
                TextBoxRabbitName.Text = Rabbit.RabbitName.ToString();
                TextBoxRabbitAge.Text = Rabbit.RabbitAge.ToString();
                TextBoxRabbitID.IsReadOnly = true;
                TextBoxRabbitName.IsReadOnly = true;
                TextBoxRabbitAge.IsReadOnly = true;
            }
            ButtonEdit.IsEnabled = true;
        }

        private void ButtonShowRabbits_Click(object sender, RoutedEventArgs e)
        {
            ListViewRabbits.ItemsSource = rabbits;
            //ListViewRabbits.ItemsSource = rabbits;
            //TextBoxRabbitID.IsReadOnly = true;
            //TextBoxRabbitName.IsReadOnly = true;
            //TextBoxRabbitAge.IsReadOnly = true;
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

        private void ButtonAddRabbits_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAddRabbits.Content.ToString() == "Add Rabbit")
            {
                TextBoxRabbitName.IsReadOnly = false;
                TextBoxRabbitAge.IsReadOnly = false;
                TextBoxRabbitID.Text = "";
                TextBoxRabbitName.Text = "";
                TextBoxRabbitAge.Text = "";
                ButtonAddRabbits.Content = "Save";
            }
            else
            {
                if (TextBoxRabbitName.Text.Length > 0)
                {
                    Int32.TryParse(TextBoxRabbitAge.Text, out int rabbitAge);
                    var rabbitToAdd = new rabbittable()
                    {
                        RabbitName = TextBoxRabbitName.Text,
                        RabbitAge = rabbitAge,
                    };
                    using (var db = new newrabbitdatabaseEntities()) 
                    {
                        db.rabbittables.Add(rabbitToAdd);
                        db.SaveChanges();
                        ListViewRabbits.ItemsSource = null;
                        rabbits = db.rabbittables.ToList();
                        ListViewRabbits.ItemsSource = rabbits;
                    }
                }

                TextBoxRabbitName.IsReadOnly = true;
                TextBoxRabbitAge.IsReadOnly = true;
                ButtonAddRabbits.Content = "Add Rabbit";
            }
        }

        private void ListViewRabbits_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if(rabbits != null)
            {
                if(ButtonEdit.Content.ToString() == "Edit")
                {
                    var shade = new SolidColorBrush(Color.FromRgb(253, 180, 200));
                    TextBoxRabbitName.Background = shade;
                    TextBoxRabbitAge.Background = shade;
                    TextBoxRabbitName.IsReadOnly = false;
                    TextBoxRabbitAge.IsReadOnly = false;
                    ButtonEdit.Content = "Save";

                }
                else
                {
                    var shade = new SolidColorBrush(Color.FromRgb(170, 4, 50));
                    TextBoxRabbitName.Background = shade;
                    TextBoxRabbitAge.Background = shade;
                    TextBoxRabbitName.IsReadOnly = true;
                    TextBoxRabbitAge.IsReadOnly = true;
                    ButtonEdit.Content = "Edit";
                }
            }
            
        }
    }
}
