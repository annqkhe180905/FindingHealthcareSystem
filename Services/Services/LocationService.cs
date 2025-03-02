using BusinessObjects.LocationModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Services.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _httpClient;

        public LocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<City>> GetCities(string proCode)
        {
            var apiUrl = $"https://provinces.open-api.vn/api/d/{proCode}/districts";

            var response = await _httpClient.GetStringAsync(apiUrl);
            var cities = JsonConvert.DeserializeObject<List<City>>(response);

            foreach (var c in cities)
            {
                c.Wards = await GetWards(c.Code);
            }

            return cities;
        }

        public async Task<List<Province>> GetProvinces()
        {
            var apiUrl = "https://provinces.open-api.vn/api/p/";
            var response = await _httpClient.GetStringAsync(apiUrl);
            var provinces = JsonConvert.DeserializeObject<List<Province>>(response);
/*
            foreach (var province in provinces)
            {
                province.Cities = await GetCities(province.Code);
            }*/

            return provinces;
        }

        public Task<List<Ward>> GetWards(string cityCode)
        {
            throw new NotImplementedException();
        }
    }
}
