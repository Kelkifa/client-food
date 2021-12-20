using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietHoaDonPage : ContentPage
    {
        List<Cart> carts = null;
        User user = null;
        Order order;
        public ChiTietHoaDonPage()
        {
            InitializeComponent();
        }
        public ChiTietHoaDonPage(List<Cart> cartList, User usr)
        {
            carts = cartList;
            user = usr;
            InitializeComponent();
        }
        void InitData()
        {
            order.cartList = carts;
            order.user = user;
        }
    }
}