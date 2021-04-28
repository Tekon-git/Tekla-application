using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GridBuilder.Infrastructure.Converters
{
    class StringToDoubleArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<double> list = value as List<double>;
            if (list is null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (double d in list)
            {
                sb.Append(d + " ");
            }
            string s = sb.ToString().Trim();
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<double> list = new List<double>();
           
            string[] s = ((string)value).Split(' ');
            foreach (string str in s)
            {
                list.Add(double.Parse(str));
            }
            return list;
        }
    }
}
