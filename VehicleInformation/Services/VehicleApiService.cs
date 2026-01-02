using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;
using VehicleInformation.Models.Domain;
using VehicleInformation.Models.Helpers;
using VehicleInformation.Services.Interfaces;

namespace VehicleInformation.Services
{
    public class VehicleApiService : IVehicleApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<VehicleApiOptions> _option;

        private readonly ILogger<VehicleApiService> _logger;

        public VehicleApiService(HttpClient httpClient, ILogger<VehicleApiService> logger ,IOptions<VehicleApiOptions> options )
        {
            _httpClient = httpClient;
            _logger = logger;
            _option = options; 
        }



        public async Task<IEnumerable<CarMake>> GetAllMakesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_option.Value.BaseUrl}getallmakes?format=json");
                response.EnsureSuccessStatusCode();
                var APIResult = await response.Content.ReadFromJsonAsync<ApiResponse<CarMake>>();
                return APIResult.Results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching makes");
                return Enumerable.Empty<CarMake>();
            }
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesForMakeAsync(int makeId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_option.Value.BaseUrl}GetVehicleTypesForMakeId/{makeId}?format=json");
                response.EnsureSuccessStatusCode();
                var APIResult = await response.Content.ReadFromJsonAsync<ApiResponse<VehicleType>>();
                return APIResult.Results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching vehicle types");
                return Enumerable.Empty<VehicleType>();
            }
        }

        public async Task<IEnumerable<CarModel>> GetModelsAsync(int makeId, int year)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_option.Value.BaseUrl}GetModelsForMakeIdYear/makeId/{makeId}/modelyear/{year}?format=json");
                response.EnsureSuccessStatusCode();
                var APIResult = await response.Content.ReadFromJsonAsync<ApiResponse<CarModel>>();
                // Parse and map to DTOs
                return APIResult.Results;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching models");
                return Enumerable.Empty<CarModel>();
            }
        }
    }

}
