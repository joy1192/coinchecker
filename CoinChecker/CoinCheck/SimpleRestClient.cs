using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CoinCheck
{
    public class SimpleRestClient
    {
        private HttpClient _client;

        private Uri _baseUrl;

        public SimpleRestClient(string baseUrl)
            : this(new Uri(baseUrl))
        {
        }

        public SimpleRestClient(Uri baseUrl)
        {
            _baseUrl = baseUrl ?? throw new ArgumentNullException(nameof(baseUrl));
            _client = new HttpClient();
        }

        public async Task<string> GetRequest(string resource, params (string Key, string Value)[] parameters)
        {
            if (string.IsNullOrEmpty(resource))
                throw new ArgumentException("resource null or empty.", nameof(resource));

            // ?key1=value1&key2=value2&... or empty
            string requestString = string.Empty;
            if (parameters?.Any() is true)
            {
                var paramList = parameters
                        .Select(parameter => $"{parameter.Key}={parameter.Value}")
                        .ToList();

                requestString = $"?{string.Join("&", paramList)}";
            }

            var uri = new Uri(this._baseUrl, resource + requestString);
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
