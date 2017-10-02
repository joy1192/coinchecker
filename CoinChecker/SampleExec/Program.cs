using CoinCheck;
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
            var client = new CoinCheckClient();
            var order_books = await client.GetOrderBooks();
            var trades = await client.GetTrades();

            Console.WriteLine();
        }
    }
}
