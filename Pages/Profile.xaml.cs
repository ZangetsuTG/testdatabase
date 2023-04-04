using System.Windows;
using System.Windows.Controls;

namespace test.Pages
{
    /// <summary>
    /// Логика взаимодействия для Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {
        private bool editMode = false;

        public Profile()
        {
            InitializeComponent();

            //profilephoto.ImageSource = FromByteToImage(User.Picture);


        }

        private void UploadImageToDatabaseClick(object sender, RoutedEventArgs e)
        {
            Database.UploadImageToDatabase();
            AppData.User.Avatar = Database.DownloadImageFromDatabase();
            MessageBox.Show("Saved");
        }

        private void UploadUserDatatoDatabaseClick(object sender, RoutedEventArgs e)
        {

            if(Database.UploadUserData())
                MessageBox.Show("Changed");
        }

        private void EditData(object sender, RoutedEventArgs e)
        {
            editMode = !editMode;

            confirmbut.Visibility = editMode ? Visibility.Visible : Visibility.Collapsed;
            usernamefield.IsReadOnly = editMode ? false : true;
            loginfield.IsReadOnly = editMode ? false : true;
            passwordfield.IsReadOnly = editMode ? false : true;
        }
    }
}
