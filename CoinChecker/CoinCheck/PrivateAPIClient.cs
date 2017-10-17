using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck
{
    public class PrivateAPIClient
    {
        private const int TimeoutMillseconds = 1000;

        private const string BaseUri = "https://coincheck.jp/";

        /// <summary>
        /// coincheck上で生成したアクセスキー
        /// </summary>
        public string AccessKey { get; }

        /// <summary>
        /// coincheck上で生成した秘密キー
        /// </summary>
        public string AccessSecret { get; }

        public PrivateAPIClient(string accessKey)
        {
            this.AccessKey = accessKey;
        }
    }
}
