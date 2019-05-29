using MyPlaylistExam.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

namespace MyPlaylistExam
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
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
                                    if (txtNewPassword.Password == txtNewPasswordCopy.Password) // проверка на совпадение паролей
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
            User user = new User()
            {
                Name = txtNewLogin.Text,
                Password = txtNewPassword.Password,
            };
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //string strCon = ConfigurationManager.AppSettings["DefaultConnection"];
                    using (SqlConnection con = new SqlConnection(@"Data Source = SLIMBOYFAT-ПК; Initial Catalog = MyPlaylist; Integrated Security = True"))
                    {
                        con.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = con;
                        var query = $"INSERT INTO [tblUserPL] ([UserName], [Password]) VALUES('{user.Name}','{user.Password}')";
                        command.CommandText = query;
                        int userId = 0;
                        var count = command.ExecuteNonQuery();
                        if (count == 1)
                        {
                            query = "SELECT SCOPE_IDENTITY() AS UserId";
                            command.CommandText = query;
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                userId = int
                                    .Parse(reader["UserId"].ToString());
                            }
                            MessageBox.Show("Ваші дані додано успішно!");
                            reader.Close();
                        }
                        else { throw new Exception("Проблема при додаванні користувача"); }
                    }
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка збереження даних", ex.Message);
            }
            Close();
        }
    }
}
