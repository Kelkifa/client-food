using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.TaiKhoanTabbedpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderManageDetailPage : ContentPage
    {
        private Order order = null;
        public OrderManageDetailPage(Order order)
        {
            this.order = order;
            InitializeComponent();
            InitTotalCostAndDiscount();
            InitData();
        }

        private void InitData()
        {
            collectionData.ItemsSource = this.order.cartList;

            txtName.Text = this.order.user.fullname;
            txtAddr.Text = this.order.address;
            txtDate.Text = this.order.createdAt;
            txtPhone.Text = this.order.sdt;
            
        }

        private void InitTotalCostAndDiscount()
        {
            int totalCost = 0;
            int totalDiscount = 0;
            foreach(Cart cart in this.order.cartList)
            {
                totalCost += cart.food.cost * cart.soLuong;
                totalDiscount += CaculateDiscount(cart.food.cost, cart.food.discount, cart.soLuong);
            }
            txtTotalCost.Text = (totalCost - totalDiscount).ToString("N0") + " đ";
            txtTotalCost1.Text = totalCost.ToString("N0") + " đ";
            txtTotalDiscount.Text = totalDiscount.ToString("N0") + " đ";
        }

        private int CaculateCost(int cost, int discount, int soLuong)
        {
            return (cost - cost * discount / 100) * soLuong;
        }
        private int CaculateDiscount(int cost, int discount, int soLuong)
        {
            return (cost * discount * soLuong) / 100 ;
        }
 

        private async void btnAgree_Clicked(object sender, EventArgs e)
        {
            ApiCall api = new ApiCall();
            ApiResponse apiResponse = await api.fetchOrderAcceptAsync(this.order._id, true);

            if (apiResponse.success)
            {
                _ = DisplayAlert("Thông báo", "Đơn hàng đã được xác nhận", "OK");
            }
            else
            {
                _ = DisplayAlert("Thông báo", apiResponse.message, "OK");
            }
        }

        private async void btnDisagree_Clicked(object sender, EventArgs e)
        {
            ApiCall api = new ApiCall();
            ApiResponse apiResponse = await api.fetchOrderAcceptAsync(this.order._id, false);
            if (apiResponse.success)
            {
                _ = DisplayAlert("Thông báo", "Đơn hàng đã được từ chối", "OK");
            }
            else
            {
                _ = DisplayAlert("Thông báo", apiResponse.message, "OK");
            }
        }
    }
}