using Food.ApiResponseClass;
using Newtonsoft.Json;
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
        private int totalCost = 0;
        public CartPage()
        {
            InitializeComponent();
            InitFoodList();
        }

        public CartPage(bool isReload)
        {
            InitializeComponent();
            InitFoodList();

            if (isReload)
            {
                var _navigation = Application.Current.MainPage.Navigation;
                var _lastPage = _navigation.NavigationStack.LastOrDefault();
                //Remove last page
                _navigation.RemovePage(_lastPage);

                _navigation.PopAsync();
            }
        }

        string ConvertCost(int cost)
        {
            return cost.ToString("N0") + "đ";
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

            int totalCost = 0;
            amount.Text = "Tổng tiền: " + ConvertCost(totalCost);


        }

        private void Image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

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
                    lstCart.ItemsSource = apiResponse.response;
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

        private int CaculateCost(int cost, int discount, int soLuong)
        {
            return (cost - discount * cost /100) * soLuong;
        }

        private void thanhToanBtn_Clicked(object sender, EventArgs e)
        {
            if (this.cartList == null) return;

            List<Cart> selectedCarts = new List<Cart>();

            foreach(Cart cart in this.cartList)
            {
                if (cart.isChecked) selectedCarts.Add(cart);
            }

            if(selectedCarts.Count == 0)
            {
                DisplayAlert("Thông báo", "Bạn chưa chọn đồ ăn nào", "Đồng ý");
            }

            Navigation.PushAsync(new ThanhToanPage(selectedCarts));
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            int tongTien = 0;
            foreach(Cart cart in this.cartList)
            {
                if (cart.isChecked)
                {
                    tongTien += CaculateCost(cart.food.cost, cart.food.discount, cart.soLuong);
                }
            }
            
            this.totalCost = tongTien;

            amount.Text = "Tổng tiền: " + ConvertCost(this.totalCost);
        }
    }
}