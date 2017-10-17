using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            this.AccessKey = accessKey;
            this.AccessSecret = accessSecret;
        }

        public override async Task<string> GetRequest(HttpClient client, string path, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("path null or empty.", nameof(path));
            
            Uri uri = new Uri(this._baseUrl, path);

            string nonce = CreateNonce();


            // パラメータ有りならば、パラメータを付けたURIを使用する
            if (parameters is Dictionary<string, string> param)
            {
                var content = new FormUrlEncodedContent(param);
                var parameter = await content.ReadAsStringAsync();
                uri = new Uri(this._baseUrl, $"{path}?{parameter}");
            }

            string signature = CreateSignature(this.AccessSecret, nonce, uri);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("ACCESS-KEY", this.AccessKey);
            client.DefaultRequestHeaders.Add("ACCESS-NONCE", nonce);
            client.DefaultRequestHeaders.Add("ACCESS-SIGNATURE", signature);

            var response = await client.GetAsync(uri);

            // Responseが失敗だった場合、例外を送出
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("status code invalid.");//仮
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// 暗号化通信用に使用するランダム値を生成します
        /// TODO: 生成ロジックを分離する
        /// </summary>
        /// <returns></returns>
        private static string CreateNonce()
        {
            // coincheckにおいてはTimestampを使用
            return $"{DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
        }

        /// <summary>
        /// SIGNATUREは、ACCESS-NONCE, リクエスト先URL, リクエストのボディ を全て文字列にし連結したものを、
        /// HMAC-SHA256 hash形式でシークレットキーを使って署名した結果です。
        /// quote: https://coincheck.com/ja/documents/exchange/api#private
        /// </summary>
        /// <param name="accessSecret"></param>
        /// <param name="nonce"></param>
        /// <param name="requestUrl"></param>
        /// <returns></returns>
        private static string CreateSignature(string accessSecret, string nonce, Uri requestUrl)
        {
            var rawSecret = Encoding.UTF8.GetBytes(accessSecret);

            string message = $"{nonce}{requestUrl}";
            var rawMessage = Encoding.UTF8.GetBytes(message);

            byte[] hash = new HMACSHA256(rawSecret).ComputeHash(rawMessage);

            return BitConverter.ToString(hash).ToLower().Replace("-", "");
        }
    }
}
