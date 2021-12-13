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
                lstCart.ItemsSource = cartResponse.response;
            }

        }
    }
}