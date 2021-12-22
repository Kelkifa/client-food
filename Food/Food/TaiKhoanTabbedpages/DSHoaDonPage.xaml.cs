using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.ApiResponseClass;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.TaiKhoanTabbedpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSHoaDonPage : ContentPage
    {
        public DSHoaDonPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetMyOrders();
        }
        private async void GetMyOrders() 
        {
            ApiCall api = new ApiCall();
            OrderResponse orderResponse = await api.fetchGetOrderAsync();
            if(orderResponse.success)
            {
                lstOrder.ItemsSource = orderResponse.response;
            }
            else
            {
                _ = DisplayAlert("Thông báo", orderResponse.message, "OK");
            }
        }

        private void lstOrder_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Order order = new Order();
            order = (Order)lstOrder.SelectedItem;
            Navigation.PushAsync(new ChiTietHoaDonPage(order));
        }
    }
}