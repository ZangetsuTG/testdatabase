using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для SignUpForm.xaml
    /// </summary>
    public partial class SignUpForm : Page
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            AppData.frame.GoBack();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlConnection sqlConnection = new SqlConnection(@"Data Source = DXD; Initial Catalog = Autification; Integrated Security = True");
            DataTable table = new DataTable();

            string sql = $"insert  into [Entry]([username], [password], [name]) values('{EnterUserName.Text}','{EnterPass.Text}','{EnterName.Text}')";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            MessageBox.Show("The information is saved");
            AppData.frame.GoBack();


            


        }
    }
}
