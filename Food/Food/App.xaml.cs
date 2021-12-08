using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabbedPageContainer());
            InitStyleNavigationBar();
            
        }

        void InitStyleNavigationBar()
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            navigationPage.BarBackgroundColor = Color.Yellow;
            navigationPage.BarBackgroundColor = Color.FromHex("#fff688");


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
