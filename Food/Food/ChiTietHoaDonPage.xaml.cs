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
        Order order;
        public ChiTietHoaDonPage()
        {
            InitializeComponent();
            InitData();
        }
        public ChiTietHoaDonPage(Order ord)
        {
            order = ord;
            InitializeComponent();
            InitData();
        }
        void InitData()
        {
            txtAddr.Text = order.address;
            txtDate.Text = order.createdAt;
            txtName.Text = order.user.fullname;
            txtPhone.Text = order.user.sdt;
            txtBillId.Text = "Mã Đơn: " + order._id;
            txtTotalCost.Text = ConvertCost(TotalCostFunc(true));
            txtTotalCost1.Text = ConvertCost(TotalCostFunc(false));
            
            txtTotalDiscount.Text = "-" + ConvertCost(TotalDiscountFunc());
            collectionData.ItemsSource = order.cartList;
        }
        int TotalCostFunc(bool check)
        {
            int totalCost = 0;
            if (order.cartList != null && check == true) 
            {
                //totalCost with discount
                totalCost = order.cartList.Sum(x => (x.food.cost - (x.food.cost * x.food.discount / 100)) * x.soLuong);
            }
            else if (order.cartList != null && check == false)
            {
                //totalCost without discount
                totalCost = order.cartList.Sum(x => x.food.cost * x.soLuong);
            }
            return totalCost;
        }
        int TotalDiscountFunc()
        {
            int total = 0;
            if (order.cartList != null)
            {
                total = order.cartList.Sum(x => x.food.cost * x.food.discount / 100  * x.soLuong);
            }
            return total;
        }
        string ConvertCost(int cost)
        {
            return cost.ToString("N0") + "đ";
        }
    }
}