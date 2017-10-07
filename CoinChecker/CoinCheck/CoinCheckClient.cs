using CoinCheck.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinCheck
{
    public class CoinCheckClient
    {
        private const int TimeoutMillseconds = 1000;

        private const string BaseUri = "https://coincheck.jp/";

        public async Task<Ticker> GetTicker()
        {
            var client = new SimpleRestClient(BaseUri);

            var response = await client.GetRequest("/api/ticker");

            return JsonConvert.DeserializeObject<Ticker>(response);
        }

        public async Task<OrderBooks> GetOrderBooks()
        {
            var client = new SimpleRestClient(BaseUri);

            var response = await client.GetRequest("/api/order_books");
            
            return JsonConvert.DeserializeObject<OrderBooks>(response);
        }

        public async Task<List<Trade>> GetTrades()
        {
            var client = new SimpleRestClient(BaseUri);

            var response = await client.GetRequest("/api/trades");

            return JsonConvert.DeserializeObject<List<Trade>>(response);
        }

    }
}
