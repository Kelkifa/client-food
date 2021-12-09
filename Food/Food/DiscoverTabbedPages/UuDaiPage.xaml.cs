using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.DiscoverTabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UuDaiPage : ContentPage
    {
        public UuDaiPage()
        {
            InitializeComponent();
            InitialData();
        }
        async void InitialData()
        {
            txtLoadNotifice.IsVisible = true;

            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/food/json?discount=desc");
            txtLoadNotifice.IsVisible = false;

            List<Food> foodList = JsonConvert.DeserializeObject<List<Food>>(response);


            if (foodList.Count == 0)
            {
                txtEmptyNotifice.IsVisible = true;
            }
            else
            {
                txtEmptyNotifice.IsVisible = false;
            }

            lstBanChay.ItemsSource = foodList;
        }

        private void lstBanChay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}