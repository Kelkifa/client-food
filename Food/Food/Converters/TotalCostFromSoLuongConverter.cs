using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Food.Converters
{
    class TotalCostFromSoLuongConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] == null || values[1] == null || values[2] == null) return "";
            int cost = (int)values[0];
            int soLuong = (int)values[1];
            int discount = (int)values[2];

            return ((cost - cost * discount / 100) * soLuong ).ToString("N0") + "đ";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
