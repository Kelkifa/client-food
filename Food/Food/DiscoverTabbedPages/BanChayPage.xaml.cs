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

    public class TestData
    {
        public string image { get; set; }
        public string text { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BanChayPage : ContentPage
    {
        public BanChayPage()
        {
            InitializeComponent();
            InitialData();
        }

        async void InitialData()
        {
            txtLoadNotifice.IsVisible = true;

            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/food/json");
            txtLoadNotifice.IsVisible = false;

            List<Food> foodList = JsonConvert.DeserializeObject<List<Food>>(response);


            if(foodList.Count == 0)
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
            Food selectedFood = (Food)lstBanChay.SelectedItem;
            Navigation.PushAsync(new ChiTietSPPage(selectedFood));
        }
    }
}