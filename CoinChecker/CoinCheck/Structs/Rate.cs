using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck.Structs
{
    [JsonObject]
    public class PairRate
    {
        /// <summary>
        /// 注文のレート
        /// </summary>
        [JsonProperty("rate")]
        public double Rate { get; set; }
    }
}
