using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food.ApiResponseClass;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DSHoaDonPage : ContentPage
    {
        public DSHoaDonPage()
        {
            InitializeComponent();
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
        }

        private void lstOrder_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Order order = new Order();
            order = (Order)lstOrder.SelectedItem;
            Navigation.PushAsync(new ChiTietHoaDonPage(order));
        }
    }
}