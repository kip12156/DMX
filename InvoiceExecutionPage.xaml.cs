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
    /// Логика взаимодействия для InvoiceExecutionPage.xaml
    /// </summary>
    public partial class InvoiceExecutionPage : Page
    {
        public InvoiceExecutionPage()
        {
            InitializeComponent();
            invoicesIdComboBox.ItemsSource = DataBaseConnection.GetInvoicesIdByExecutorId(MainWindow.UserId);
        }

        private void AcceptInvoiceInWorkButtonClick(object sender, RoutedEventArgs e)
        {
            var updateResult = DataBaseConnection.AcceptInvoiceinWork((int)invoicesIdComboBox.SelectedItem);
            if (!updateResult)
            {
                MessageBox.Show("Ошибка при принятии заявки", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Успешный успех", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new InvoiceExecutionPage());
            }
        }
        
        private void CompleteInvoiceButtonClick(object sender, RoutedEventArgs e)
        {
            var updateResult = DataBaseConnection.CompleteInvoice((int)invoicesIdComboBox.SelectedItem, executorCommentTextBox.Text);
            if (!updateResult)
            {
                MessageBox.Show("Ошибка при завершении заявки", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Успешный успех", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new InvoiceExecutionPage());
            }
        }
    }
}
