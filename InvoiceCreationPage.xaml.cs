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
    /// Логика взаимодействия для InvoiceCreationPage.xaml
    /// </summary>
    public partial class InvoiceCreationPage : Page
    {
        public InvoiceCreationPage()
        {
            InitializeComponent();
            deviceComboBox.ItemsSource = DataBaseConnection.GetDevicesId();
            defectComboBox.ItemsSource = DataBaseConnection.GetDefectsId();
        }

        private void CreateInvoiceButtonClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(clientNameTextBox.Text) 
                || String.IsNullOrWhiteSpace(clientEmailTextBox.Text) 
                || String.IsNullOrWhiteSpace(serialNumberTextBox.Text) 
                || String.IsNullOrWhiteSpace(defectDescriptionTextBox.Text) 
                || deviceComboBox.SelectedItem == null 
                || defectComboBox.SelectedItem == null 
                || datePicker.Text == "")
            {
                MessageBox.Show("Ошибка! Не введены необходимые поля", "Ошибка ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var creationresult = DataBaseConnection.AddInvoice(clientNameTextBox.Text, clientEmailTextBox.Text, (int)deviceComboBox.SelectedItem, serialNumberTextBox.Text, (int)defectComboBox.SelectedItem, defectDescriptionTextBox.Text, datePicker.Text);

            if (!creationresult)
            {
                MessageBox.Show("Ошибкапри добавлении заявки", "Ошибка ввода данных!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                MessageBox.Show("Успешный успех", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new InvoiceCreationPage());
            }
        }
    }
}
