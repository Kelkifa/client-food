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
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        bool IsErrorAndSetNotifice(string notifice, Label notificeLabel, string entryData)
        {
            if(entryData == null)
            {
                notificeLabel.Text = notifice;
                notificeLabel.IsVisible = true;
                return true;
            }
            else
            {
                notificeLabel.IsVisible = false;
                return false;
            }
        }

        private async void SignUp_Clicked(object sender, EventArgs e)
        {
            bool flagUser = IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiUsername, userNameEntry.Text);
            bool flagPassword = IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiPassword, passwordEntry.Text);
            bool flagConfirmPassword = IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiConfiPassword, confirmpasswordEntry.Text);
            bool flagFullName = IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiFullName, fullNameEntry.Text);

            if (flagUser || flagPassword || flagConfirmPassword || flagFullName) return;
            //if (IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiPassword, passwordEntry.Text)) return;
            //if (IsErrorAndSetNotifice("Bạn chưa nhập trường này", txtNotiConfiPassword, confirmpasswordEntry.Text)) return;


            if(passwordEntry.Text != confirmpasswordEntry.Text)
            {
                IsErrorAndSetNotifice("Mật khẩu không khớp", txtNotiConfiPassword, null);
                return;
            }

            ApiCall apiCall = new ApiCall();


            ApiResponse apiResponse = await apiCall.fetchRegisterAsync(
                fullNameEntry.Text, 
                addressEntry.Text, 
                telephoneEntry.Text, 
                userNameEntry.Text, 
                passwordEntry.Text
            );

            _ = DisplayAlert("Thong bao", apiResponse.message, "OK");
                    Navigation.PushAsync(new LoginPage());
            /*
            if (response.IsSuccessStatusCode)
            {
                if(apiResponse.success == true)
                {
                    DisplayAlert("Thong bao", "Đăng ký thành công" , "OK");
                }
                else
                {
                    DisplayAlert("Thong bao", apiResponse.message, "OK");

                }
            }
            */
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginPage());
        }
    }
}