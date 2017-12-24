using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck.Structs
{
    [JsonObject]
    public class TradeResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty("data")]
        public List<Trade> Data { get; set; }
    }

    [JsonObject]
    public class Pagination
    {
        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("order")]
        public string Order { get; set; }
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

        [JsonProperty("pair")]
        public TradePair Pair { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreateAt { get; set; }
    }
}
