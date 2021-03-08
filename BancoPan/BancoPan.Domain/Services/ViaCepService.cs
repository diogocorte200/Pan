using BancoPan.Domain.Domain.Aggregate;
using BancoPan.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BancoPan.Domain.Services
{
    public class ViaCepService : IViaCepService
    {
        private readonly ILogger<ViaCepService> _logger;
        private readonly HttpClient _httpClient;

        public ViaCepService(ILogger<ViaCepService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        
        public async Task<ViaCep> SearchAddress(string cep)
        {
            try
            {
                var strUri = $"https://viacep.com.br/ws/{cep}/json";

                var result = await _httpClient.GetAsync(strUri);

                if (result.IsSuccessStatusCode)
                {

                    var resultJson = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ViaCep>(resultJson);
                }
                else
                {
                    _logger.LogInformation($"ViaCepService StatusCode:{result.StatusCode} Cep:{cep}");
                    return default;
                }
                    
            }
            catch (Exception error)
            {
                _logger.LogError(error, $"ViaCepService Cep:{cep}");
                throw;
            }
        }
    }
}
