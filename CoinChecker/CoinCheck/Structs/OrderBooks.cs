using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck.Structs
{
    [JsonObject]
    public class OrderBooks
    {
        [JsonProperty("asks")]
        public List<string[]> Asks { get; set; }

        [JsonProperty("bids")]
        public List<string[]> Bids { get; set; }
    }
}
