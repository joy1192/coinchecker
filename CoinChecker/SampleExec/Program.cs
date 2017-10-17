﻿using CoinCheck;
using CoinCheck.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleExec
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new PublicAPIClient();
            var order_books = await client.GetOrderBooks();
            var trades = await client.GetTrades();
            var ticker = await client.GetTicker();

            var buy_rate_amount = await client.GetOrdersRateByAmount(TradePair.btc_jpy, OrderType.buy, 1.0);
            var sell_rate_amount = await client.GetOrdersRateByAmount(TradePair.btc_jpy, OrderType.sell, 1.0);
            var buy_rate_price = await client.GetOrdersRateByPrice(TradePair.btc_jpy, OrderType.buy, 1000000);
            var sell_rate_price = await client.GetOrdersRateByPrice(TradePair.btc_jpy, OrderType.sell, 1000000);

            var access = AccessInfomationUtility.GetAccessKey();
            var secret = AccessInfomationUtility.GetSecretAccessKey();

            var privateClient = new PrivateRestClient("https://coincheck.jp/", access, secret);

            System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();
            var result = await privateClient.GetRequest(_client, "/api/accounts/balance");

            Console.WriteLine();
        }
    }
}
