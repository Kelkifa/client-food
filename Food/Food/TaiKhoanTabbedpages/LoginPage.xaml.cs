using Food.ApiResponseClass;
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

namespace Food.TaiKhoanTabbedpages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        bool IsNotEmptyAndSetNotifi(string notifi, Label notiLabel, string entryData)
        {
            if(entryData == null)
            {
                notiLabel.Text = notifi;
                notiLabel.IsVisible = true;
                return true;
            }
            else
            {
                notiLabel.IsVisible = false;
                return false;
            }
        }

        private async void LogIn_Clicked(object sender, EventArgs e)
        {
            bool flagUsername = IsNotEmptyAndSetNotifi("Bạn chưa nhập trường này", txtUseNotifi, userNameEntry.Text);
            bool flagPassword= IsNotEmptyAndSetNotifi("Bạn chưa nhập trường này", txtPassNoti, passwordEntry.Text);

            if (flagUsername || flagPassword) return;

            ApiCall apiCall = new ApiCall();
            LoginRes apiResponse = await apiCall.FetchLoginAsync(userNameEntry.Text, passwordEntry.Text);

            if(apiResponse.success == true)
            {
                Database database = new Database();
                if (database.AddUser(apiResponse.response)){
                ApiCall.userId = apiResponse.response._id;
                _ = DisplayAlert("Thong bao", "Đăng nhập thành công", "OK");
                _ = Navigation.PushAsync(new TabbedPageContainer());
                }
                else
                {
                    _ = DisplayAlert("Thong bao", "Đăng nhập không thành công", "OK");
                }
            }
            else
            {
                _ = DisplayAlert("Thong bao", apiResponse.message, "OK");
            }
        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}