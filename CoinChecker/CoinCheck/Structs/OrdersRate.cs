using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck.Structs
{
    [JsonObject]
    public class OrdersRate
    {
        /// <summary>
        /// always true
        /// </summary>
        [JsonProperty("success")]
        public bool Sussess { get; set; }

        /// <summary>
        /// 注文のレート
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }

        /// <summary>
        /// 注文の金額
        /// </summary>
        [JsonProperty("price")]
        public double Price { get; set; }

        /// <summary>
        /// 注文の量
        /// </summary>
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}
