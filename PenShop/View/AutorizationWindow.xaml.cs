using PenShop.db;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace PenShop.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        private static bool isAutorization = true;
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void AutorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isAutorization)
            {
                App.user = App.db.Users.Where(x => x.Login == LoginTB.Text && x.Password == PassPB.Password).FirstOrDefault();

                if (App.user == null)
                {
                    MessageBox.Show("Неправильный пароль или логин!");
                    return;
                }

                MessageBox.Show($"Добро пожаловать в программу {App.user.FIO}");
                new HomeWindow().Show();
                this.Close();
                return;
            }

            var user = new Users();
            user.Login = LoginTB.Text;  
            user.Password = PassPB.Password;
            user.FIO = FioTB.Text;
            user.Id_Role = 2;
            App.db.Users.Add(user);
            App.db.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно!");
        }

        private void RegistrationBtn_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (isAutorization)
            {
                CaptionLbl.Content = "Регистрация";
                AutorizationBtn.Content = "Зарегистрироваться";
                RegistrationNavigateBtn.Text = "Вход";
                FioPnl.Visibility = Visibility.Visible;
            }
            else
            {
                CaptionLbl.Content = "Авторизация";
                AutorizationBtn.Content = "Войти";
                RegistrationNavigateBtn.Text = "Регистрация";
                FioPnl.Visibility = Visibility.Collapsed;
            }

            isAutorization = !isAutorization;
        }
    }
}
