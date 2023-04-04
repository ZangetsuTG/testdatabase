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
    /// Логика взаимодействия для TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {

        SqlDataAdapter adapter = new SqlDataAdapter();
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DXD; Initial Catalog = Autification; Integrated Security = True");
        DataTable table = new DataTable();


        public TablePage()
        {
            InitializeComponent();


            string sql = $"select * from [School]";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            data.ItemsSource = table.DefaultView;



        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            adapter.DeleteCommand = new SqlCommand();
            adapter.DeleteCommand.Connection = sqlConnection;
           adapter.DeleteCommand.CommandType = CommandType.Text;
            adapter.DeleteCommand.CommandText = @"delete from School where Name = @name";
            adapter.DeleteCommand.Parameters.Add("@name", SqlDbType.NVarChar, 4000, "Name");

            if (MessageBox.Show("You sure?",
                "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    if (data.SelectedItems.Count == 1)
                    {
                        int selectedIndex = data.SelectedIndex;
                        var row = table.Rows[selectedIndex];
                        row.Delete();

                        adapter.Update(table);
                    }
                    else if (data.SelectedItems.Count > 1)
                    {
                        while (data.SelectedItems.Count > 0)
                        {
                            int selectedIndex = data.SelectedIndex;
                            var row = table.Rows[selectedIndex];
                            row.Delete();

                            adapter.Update(table);
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
               
            }

           
        }
    }
}
