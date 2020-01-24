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

namespace lab_26_rabbit_generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static List<Rabbit> rabbitList = new List<Rabbit>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonGenRabbits100TimesClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                var rabbit = new Rabbit();
                rabbit.age = 0;
                rabbit.rabbitName = "Rabbit" + i;
                rabbitList.Add(rabbit);
            }

            foreach(var rabbit in rabbitList)
            {
                List100Rabbits.Items.Add(rabbit.rabbitName );
            }
        }
        private void ButtonAgeRabbitsClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                var rabbit = new Rabbit();
                rabbit.age = 0;
                rabbit.rabbitName = "Rabbit" + i;
                rabbitList.Add(rabbit);
            }
            foreach (var i in rabbitList)
            {
                i.age+=50;
                ListAgeRabbits.Items.Add(i.rabbitName + " " + i.age);
            }
        }

        private void ButtonBreedRabbitsClick(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            var rabbits = new List<Rabbit>();
            string[] names = new string[] { "hector", "lionel", "pierre", "matteo", "paul", "kieran", "gabbi", "jadon", "zlatan", "kylian" };
            rabbits.Add(new Rabbit());
            rabbits[0].rabbitId = 1;
            rabbits[0].age = 0;
            rabbits[0].rabbitName = names[rand.Next(0, 9)];

            int numRabs = 0;
            int currentRab = 0;
            if (rabbits.Count < 50)
            {

                AgeRabbits(rabbits);
                for (int i = 0; i <= numRabs; i++)
                {
                    currentRab++;
                    rabbits.Add(new Rabbit());
                    rabbits[currentRab].rabbitId = currentRab + 1;
                    rabbits[currentRab].age = 0;
                    rabbits[currentRab].rabbitName = names[rand.Next(0, 9)];

                    if (i == numRabs)
                    {

                        if (rabbits.Count > 50)
                            break;
                        if (numRabs == 0)
                            numRabs = 1;
                        if (numRabs == 1)
                            numRabs = 2;
                        else
                            numRabs = rabbits.Count;
                        AgeRabbits(rabbits);

                        i = 0;
                    }
                }
            }
            foreach (var i in rabbits)
            {
                i.age++;
                ListBreedRabbits.Items.Add(i.rabbitName + " " + i.age);
            }

            void AgeRabbits(List<Rabbit> rabage)
            {
                rabage.ForEach(item => item.age++);
            }
        }

    }  

    class Rabbit 
    {
        public int rabbitId { get; set; }
        public string rabbitName { get; set; }
        public int age { get; set; }

    }

}
