using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace NotaSpese.Infrastructure
{
   public class DateTimeToStringConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, string language)
            {
                return String.Format("{0:MM/dd/yyyy}", (DateTimeOffset)value);
            }

            public object ConvertBack(object value, Type targetType, object parameter, string culture)
            {
                throw new NotImplementedException();
            }
        }
    
}
