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
    public partial class ThanhToanPage : ContentPage
    {
        List<Cart> cartList = new List<Cart>();
        User user = new User();
        public ThanhToanPage()
        {
            InitializeComponent();
        }

        public ThanhToanPage(List<Cart> cartList)
        {
            this.cartList = cartList;
            GetUserInfo();
            InitializeComponent();
            InitData();
        }

        void InitData()
        {
            entryFullname.Text = user.fullname;
            entryAddress.Text = user.address;
            entrySdt.Text = user.sdt;
        }
        public void GetUserInfo()
        {
            Database database = new Database();

            List<User> storedUserList = database.GetUser();
            if(storedUserList != null)
            {
                if(storedUserList.Count != 0)
                {
                    this.user = storedUserList[0];
                }
            }
        }

        private async void btnThanhToan_Clicked(object sender, EventArgs e)
        {
            ApiCall api = new ApiCall();

            List<string> cartIdList = new List<string>();
            foreach(Cart cart in this.cartList)
            {
                cartIdList.Add(cart._id);
            }
            ApiResponse apiResponse = await api.fetchCreateOrderAsync(cartIdList, entryAddress.Text, entrySdt.Text);

            if (apiResponse.success)
            {
                _ = DisplayAlert("Thông báo", "Đặt hàng thành công", "OK");
                _ = Navigation.PopAsync();
            }
            else
            {
                _ = DisplayAlert("Thông báo", apiResponse.message, "OK");
            }
        }
    }
}