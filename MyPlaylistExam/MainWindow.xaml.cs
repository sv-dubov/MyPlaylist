using System;
using System.Collections.Generic;
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

namespace MyPlaylistExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnLoginStart_Click(object sender, RoutedEventArgs e)
        {
            LoginForm login = new LoginForm();
            login.ShowDialog();
            Close();
        }

        private void BtnSignUpStart_Click(object sender, RoutedEventArgs e)
        {
            SignUp signup = new SignUp();
            signup.ShowDialog();
            Close();
        }
    }
}
