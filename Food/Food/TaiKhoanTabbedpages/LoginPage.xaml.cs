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

        async void FetchApi(string username, string password)
        {
            var client = new HttpClient { BaseAddress = new Uri("https://xamarin-food.herokuapp.com") };

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            };

            var content = new FormUrlEncodedContent(pairs);

            var response = await client.PostAsync("api/auth/login", content);

            string result = await response.Content.ReadAsStringAsync();

            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);
            if (response.IsSuccessStatusCode)
            {
                if (apiResponse.success == true)
                {
                    DisplayAlert("Thong bao", "Đăng nhâp thành công", "OK");
                    Auth.currUsername = userNameEntry.Text;
                    Navigation.PushAsync(new LoginPage());
                }
                else
                {
                    DisplayAlert("Thong bao", apiResponse.message, "OK");
                }
            }
        }
        private void LogIn_Clicked(object sender, EventArgs e)
        {
            bool flagUsername = IsNotEmptyAndSetNotifi("Bạn chưa nhập trường này", txtUseNotifi, userNameEntry.Text);
            bool flagPassword= IsNotEmptyAndSetNotifi("Bạn chưa nhập trường này", txtPassNoti, passwordEntry.Text);

            if (flagUsername || flagPassword) return;

            FetchApi(userNameEntry.Text, passwordEntry.Text);

        }

        private void Register_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}