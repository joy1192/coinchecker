using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck
{
    [JsonObject]
    public class Ticker
    {
        /// <summary>
        /// 最後の取引の価格
        /// </summary>
        [JsonProperty("last")]
        public string Last { get; set; }

        /// <summary>
        /// 現在の買い注文の最高価格
        /// </summary>
        [JsonProperty("bid")]
        public string Bid { get; set; }

        /// <summary>
        ///  現在の売り注文の最安価格
        /// </summary>
        [JsonProperty("ask")]
        public string Ask { get; set; }

        /// <summary>
        /// 24時間での最高取引価格
        /// </summary>
        [JsonProperty("high")]
        public string High { get; set; }

        /// <summary>
        /// 24時間での最安取引価格
        /// </summary>
        [JsonProperty("low")]
        public string Low { get; set; }

        /// <summary>
        ///  24時間での取引量
        /// </summary>
        [JsonProperty("volume")]
        public string Volume { get; set; }

        /// <summary>
        /// 現在の時刻
        /// </summary>
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
    }
}