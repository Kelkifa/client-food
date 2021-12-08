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
        }

        List<XemNhanh> xemNhanhList = new List<XemNhanh>();

        void CreateXemNhanh()
        {


            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN1",
                    XemNhanhLabel = "Mã Ưu Đãi",
                    XemNhanhImage = "MUD.jpg"
                });


            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN2",
                    XemNhanhLabel = "Chopp Ưu Đãi",
                    XemNhanhImage = "ChopUD.jpg"
                });

            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN3",
                    XemNhanhLabel = "Mới Mới Mới",
                    XemNhanhImage = "Moi.jpg"
                });

            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN4",
                    XemNhanhLabel = "Công thức",
                    XemNhanhImage = "ChopCT.jpg"
                });
            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN5",
                    XemNhanhLabel = "Chopp Bật Mí",
                    XemNhanhImage = "ChopBM.jpg"
                });
            xemNhanhList.Add(new XemNhanh
                {
                    XemNhanhID = "XN6",
                    XemNhanhLabel = "Chopp VIP",
                    XemNhanhImage = "ChopVIP.jpg"
                });
            

            XemNgay.ItemsSource = xemNhanhList;
        }
    }
}