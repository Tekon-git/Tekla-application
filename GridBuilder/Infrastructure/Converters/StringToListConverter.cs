using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GridBuilder.Infrastructure.Converters
{
    class StringToListConverter : IValueConverter
    {
        

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            List<(int, double)> List = value as List<(int, double)>;
            StringBuilder sb = new StringBuilder();
            foreach((int, double) val in List)
            {
                if (val.Item1 == 1)
                    sb.Append(val.Item2 + " ");
                else
                    sb.Append(val.Item1 + "*" + val.Item2 + " ");
            }
            string s = sb.ToString().Trim();
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = ((string)value).Trim(' ', '*');
            string[] ar = s.Split(' ');
            ar = ar.Select(x => x.Trim('*')).ToArray();
            ar = ar.Where(i => i != string.Empty).ToArray();

            List<(int, double)> List = new List<(int, double)>();
            for (int i = 0; i < ar.Length; i++)
            {
                string str = ar[i];

                if (str.Contains('*'))
                {
                    string[] words = str.Split('*');
                    (int, double) cort = (int.Parse(words[0]), double.Parse(words[1]));
                    List.Add(cort);
                }
                else
                {
                    (int, double) cort = (1, double.Parse(str));
                    List.Add(cort);
                }
            }
            return List;
        }
    }
}
