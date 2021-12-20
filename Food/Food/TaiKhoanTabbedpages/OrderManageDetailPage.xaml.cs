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
        
        private void btnAccept_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDisagree_Clicked(object sender, EventArgs e)
        {

        }
    }
}