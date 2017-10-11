using CoinCheck.Structs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace CoinCheck
{
    public class PublicAPIClient
    {
        private const string BaseUri = "https://coincheck.jp/";

        private HttpClient _client;

        private PublicRestClient _requester;

        public PublicAPIClient()
        {
            _requester = new PublicRestClient(BaseUri);
            _client = new HttpClient();
        }

        public async Task<Ticker> GetTicker()
        {
            var path = "/api/ticker";
            var response = await _requester.GetRequest(_client, path);

            return JsonConvert.DeserializeObject<Ticker>(response);
        }

        public async Task<OrderBooks> GetOrderBooks()
        {
            var path = "/api/order_books";

            var response = await _requester.GetRequest(_client, path);

            return JsonConvert.DeserializeObject<OrderBooks>(response);
        }

        public async Task<List<Trade>> GetTrades()
        {
            var path = "/api/trades";

            var response = await _requester.GetRequest(_client, path);

            return JsonConvert.DeserializeObject<List<Trade>>(response);
        }

        public async Task<OrdersRate> GetOrdersRateByAmount(TradePair pair, OrderType type, double amount)
        {
            var path = "/api/exchange/orders/rate";
            var parameter = new Dictionary<string, string>
            {
                {"order_type", $"{type}" },
                {"pair", $"{pair}"},
                {"amount", $"{amount}"},
            };

            var response = await _requester.GetRequest(_client, path, parameter);

            return JsonConvert.DeserializeObject<OrdersRate>(response);
        }

        public async Task<OrdersRate> GetOrdersRateByPrice(TradePair pair, OrderType type, double price)
        {
            var path = "/api/exchange/orders/rate";
            var parameter = new Dictionary<string, string>
            {
                {"order_type", $"{type}" },
                {"pair", $"{pair}"},
                {"price", $"{price}"},
            };

            var response = await _requester.GetRequest(_client, path, parameter);

            return JsonConvert.DeserializeObject<OrdersRate>(response);
        }
    }
}
