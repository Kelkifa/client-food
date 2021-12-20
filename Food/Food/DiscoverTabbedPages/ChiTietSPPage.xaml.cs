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
        int soLuong = 1;
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
            txtDes.Text = food.description;
            txtMax.Text = food.maxMass;
            txtMin.Text = food.minMass;
            txtUnit.Text = food.unit;
            txtProd.Text = food.production;
            txtSalePrice.Text = ConvertCost(food.cost - food.cost * food.discount / 100);
            srcImg.Source = food.image;
            Title = food.name;


            txtTotalCost.Text = txtSalePrice.Text;
            txtTotalCount.Text = this.soLuong.ToString();
            txtCost.BindingContext = food;
        }

        private void cmdAddCount_Clicked(object sender, EventArgs e)
        {
            this.soLuong += 1;
            txtTotalCount.Text = this.soLuong.ToString();

            CaculateAndChangeTotalCost();
        }

        private void cmdSubCount_Clicked(object sender, EventArgs e)
        {
            if(this.soLuong <= 1)
            {
                return;
            }

            this.soLuong -= 1;
            txtTotalCount.Text= this.soLuong.ToString();

            CaculateAndChangeTotalCost();
        }

        void CaculateAndChangeTotalCost()
        {
            int cost = this.food.cost * (1 - this.food.discount/100) * this.soLuong;
            txtTotalCost.Text = ConvertCost(cost);
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
                _ = Navigation.PopAsync();
            }
            else
            {
                _ = DisplayAlert("Thong bao", apiResponse.message, "OK");
            }
        }
    }
}