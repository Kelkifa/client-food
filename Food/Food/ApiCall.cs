using Food.ApiResponseClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Food
{

    class ApiCall
    {
        public static string userId = null;

        private string baseUrl = "https://xamarin-food.herokuapp.com/";
        public HttpClient client = new HttpClient();

        public HttpRequestMessage httpRequestMessage = null;

        public async Task<LoginRes> FetchLoginAsync(string username, string password)
        {
            string url = "api/auth/login";

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            HttpRequestMessage message = SetMessage("post", content, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            LoginRes apiResponse = JsonConvert.DeserializeObject<LoginRes>(result);
            return apiResponse;
        }

        public async Task<ApiResponse> fetchRegisterAsync(string username, string password)
        {
            string url = "api/auth/register";

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            HttpRequestMessage message = SetMessage("post", content, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);
            return apiResponse;
        }

        internal void FetchAddCart(int soLuong, string foodId)
        {
            throw new NotImplementedException();
        }

        public async Task<CartResponse> fetchCartAsync()
        {
            string url = "api/cart/get";

            HttpRequestMessage message = SetMessage("get", null, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            CartResponse apiResponse = JsonConvert.DeserializeObject<CartResponse>(result);
            return apiResponse;
        }

        public async Task<ApiResponse> fetchAddToCartAsync(int soLuong, string foodId)
        {
            string url = "api/cart/add";

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("food", foodId),
                new KeyValuePair<string, string>("soLuong", soLuong.ToString()),
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            HttpRequestMessage message = SetMessage("get", content, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            ApiResponse apiResponse = JsonConvert.DeserializeObject<CartResponse>(result);

            return apiResponse;

        }

        public async Task<CartResponse> fetchRemoveCartListAsync(List<String> cartIdList)
        {
            string url = "api/cart/remove";

            var jsonData = JsonConvert.SerializeObject(cartIdList);

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("cartIdList", jsonData),
            };

            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            HttpRequestMessage message = SetMessage("post", content, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            CartResponse apiResponse = JsonConvert.DeserializeObject<CartResponse>(result);

            return apiResponse;

        }

        public async Task<ApiResponse> fetchCreateOrderAsync(List<Cart> cartList, string address, string sdt)
        {
            string url = "api/order/create";

            string jsonCartList = JsonConvert.SerializeObject(cartList);

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("cartList", jsonCartList),
                new KeyValuePair<string, string>("address", address),
                new KeyValuePair<string, string>("sdt", sdt),
            };
            FormUrlEncodedContent content = new FormUrlEncodedContent(pairs);

            HttpRequestMessage message = SetMessage("post", content, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(result);

            return apiResponse;
        }

        public async Task<OrderResponse> fetchGetOrderAsync()
        {
            string url = "api/order/get";

            HttpRequestMessage message = SetMessage("get", null, url);

            var response = this.client.SendAsync(message).Result;

            string result = await response.Content.ReadAsStringAsync();

            OrderResponse apiResponse = JsonConvert.DeserializeObject<OrderResponse>(result);

            return apiResponse;
        }

        public HttpRequestMessage SetMessage(string method, FormUrlEncodedContent content, string url )
        {
            return new HttpRequestMessage
            {
                Method = method == "post" ? HttpMethod.Post : HttpMethod.Get,
                RequestUri = new Uri(this.baseUrl + url),
                Headers = {
                    { HttpRequestHeader.Authorization.ToString(), "Bearer " + userId },
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "X-Version", "1" }
                },
                Content = content
            };
        }

    }
}
