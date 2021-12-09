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
    public partial class MaUuDaiPage : ContentPage
    {
        public MaUuDaiPage()
        {
            InitializeComponent();
        }

        public MaUuDaiPage(XemNhanh xemnhanh)
        {
            InitializeComponent();
            Title = xemnhanh.XemNhanhLabel;
            InitializeMUD(xemnhanh);
        }

        void InitializeMUD(XemNhanh xemNhanh1)
        {
            List<XemNhanhInfo> xemNhanhLst = new List<XemNhanhInfo>();

            //MUD
            if(xemNhanh1.XemNhanhID == "XN1")
            {
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "MUD1",
                    XemNhanhInfoLabel = "Mã Giảm 15k",
                    XemNhanhInfoImage = "MUD1.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "MUD2",
                    XemNhanhInfoLabel = "Miễn phí dịch vụ",
                    XemNhanhInfoImage = "MUD2.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "MUD3",
                    XemNhanhInfoLabel = "Giảm 10%",
                    XemNhanhInfoImage = "MUD3.jpg"
                });
            }

            // Moi
            if (xemNhanh1.XemNhanhID == "XN3")
            {
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi1",
                    XemNhanhInfoLabel = "Tưng bừng khai trương 48%",
                    XemNhanhInfoImage = "Moi1.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi2",
                    XemNhanhInfoLabel = "Tưng bừng khai trương 33%",
                    XemNhanhInfoImage = "Moi2.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi3",
                    XemNhanhInfoLabel = "Ưu đãi 15%",
                    XemNhanhInfoImage = "Moi3.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi4",
                    XemNhanhInfoLabel = "Ưu đãi 10%",
                    XemNhanhInfoImage = "Moi4.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi5",
                    XemNhanhInfoLabel = "Ưu đãi 30%",
                    XemNhanhInfoImage = "Moi5.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi6",
                    XemNhanhInfoLabel = "Quà tặng",
                    XemNhanhInfoImage = "Moi6.jpg"
                });
                xemNhanhLst.Add(new XemNhanhInfo
                {
                    XemNhanhInfoID = "Moi7",
                    XemNhanhInfoLabel = "Thực phẩm mới",
                    XemNhanhInfoImage = "Moi7.jpg"
                });
            }
        }

    }
}