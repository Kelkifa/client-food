using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.DiscoverTabbedPages
{
    public class TestData
    {
        public string image { get; set; }
        public string text { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class BanChayPage : ContentPage
    {
        public BanChayPage()
        {
            InitializeComponent();
            InitialData();
        }

        void InitialData()
        {
            List<TestData> testData = new List<TestData>();
            testData.Add(new TestData() { image = "https://media-cdn.laodong.vn/Storage/NewsPortal/2021/4/6/896286/Qua-Tao-1.jpg", text = "Test data" });
            testData.Add(new TestData() { image = "https://i.gadgets360cdn.com/products/large/micromax-in-2b-1-414x800-1627626668.jpg?downsize=240:*&output-quality=80&output-format=webp", text = "Test data 2" });
            testData.Add(new TestData() { image = "https://media-cdn.laodong.vn/Storage/NewsPortal/2021/4/6/896286/Qua-Tao-1.jpg", text = "Test data 2" });
            testData.Add(new TestData() { image = "https://media-cdn.laodong.vn/Storage/NewsPortal/2021/4/6/896286/Qua-Tao-1.jpg", text = "Test data 2" });
            testData.Add(new TestData() { image = "https://media-cdn.laodong.vn/Storage/NewsPortal/2021/4/6/896286/Qua-Tao-1.jpg", text = "Test data 2" });
            testData.Add(new TestData() { image = "https://media-cdn.laodong.vn/Storage/NewsPortal/2021/4/6/896286/Qua-Tao-1.jpg", text = "Test data 2" });



            lstBanChay.ItemsSource = testData;
        }

        private void lstBanChay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TestData data = (TestData)lstBanChay.SelectedItem;
            DisplayAlert("Thong bao ", data.text, "OK");
        }
    }
}