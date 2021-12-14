using Food.ApiResponseClass;
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
    public partial class CartPage : ContentPage
    {

        List<Cart> cartList = null;
        public CartPage()
        {
            InitializeComponent();
            InitFoodList();
        }

        async void InitFoodList()
        {
            ApiCall api = new ApiCall();

            CartResponse cartResponse = await api.fetchCartAsync();
            if (cartResponse.success)
            {
                this.cartList = cartResponse.response;
                lstCart.ItemsSource = this.cartList;
            }
            
        }

        private void Image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void btnCheck_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Thong baos", cartList[0].isChecked ? "checked":"not checked", "OK");
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            List<String> selectedCartId = new List<string>();
            
            foreach(Cart cart in this.cartList)
            {
                if (cart.isChecked) selectedCartId.Add(cart._id);
            }
            

            if (selectedCartId.Count != 0)
            {
                ApiCall api = new ApiCall();

                CartResponse apiResponse = await api.fetchRemoveCartListAsync(selectedCartId);

                if (apiResponse.success)
                {
                    _ = DisplayAlert("Thong bao", "Xóa thành công", "OK");
                    _ = Navigation.PushAsync(new CartPage());
                }
                else
                {
                    _ = DisplayAlert("Thông báo", apiResponse.message, "OK");
                }
            }
            else
            {
                _ = DisplayAlert("Thông báo", "Bạn chưa chọn food để xoá", "OK");
            }


        }
    }
}