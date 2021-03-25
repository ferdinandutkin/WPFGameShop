using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPFGameShop
{
    class ByteArrayToBitmapConverter : IValueConverter
    { 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {

                return null;
            }

            var ms = new MemoryStream(value as byte[]);

            ms.Seek(0, SeekOrigin.Begin);

            var newBitmapImage = new BitmapImage();

            newBitmapImage.BeginInit();

            newBitmapImage.StreamSource = ms;

            newBitmapImage.EndInit();

            return newBitmapImage;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
            {
                return null;
            }
            byte[] buffer;
            var stream = (value as BitmapImage).StreamSource;
            using (var br = new BinaryReader(stream))
            {
                buffer = br.ReadBytes((int)stream.Length);
            }
            return buffer;
        }
    }
}
