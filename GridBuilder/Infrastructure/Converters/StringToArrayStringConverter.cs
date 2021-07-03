using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GridBuilder.Infrastructure.Converters
{
    class StringToArrayStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = value as List<string>;
            StringBuilder sb = new StringBuilder();
            foreach (string str in list)
            {
                sb.Append(str + " ");
            }
            string s = sb.ToString().Trim();
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<string> list = new List<string>();
            string s = value as string;
            string[] words = s.Split(' ');
            foreach (string str in words)
            {
                list.Add(str);
            }
            return list;
        }
    }
}
