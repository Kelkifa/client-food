using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.TaiKhoanTabbedpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CaNhanPage : ContentPage
    {
        public CaNhanPage()
        {
            InitializeComponent();
            InitView();
        }

        void InitView()
        {
            if (ApiCall.userId != null)
            {
                layoutInfo.IsVisible = true;
                layoutAuth.IsVisible = false;
                layoutBottom.IsVisible = true;
            }
            else
            {
                layoutInfo.IsVisible = false;
                layoutAuth.IsVisible = true;
                layoutBottom.IsVisible = false;
            }
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void btnRegister_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void btnMyOrder_Clicked(object sender, EventArgs e)
        {

        }

        private void btnLogOut_Clicked(object sender, EventArgs e)
        {
            ApiCall.userId = null;
            InitView();
            Database database = new Database();
            database.RemoveUser();
        }
    }
}