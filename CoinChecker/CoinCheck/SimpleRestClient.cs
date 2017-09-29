using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<string> GetRequest(string resource)
        {
            var uri = new Uri(this._baseUrl, resource);
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("status code invalid.");//仮
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
