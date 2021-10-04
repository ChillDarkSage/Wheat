using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using Wheat.Models;
using Xamarin.Forms;

namespace Wheat.Converter
{
    public class DishCountToIsVisible : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dishModeles = value as ObservableCollection<DishModel>;
            int count = dishModeles.Count;
            return count == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
