using Microsoft.AspNetCore.Components;
using RatesAPI.Core.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RatesAPI.Core.Services
{
    public class RatesOperations : IRatesOperations
    {
        public IHttpClientFactory _httpClientFactory { get; set; }
        private readonly JsonSerializerOptions _options;
        public RatesOperations(IHttpClientFactory factory)
        {
            _httpClientFactory = factory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<LatestRatesResponse> GetLatestRatesAsync()
        {
            var httpCLient = _httpClientFactory.CreateClient();
            httpCLient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var uri = "http://data.fixer.io/api/latest?access_key=0f165f8d380e1a16c7cb9d90a727cc79";
           

            var response = await httpCLient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            var rates = await JsonSerializer.DeserializeAsync<LatestRatesResponse>(stream, _options);

            return rates;

        }
    }
}
