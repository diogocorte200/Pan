using BancoPan.Domain.Domain.Aggregate.Ibge;
using BancoPan.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BancoPan.Domain.Services
{
    public class IbgeService : IIbgeService
    {
        private readonly ILogger<IbgeService> _logger;
        private readonly HttpClient _httpClient;

        public IbgeService(ILogger<IbgeService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }
        public async Task<List<Municipio>> SearchCounties(int id)
        {
            try
            {
                var strUri = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{id}/municipios";

                var result = await _httpClient.GetAsync(strUri);

                if (result.IsSuccessStatusCode)
                {

                    var resultJson = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Municipio>>(resultJson);
                }
                else
                {
                    _logger.LogInformation($"ViaCepService SearchCounties StatusCode:{result.StatusCode} ID:{id}");
                    return default;
                }

            }
            catch (Exception error)
            {
                _logger.LogError(error, $"ViaCepService SearchCounties ID:{id} {error.Message}");
                throw;
            }
        }

        public async Task<List<Estado>> SearchEstates()
        {
            try
            {
                var strUri = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/";

                var result = await _httpClient.GetAsync(strUri);

                if (result.IsSuccessStatusCode)
                {

                    var resultJson = await result.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Estado>>(resultJson);
                }
                else
                {
                    _logger.LogInformation($"IbgeService SearchEstates StatusCode:{result.StatusCode} ");
                    return default;
                }

            }
            catch (Exception error)
            {
                _logger.LogError(error, $"IbgeService SearchEstates {error.Message}");
                throw;
            }
        }
    }
}
