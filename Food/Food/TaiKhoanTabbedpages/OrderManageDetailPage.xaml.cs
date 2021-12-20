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
            InitData();
        }

        private void InitData()
        {
            lstCart.ItemsSource = this.order.cartList;

            txtId.Text = this.order._id;
            txtFullname.Text = this.order.user.fullname;
            txtAddress.Text = this.order.address;
            txtSdt.Text = this.order.sdt;
            txtCreatedAt.Text = this.order.createdAt;
        }

        private void btnAccept_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDisagree_Clicked(object sender, EventArgs e)
        {

        }
    }
}