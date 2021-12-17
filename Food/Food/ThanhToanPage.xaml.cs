
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThanhToanPage : ContentPage
    {
        public ThanhToanPage()
        {
            InitializeComponent();
            InitialData();
        }

        async void InitialData()
        {

            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/auth/register");

            List<Order> OrderList = JsonConvert.DeserializeObject<List<Order>>(response);

            lstOrder.ItemsSource = OrderList;
        }
    }
}