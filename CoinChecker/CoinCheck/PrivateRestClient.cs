using System;
using System.Collections.Generic;
using System.Text;

namespace CoinCheck
{
    public class PrivateRestClient : PublicRestClient
    {
        /// <summary>
        /// coincheck上で生成したアクセスキー
        /// </summary>
        public string AccessKey { get; }

        /// <summary>
        /// coincheck上で生成した秘密キー
        /// </summary>
        public string AccessSecret { get; }

        public PrivateRestClient(string baseUrl, string accessKey, string accessSecret) : base(baseUrl)
        {
        }
    }
}
