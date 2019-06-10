using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyPlaylistExam
{
    /// <summary>
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public static string PasswordHash(string plaintext)
        {
            HashAlgorithm mhash = new SHA1CryptoServiceProvider();
            byte[] bytValue = Encoding.UTF8.GetBytes(plaintext);
            byte[] bytHash = mhash.ComputeHash(bytValue);
            mhash.Clear();
            return Convert.ToBase64String(bytHash);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conStr = new SqlConnection(@"Data Source = SLIMBOYFAT-ПК; Initial Catalog = MyPlaylist; Integrated Security = True");
            try
            {
                if (conStr.State == ConnectionState.Closed)
                    conStr.Open();
                String query = "SELECT COUNT(1) FROM tblUserPL WHERE Name=@Name AND Password=@Password";
                SqlCommand cmd = new SqlCommand(query, conStr);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Password", PasswordHash(txtPassword.Password));
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неправильний логін або пароль!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conStr.Close();
            }
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
