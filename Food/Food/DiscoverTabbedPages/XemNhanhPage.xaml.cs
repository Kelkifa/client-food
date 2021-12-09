using Food.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.DiscoverTabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XemNhanhPage : ContentPage
    {
        public XemNhanhPage()
        {
            InitializeComponent();
            CreateXemNhanh();

            var vm = (SliderViewModel)this.BindingContext;
            vm.LoadData();

            Device.StartTimer(TimeSpan.FromSeconds(3), (Func<bool>)(() =>
            {
                mainSlider.Position = mainSlider.Position < vm.Sliders.Count - 1 ? mainSlider.Position + 1 : 0;
                return true;
            }));
        }

        List<XemNhanh> xemNhanhList = new List<XemNhanh>();

        void CreateXemNhanh()
        {

            // Add MUD
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN1",
                XemNhanhLabel = "Mã Ưu Đãi",
                XemNhanhImage = "MUD.jpg"
            });
            // Add Chopp UD
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN2",
                XemNhanhLabel = "Chopp Ưu Đãi",
                XemNhanhImage = "ChopUD.jpg"
            });
            // Add Moi Moi
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN3",
                XemNhanhLabel = "Mới Mới Mới",
                XemNhanhImage = "Moi.jpg"
            });
            // Add CT
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN4",
                XemNhanhLabel = "Công thức",
                XemNhanhImage = "ChopCT.jpg"
            });
            // Add Chopp BM
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN5",
                XemNhanhLabel = "Chopp Bật Mí",
                XemNhanhImage = "ChopBM.jpg"
            });
            // Add Chopp VIP
            xemNhanhList.Add(new XemNhanh
            {
                XemNhanhID = "XN6",
                XemNhanhLabel = "Chopp VIP",
                XemNhanhImage = "ChopVIP.jpg"
            });

            XemNgay.ItemsSource = xemNhanhList;
        }

        private void XemNgay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(XemNgay.SelectedItem != null)
            {
                XemNhanh xemnhanh = (XemNhanh)XemNgay.SelectedItem;
                Navigation.PushAsync(new MaUuDaiPage(xemnhanh));
            }
        }

    }
}