using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck.Structs
{
    public enum OrderType
    {
        Unknows,
        Buy,
        Sell
    }

    [JsonObject]
    public class Trade
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("rate")]
        public int Rate { get; set; }

        [JsonProperty("order_type")]
        public OrderType OrderType { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreateAt { get; set; }
    }
}
