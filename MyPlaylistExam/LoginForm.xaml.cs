using MyPlaylistExam.Entities;
using MyPlaylistExam.Models;
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
        private EFContext _context;
        private List<UserViewModel> _userList;
        public LoginForm()
        {
            InitializeComponent();
            _context = new EFContext();
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
            try
            {
                _userList = new List<UserViewModel>(_context.Users.Select(u => new UserViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    Password = u.Password,
                    Image = u.Image
                }).Where(u => u.Name == txtUsername.Text)
                .ToList());

                foreach (var item in _userList)
                {
                    if (item.Name == txtUsername.Text && item.Password == PasswordHash(txtPassword.Password))
                    {
                        TracksForm tf = new TracksForm();
                        tf.Show();
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Неправильний логін або пароль!");
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
        }
    }
}
