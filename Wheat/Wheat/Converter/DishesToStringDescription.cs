using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Wheat.Models;
using Xamarin.Forms;

namespace Wheat.Converter
{
    public class DishesToStringDescription : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<DishModel> dishes = value as List<DishModel>;
            StringBuilder sb = new StringBuilder();

            if (!dishes[0].IsNonStapleFood)
                if (dishes.Count == 1)
                {
                    if (string.IsNullOrWhiteSpace(dishes[0].Place))
                        sb.Append("目的地显然, " + "目标是" + dishes[0].Name + ".\n");
                    else
                        sb.Append("目的地是「" + dishes[0].Place + "」,\n目标是" + dishes[0].Name + ".\n");
                    sb.Append("代价是" + dishes[0].Price + ".\n");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(dishes[0].Place))
                        sb.Append("目的地显然, " + "目标是" + dishes[0].Name + ".\n");
                    else
                        sb.Append("目的地是「" + dishes[0].Place + "」, 目标是" + dishes[0].Name + ".\n");
                    sb.Append("至于副食, ");
                    if (string.IsNullOrWhiteSpace(dishes[1].Place))
                        sb.Append("目标是" + dishes[1].Name + ".\n");
                    else
                        sb.Append("前往「" + dishes[1].Place + "」, 目标是" + dishes[1].Name + ".\n");
                }
            else
            {
                if (string.IsNullOrWhiteSpace(dishes[0].Place))
                {
                    sb.Append("一份" + dishes[0].Name + ",\n");
                }
                else
                    sb.Append(dishes[0].Place + ", 一份" + dishes[0].Name + ".\n");
            }

            return sb;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
