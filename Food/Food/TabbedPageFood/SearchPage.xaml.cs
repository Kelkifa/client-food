using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.TabbedPageFood
{
    public class TestData
    {
        public string image { get; set; }
        public string text { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }


        private async void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/food/json?s="+inputSearch.Text);

            List<Food> foodList = JsonConvert.DeserializeObject<List<Food>>(response);

            lstProducts.ItemsSource = foodList;
        }
    }
}