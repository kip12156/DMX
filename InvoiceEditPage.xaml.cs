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
    /// Логика взаимодействия для InvoiceEditPage.xaml
    /// </summary>
    public partial class InvoiceEditPage : Page
    {
        public InvoiceEditPage()
        {
            InitializeComponent();
            invoicesIdComboBox.ItemsSource = DataBaseConnection.GetInvoicesId();
            executorsIdComboBox.ItemsSource = DataBaseConnection.GetExecutorsId();
        }

        private void SaveChangesButtonClick(object sender, RoutedEventArgs e)
        {
            var updateResult = DataBaseConnection.EditInvoice((int)invoicesIdComboBox.SelectedItem, (int)executorsIdComboBox.SelectedItem, defectDescriptionTextBox.Text);
            if (!updateResult)
            {
                MessageBox.Show("Ошибка при редактировании заявки", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Успешный успех", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new InvoiceEditPage());
            }
        }
    }
}
