using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/food/json");

            List<Food> foodList = JsonConvert.DeserializeObject<List<Food>>(response);


            //DisplayAlert("Thong bao", response, "OK");

            lstBanChay.ItemsSource = foodList;
        }

        private void lstBanChay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TestData data = (TestData)lstBanChay.SelectedItem;
            DisplayAlert("Thong bao ", data.text, "OK");
        }
    }
}