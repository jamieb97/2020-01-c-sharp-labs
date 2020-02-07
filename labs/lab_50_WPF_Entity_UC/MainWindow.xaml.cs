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

namespace lab_50_WPF_Entity_UC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>();
        List<Category> categories = new List<Category>();
        User user = new User();
        Category category = new Category();
        bool EditUser = false;
        public MainWindow()
        {
            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {

            using (var db = new UsersCatergoriesModel())
            {
                users = db.Users.ToList();
                categories = db.Categories.ToList();
            }
            ListBox01.ItemsSource = users;
            ListBox02.ItemsSource = categories;
            ListBox01.DisplayMemberPath = "UserName";
            ListBox02.DisplayMemberPath = "CategoryName";
            ComboBoxCatergories.ItemsSource = categories;
            ComboBoxCatergories.DisplayMemberPath = "CategoryName";
            ComboBoxCatergories.IsReadOnly = true;
        }

        private void ListBox01_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBox01.SelectedItem != null)
            {
                user = (User)ListBox01.SelectedItem;
                //display user category in combo
                ComboBoxCatergories.Text = user.Category.CategoryName;
            }
        }

        private void ListBox02_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox02_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void ComboBoxCatergories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            category = (Category)ComboBoxCatergories.SelectedItem;
            if (EditUser && user != null)
            {
                using (var db = new UsersCatergoriesModel())
                {
                    var userToUpdate = db.Users.Find(user.UserID);
                    userToUpdate.CategoryID = category.CategoryID;
                    db.SaveChanges();
                    ListBox01.ItemsSource = null;
                    users = db.Users.ToList();
                    ListBox01.ItemsSource = users;
                    MessageBox.Show($"User {user.UserName} category changed to {userToUpdate.Category.CategoryName}");
                    ListBox02.ItemsSource = null;
                    categories = db.Categories.ToList();
                    ListBox02.ItemsSource = categories;
                    EditUser = false;
                    ListBox01.Background = Brushes.White;
                }
            }
        }

        private void ListBox01_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ComboBoxCatergories.Background = Brushes.NavajoWhite;
            ListBox01.Background = Brushes.NavajoWhite;
            EditUser = true;
        }
    }
}