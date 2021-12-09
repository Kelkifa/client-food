using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Food.Converters
{
    class DiscountPriceConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0]==null || values[1]==null) return "";
            int cost = (int)values[0];
            int discount = (int)values[1];

            return (cost-cost*discount/100).ToString("N0") + " đ";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
