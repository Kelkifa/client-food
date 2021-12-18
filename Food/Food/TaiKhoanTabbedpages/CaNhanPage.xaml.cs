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
        User user = null;
        public CaNhanPage()
        {
            GetUserInfo();
            InitializeComponent();
            InitView();
            InitUserInfo();
        }

        private void GetUserInfo()
        {
            Database database = new Database();
            List<User> userList = database.GetUser();
            if(userList != null)
            {
                if(userList.Count > 0)
                {
                    this.user = userList[0];
                }
            }
        }

        void InitView()
        {
            if (this.user != null)
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

        private void InitUserInfo()
        {
            if (this.user != null)
            {
                btnAvatar.Text = this.user.username.Substring(0, 1);
                txtUsername.Text = this.user.username;
                txtFullname.Text = this.user.fullname;
                txtDiaChi.Text = this.user.address;
                txtSdt.Text = this.user.sdt;
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