using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Food.Converters
{
    internal class TotalCostFromCart : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            List<Cart> cartList = (List<Cart>)value;

            int totalCost = 0;
            foreach(Cart cart in cartList)
            {
                totalCost += (cart.food.cost - cart.food.cost * cart.food.discount / 100) * cart.soLuong;
            }

            return totalCost.ToString("N0") + "đ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
