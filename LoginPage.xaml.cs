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

namespace DemoEx
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(logintextbox.Text))
            {
                MessageBox.Show("Ошибка! Не введен логин", "Ошибка ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (String.IsNullOrWhiteSpace(passwordBox.Password))
            {
                MessageBox.Show("Ошибка! Не введен пароль", "Ошибка ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var authorizeResult = DataBaseConnection.AuthorizeUser(logintextbox.Text, passwordBox.Password);
            if(!authorizeResult)
            {
                MessageBox.Show("Неправильно введен логин или пароль", "Ошибка авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (MainWindow.UserRole == "User")
            {
                NavigationService.Navigate(new MainMenuPage());
            }
            else if (MainWindow.UserRole == "Executor")
            {
                NavigationService.Navigate(new InvoiceExecutionPage());
            }
            else if (MainWindow.UserRole == "Manager")
            {
                NavigationService.Navigate(new ManagerMenuPage());
            }
        }
    }
}
