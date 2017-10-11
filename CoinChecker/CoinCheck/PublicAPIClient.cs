using CoinCheck.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoinCheck
{
    public class PublicAPIClient
    {
        private const int TimeoutMillseconds = 1000;

        private const string BaseUri = "https://coincheck.jp/";

        public PublicAPIClient()
        {
        }

        public async Task<Ticker> GetTicker()
        {
            var client = new PublicRestClient(BaseUri);

            var response = await client.GetRequest("/api/ticker");

            return JsonConvert.DeserializeObject<Ticker>(response);
        }

        public async Task<OrderBooks> GetOrderBooks()
        {
            var client = new PublicRestClient(BaseUri);

            var response = await client.GetRequest("/api/order_books");
            
            return JsonConvert.DeserializeObject<OrderBooks>(response);
        }

        public async Task<List<Trade>> GetTrades()
        {
            var client = new PublicRestClient(BaseUri);

            var response = await client.GetRequest("/api/trades");

            return JsonConvert.DeserializeObject<List<Trade>>(response);
        }

        public async Task<OrdersRate> GetOrdersRateByAmount(TradePair pair, OrderType type, double amount)
        {
            var client = new PublicRestClient(BaseUri);

            var response = await client.GetRequest("/api/exchange/orders/rate", ("order_type", $"{type}".ToLower()), ("pair", $"{pair}".ToLower()), ("amount", $"{amount}"));

            return JsonConvert.DeserializeObject<OrdersRate>(response);
        }

        public async Task<OrdersRate> GetOrdersRateByPrice(TradePair pair, OrderType type, double price)
        {
            var client = new PublicRestClient(BaseUri);

            var response = await client.GetRequest("/api/exchange/orders/rate", ("order_type", $"{type}".ToLower()), ("pair", $"{pair}".ToLower()), ("price", $"{price}"));

            return JsonConvert.DeserializeObject<OrdersRate>(response);
        }
    }
}
