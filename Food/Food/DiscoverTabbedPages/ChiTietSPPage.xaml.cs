using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Food.DiscoverTabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChiTietSPPage : ContentPage
    {
        Food food;
        public ChiTietSPPage()
        {
            InitializeComponent();
            DataInit();
        }
        public ChiTietSPPage(Food selectedFood)
        {
            food = selectedFood;
            InitializeComponent();
            DataInit();
        }
        void DataInit()
        {
            txtName.Text = food.name;
            txtCost.Text = ConvertCost(food.cost);
            txtDes.Text = food.description;
            txtMax.Text = food.maxMass;
            txtMin.Text = food.minMass;
            txtUnit.Text = food.unit;
            txtProd.Text = food.production;
            srcImg.Source = food.image;
            Title = food.name;

            txtTotalCount.Text = "1";
            txtTotalCost.Text = ConvertCost(food.cost);
        }

        private void cmdAddCount_Clicked(object sender, EventArgs e)
        {
            txtTotalCount.Text = (int.Parse(txtTotalCount.Text) + 1).ToString();
            txtTotalCost.Text = ConvertCost(int.Parse(txtTotalCount.Text) * food.cost);
        }

        private void cmdSubCount_Clicked(object sender, EventArgs e)
        {
            txtTotalCount.Text = (int.Parse(txtTotalCount.Text) - 1).ToString();
            txtTotalCost.Text = ConvertCost(int.Parse(txtTotalCount.Text) * food.cost);
        }

        string ConvertCost(int cost)
        {
            return cost.ToString("N0") + "đ";
        }

        private async void cmdAddToCart_Clicked(object sender, EventArgs e)
        {
            int soLuong = int.Parse(txtTotalCount.Text);
            string foodId = this.food._id;

            ApiCall api = new ApiCall();

            ApiResponse apiResponse = await api.fetchAddToCartAsync(soLuong, foodId);

            if (apiResponse.success)
            {
                _ = DisplayAlert("Thong bao", "Thêm thành công", "OK");
            }
            else
            {
                _ = DisplayAlert("Thong bao", apiResponse.message, "OK");
            }
        }
    }
}