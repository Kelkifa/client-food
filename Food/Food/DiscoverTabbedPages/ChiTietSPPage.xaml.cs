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
            txtCost.Text = food.cost.ToString();
            txtDes.Text = food.description;
            txtMax.Text = food.maxMass;
            txtMin.Text = food.minMass;
            txtUnit.Text = food.unit;
            txtProd.Text = food.production;
            srcImg.Source = food.image;
            Title = food.name;

            txtTotalCount.Text = "1";
            txtTotalCost.Text = food.cost.ToString();
        }
        private void cmdAddToCart_Clicked(object sender, EventArgs e)
        {
            // Add to cart handle
        }

        private void cmdAddCount_Clicked(object sender, EventArgs e)
        {
            txtTotalCount.Text = (int.Parse(txtTotalCount.Text) + 1).ToString();
            txtTotalCost.Text = (int.Parse(txtTotalCount.Text) * food.cost).ToString();
        }

        private void cmdSubCount_Clicked(object sender, EventArgs e)
        {
            txtTotalCount.Text = (int.Parse(txtTotalCount.Text) - 1).ToString();
            txtTotalCost.Text = (int.Parse(txtTotalCount.Text) * food.cost).ToString();
        }
    }
}