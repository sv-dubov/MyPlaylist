using Microsoft.Win32;
using MyPlaylistExam.Entities;
using MyPlaylistExam.Helpers;
using MyPlaylistExam.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Web;

namespace MyPlaylistExam
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private EFContext _context;
        public string ImgStr { get; set; }
        public SignUp()
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

        private void btnNewSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewLogin.Text.Length > 0) // перевірка логіна
            {
                if (txtNewPassword.Password.Length > 0) // перевірка пароля
                {
                    if (txtNewPasswordCopy.Password.Length > 0) // повторна перевірка пароля
                    {
                        if (txtNewPassword.Password.Length >= 6)
                        {
                            bool en = true; // англ. розкладка
                            bool symbol = false; // символ
                            bool number = false; // цифра

                            for (int i = 0; i < txtNewPassword.Password.Length; i++) // перебір символів
                            {
                                if (txtNewPassword.Password[i] >= 'А' && txtNewPassword.Password[i] <= 'Я')
                                    en = false; // якщо укр. чи рос. розкладка
                                if (txtNewPassword.Password[i] >= '0' && txtNewPassword.Password[i] <= '9')
                                    number = true; // якщо цифри
                                if (txtNewPassword.Password[i] == '_' || txtNewPassword.Password[i] == '-' || txtNewPassword.Password[i] == '!')
                                    symbol = true; // якщо символи
                            }

                            if (!en)
                                MessageBox.Show("Пароль може бути лише латиницею!");
                            else if (!symbol)
                                MessageBox.Show("Додайте один із таких символів: _ - !");
                            else if (!number)
                                MessageBox.Show("Додайте хоча б одну цифру");
                            if (en && symbol && number) // перевірка на повну відповідність
                                if (en)
                                {
                                    if (txtNewPassword.Password == txtNewPasswordCopy.Password) // перевірка співпадіння паролів
                                    {
                                        AddUser();
                                    }
                                    else MessageBox.Show("Паролі не співпадають");
                                }
                        }
                        else MessageBox.Show("Пароль надто короткий, потрібно мінімум 6 символів");
                    }
                    else MessageBox.Show("Повторіть пароль");
                }
                else MessageBox.Show("Вкажіть пароль");
            }
            else MessageBox.Show("Вкажіть логін");
        }

        private void AddUser()
        {
            try
            {
                _context.Users.Add(new User
                {
                    Name = txtNewLogin.Text,
                    Password = PasswordHash(txtNewPassword.Password),
                    Image = ImgStr
                });
                _context.SaveChanges();
                //try
                //{
                //    _context.SaveChanges();
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                //    {
                //        System.Web.HttpContext.Current.Response.Write("Object: " + validationError.Entry.Entity.ToString());
                //        System.Web.HttpContext.Current.Response.Write("");
                //        foreach (DbValidationError err in validationError.ValidationErrors)
                //        {
                //            System.Web.HttpContext.Current.Response.Write(err.ErrorMessage + "");
                //        }
                //    }
                //}
                MessageBox.Show("Ваші дані додано успішно!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження даних", ex.Message);
            }
            Close();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                ImgStr = ImageHelper.ImgToBase64(System.Drawing.Image.FromFile(dialog.FileName));
                imgUser.Source = new BitmapImage(new Uri(dialog.FileName));
            }
        }
    }
}
