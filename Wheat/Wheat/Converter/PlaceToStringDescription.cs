using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Wheat.Converter
{
    public class PlaceToStringDescription : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string place = value as string; 
            if (string.IsNullOrWhiteSpace(place)) return "未经记载......";
            return "前往「" + place + "」取得";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
