using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace Food.ViewModels
{
    public class ViewModelLocator
    {
        private IContainer _container;

        [Preserve]

        public ViewModelLocator()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SliderViewModel>().As<ISliderViewModel>().SingleInstance();

            _container = builder.Build();
        }
        public ISliderViewModel Slider
        {
            get { return _container.Resolve<ISliderViewModel>(); }
        }
    }
}
