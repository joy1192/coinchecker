using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CoinCheck
{
    public class PublicRestClient
    {
        private HttpClient _client;

        private Uri _baseUrl;

        public PublicRestClient(string baseUrl)
            : this(new Uri(baseUrl))
        {
        }

        public PublicRestClient(Uri baseUrl)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _client = new HttpClient();
        }

        public virtual async Task<string> GetRequest(string path, Dictionary<string, string> parameters = null)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("resource null or empty.", nameof(path));

            Uri uri = new Uri(this._baseUrl, path);

            // パラメータ有りならば、パラメータを付けたURIを使用する
            if (parameters is Dictionary<string, string> param)
            {
                var content = new FormUrlEncodedContent(param);
                var parameter = await content.ReadAsStringAsync();
                uri = new Uri(this._baseUrl, $"{path}?{parameter}");
            }
            
            var response = await _client.GetAsync(uri);

            // Responseが失敗だった場合、例外を送出
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("status code invalid.");//仮
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
