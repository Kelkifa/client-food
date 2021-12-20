﻿using Food.ApiResponseClass;
using Newtonsoft.Json;
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
    public partial class OrderManagePage : ContentPage
    {
        public OrderManagePage()
        {
            InitializeComponent();
            GetOrderList();
        }

        private async void GetOrderList()
        {
            ApiCall api = new ApiCall();

            OrderResponse orderResponse = await api.fetchAdminGetOrderAsync();

            if (orderResponse.success)
            {
                lstOrder.ItemsSource = orderResponse.response;
            }

        }
    }
}