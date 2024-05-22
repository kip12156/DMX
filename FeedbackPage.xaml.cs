using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace DemoEx
{
    /// <summary>
    /// Логика взаимодействия для FeedbackPage.xaml
    /// </summary>
    public partial class FeedbackPage : Page
    {
        public FeedbackPage()
        {
            InitializeComponent();

            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode("yandex.ru", QRCodeGenerator.ECCLevel.Q);
            QRCode qRCode = new QRCode(qRCodeData);

            Bitmap bitmap = qRCode.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                qRCodeUIImage.Source = bitmapImage;
            }
        }
    }
}
