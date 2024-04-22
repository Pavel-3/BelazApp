using BelazApp.Models;
using BelazApp.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BelazApp.Services
{
    class VehicleService : IVehicleService
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task<ObservableCollection<DateTime>> GetAllDatesForVehicleAsync(string id)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"https://localhost:7051/api/GetRecordingTime?id={id}");
            return JsonSerializer.Deserialize<ObservableCollection<DateTime>>(result, options);
        }
        public async Task<ObservableCollection<BasicVehicleInfo>> GetBasicVehiclesAsync()
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync("https://localhost:7051/api/GetAllVehicle");
            return JsonSerializer.Deserialize<ObservableCollection<BasicVehicleInfo>>(result, options);
        }

        public async Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"https://localhost:7051/api/GetDetailedVehicle?id={id}");
            return JsonSerializer.Deserialize<DetailedVehicleInfo>(result, options);
        }

        public async Task<DetailedVehicleInfo> GetDetailedVehicleInfoAsync(string id, DateTime time)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"https://localhost:7051/api/GetDetailedVehicle?id={id}");
            return JsonSerializer.Deserialize<DetailedVehicleInfo>(result, options);
        }

        public async Task<ObservableCollection<VehicleReport>> GetVehicleReportsAsync(string id)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync($"https://localhost:7051/api/GetVehicleReport?id={id}");
            return JsonSerializer.Deserialize<ObservableCollection<VehicleReport>>(result, options);
        }
    }
}
