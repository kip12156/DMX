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
    /// Логика взаимодействия для ManagerMenuPage.xaml
    /// </summary>
    public partial class ManagerMenuPage : Page
    {
        public ManagerMenuPage()
        {
            InitializeComponent();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }

        private void InvoiceExecutorsEditButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InvoiceExecutorsEditPage());
        }
        private void InvoiceFinishDateEditButtonClick(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new InvoiceFinishDateEditPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
