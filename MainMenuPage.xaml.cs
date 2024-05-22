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
    /// Логика взаимодействия для MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void InvoiceCreationButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvoiceCreationPage());
        }
        private void InvoiceEditButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvoiceEditPage());
        }
        private void InvoicesListButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvoicesListPage());
        }
        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StatisticsPage());
        }
        private void FeedbackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FeedbackPage());
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

    }
}
