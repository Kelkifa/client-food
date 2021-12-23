using Food.DiscoverTabbedPages;
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
    public partial class listProductNganhHangPage : ContentPage
    {
        List<Food> foodList = new List<Food>();
        String titleNH;
        public listProductNganhHangPage(List<Food> selectedFood, String title)
        {
            foodList = selectedFood;
            this.titleNH = title;
            InitializeComponent();
            InitialData();
        }
        void InitialData()
        {
            txtLoadNotifice.IsVisible = false;
            txtTitle.Title = this.titleNH;

            if (foodList.Count == 0)
            {
                txtEmptyNotifice.IsVisible = true;
            }
            else
            {
                txtEmptyNotifice.IsVisible = false;
            }

            lstProductNganhHang.ItemsSource = foodList;
        }

        private void lstProductNganhHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Food selectedFood = (Food)lstProductNganhHang.SelectedItem;
            Navigation.PushAsync(new ChiTietSPPage(selectedFood));
        }
    }
}