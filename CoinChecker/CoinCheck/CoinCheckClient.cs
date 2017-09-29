using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CoinCheck
{
    public class CoinCheckClient
    {
        private const int TimeoutMillseconds = 1000;

        private const string BaseUri = "https://coincheck.jp/";

        public OrderBooks GetOrderBooks()
        {
            var client = new SimpleRestClient(BaseUri);

            var response = client.GetRequest("/api/order_books");

            if (!response.Wait(TimeoutMillseconds))
                throw new TimeoutException();

            return JsonConvert.DeserializeObject<OrderBooks>(response.Result);
        }

        public List<Trade> GetTrades()
        {
            var client = new SimpleRestClient(BaseUri);

            var response = client.GetRequest("/api/trades");

            if (!response.Wait(TimeoutMillseconds))
                throw new TimeoutException();

            return JsonConvert.DeserializeObject<List<Trade>>(response.Result);
        }
    }
}
