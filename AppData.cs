using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using test.ViewModels;

namespace test
{
    class AppData
    {
        public static Frame frame { get; set; }

        public static Frame frame1 { get; set; }


        public static User User { get; set; } 

        public static BitmapImage ProfileImage { get; set; }

        public static ImageBrush MenuItemProfileImage { get; set; }

        public static SharedViewModel SharedViewModel { get; set; } = new SharedViewModel();
    }
}
