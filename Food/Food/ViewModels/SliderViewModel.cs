using Food.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms.Internals;

namespace Food.ViewModels
{
    public interface ISliderViewModel { }
    public class SliderViewModel :MainViewModel,ISliderViewModel
    {
        private ObservableCollection<SliderModel> _sliders;
        public ObservableCollection<SliderModel> Sliders
        {
            get { return _sliders; }
            set { _sliders = value; OnPropertyChanged(nameof(Sliders)); }
        }
        [Preserve]

        public SliderViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            var sliders = new List<SliderModel>
            {
                new SliderModel {Id = 1, Url="slide1.jpg"},
                new SliderModel {Id = 2, Url="slide2.jpg"},
                new SliderModel {Id = 3, Url="slide3.jpg"},
                new SliderModel {Id = 4, Url="slide4.jpg"},
                new SliderModel {Id = 5, Url="slide5.jpg"},
            };
            Sliders = new ObservableCollection<SliderModel>(sliders);
        }
    }
}
