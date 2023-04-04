using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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

namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuItem.xaml
    /// </summary>
    public partial class MenuItem : Page
    {
        

        public MenuItem()
        {
            InitializeComponent();

            AppData.frame1 = switcher;

            Console.WriteLine(topName);




            AppData.MenuItemProfileImage = topImage;
            

            

        }



        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            var profile = new Profile();
            profile.DataContext = DataContext;
            AppData.frame1.Content = profile;
        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            AppData.frame1.Content = new TablePage();
        }

       

        private void ExitButtonclick(object sender, RoutedEventArgs e)
        {
            AppData.frame.GoBack();
        }
    }
    }

