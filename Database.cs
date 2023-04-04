using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace test
{
    public static class Database
    {
        public static SqlDataAdapter adapter = new SqlDataAdapter();
        public static SqlConnection sqlConnection = new SqlConnection(@"Data Source = DXD; Initial Catalog = Autification; Integrated Security = True");
        public static DataTable table = new DataTable();

        public static void UploadImageToDatabase()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Картинки(*.JPG;*.GIF)|*.JPG;*.GIF" + "|Все файлы (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                string fileName = myDialog.FileName;

                string sql = $"update [Entry] " +
                             $"set avatar=CONVERT(VARBINARY(MAX), (@AvatarContent), 1)" +
                             $"where username=('{AppData.User.Username}') ";
                using (SqlCommand _cmd = new SqlCommand(sql, sqlConnection))
                {
                    SqlParameter param = _cmd.Parameters.Add("@AvatarContent", SqlDbType.VarBinary);
                    param.Value = FromImageToBytes(fileName);

                    sqlConnection.Open();
                    _cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
        }

        public static byte[] DownloadImageFromDatabase() 
        {

           sqlConnection.Open();
            string sql = $"select * from [Entry] " +
                         $"where username=('{AppData.User.Username}') ";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            var reader = cmd.ExecuteReader();

            var rows = new List<Dictionary<dynamic, dynamic>>();
            Dictionary<dynamic, dynamic> column;
            while (reader.Read())
            {

                column = new Dictionary<dynamic, dynamic>();

                column["avatar"] = reader["avatar"];

                rows.Add(column);
            }
            sqlConnection.Close();

            if (rows[rows.Count - 1]["avatar"] is byte[] avatar)
                return rows[rows.Count - 1]["avatar"];
            else
                return null;
        }

        public static bool UploadUserData() //edit user on profile
        {

            if (AppData.User.Username.Length == 0)
            {
                MessageBox.Show("Field Username cannot be empty!");
                return false;
            }
            if (AppData.User.Name.Length == 0)
            {
                MessageBox.Show("Field Name cannot be empty!");
                return false;
            }
            if (AppData.User.Password.Length == 0)
            {
                MessageBox.Show("Field Password cannot be empty!");
                return false;
            }

            string sql = $"update [Entry] " +
                             $"set username=@Username, name=@Name, password=@Password " +  
                             $"where username=('{AppData.User.Username}') ";
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.Parameters.AddWithValue("@Username", AppData.User.Username);
            cmd.Parameters.AddWithValue("@Name", AppData.User.Name);
            cmd.Parameters.AddWithValue("@Password", AppData.User.Password);

            sqlConnection.Open();

            cmd.ExecuteNonQuery();

            sqlConnection.Close();
            return true;
        }

        public static byte[] FromImageToBytes(string pathToImage)
        {
            return File.ReadAllBytes(pathToImage);
        }
    }
}