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
            
        }
    }
}