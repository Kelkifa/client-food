using Food.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Food.TabbedPageFood
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NganhHangTabbedPage : ContentPage
    {
        List<Food> foodList = new List<Food>();
        public NganhHangTabbedPage()
        {
            InitializeComponent();
            CreateNganhHangCollection();
            Init();
        }

        List<NganhHang> nganhHangList = new List<NganhHang>();

        void CreateNganhHangCollection()
        {
            nganhHangList.Add(new NganhHang { _id = "rau củ", name_NganhHang = "RAU CỦ", img_NganhHang = "RC.jpg" });
            nganhHangList.Add(new NganhHang { _id = "thịt tươi sống", name_NganhHang = "THỊT TƯƠI SỐNG", img_NganhHang = "TTS.jpg" });
            nganhHangList.Add(new NganhHang { _id = "trái cây", name_NganhHang = "TRÁI CÂY", img_NganhHang = "TC.jpg" });
            nganhHangList.Add(new NganhHang { _id = "hải sản", name_NganhHang = "HẢI SẢN", img_NganhHang = "HS.jpg" });
            nganhHangList.Add(new NganhHang { _id = "đồ uống", name_NganhHang = "ĐỒ UỐNG", img_NganhHang = "DU.jpg" });
            nganhHangList.Add(new NganhHang { _id = "trứng sữa", name_NganhHang = "TRỨNG SỮA", img_NganhHang = "TS.jpg" });

            lstNganhHang.ItemsSource = nganhHangList;
        }

        async void Init()
        {
            HttpClient http = new HttpClient();

            string response = await http.GetStringAsync("https://xamarin-food.herokuapp.com/api/food/json");

            foodList = JsonConvert.DeserializeObject<List<Food>>(response);

            
        }

        private void lstNganhHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NganhHang selectedNganhHang = (NganhHang)lstNganhHang.SelectedItem;
            List<Food> foods = foodList.Where(x => x.type == selectedNganhHang._id).ToList();

            Navigation.PushAsync(new listProductNganhHangPage(foods, selectedNganhHang.name_NganhHang));
        }
    }
}