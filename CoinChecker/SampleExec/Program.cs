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
        static void Main(string[] args)
        {
            var client = new CoinCheckClient();
            var order_books = client.GetOrderBooks();
            var trades = client.GetTrades();

            Console.WriteLine();
        }
    }
}
