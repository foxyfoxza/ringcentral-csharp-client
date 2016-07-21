using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace RingCentral
{
    public partial class RestClient
    {
        private Url GetClient(string endpoint, object queryParams)
        {
            var url = server.AppendPathSegment(endpoint).SetQueryParams(queryParams);
            if (token != null)
            {
                url = url.WithOAuthBearerToken(token.access_token);
            }
            return url;
        }

        public Task<HttpResponseMessage> Get(string endpoint, object queryParams = null)
        {
            return GetClient(endpoint, queryParams).GetAsync();
        }

        public Task<HttpResponseMessage> Post(string endpoint, object requestBody, object queryParams = null)
        {
            return GetClient(endpoint, queryParams).PostJsonAsync(requestBody);
        }

        public Task<HttpResponseMessage> Put(string endpoint, object requestBody, object queryParams = null)
        {
            return GetClient(endpoint, queryParams).PutJsonAsync(requestBody);
        }

        public Task<HttpResponseMessage> Delete(string endpoint, object queryParams = null)
        {
            return GetClient(endpoint, queryParams).DeleteAsync();
        }

        public async Task<T> Get<T>(string endpoint, object queryParams = null)
        {
            var response = await Get(endpoint, queryParams);
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<T> Post<T>(string endpoint, object requestBody, object queryParams = null)
        {
            var response = await Post(endpoint, requestBody, queryParams);
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<T> Put<T>(string endpoint, object requestBody, object queryParams = null)
        {
            var response = await Put(endpoint, requestBody, queryParams);
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}