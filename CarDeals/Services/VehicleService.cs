using CarDeals.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarDeals.Services
{
   public class VehicleService
    {
        private RestClient _client;

        public VehicleService(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<List<Vehicle>> GetVehicles()
        {
            var request = new RestRequest(ApiConstants.API_VEHICLES, Method.GET);

            IRestResponse response = await _client.ExecuteAsync(request);
            var content = response.Content;
            return JsonConvert.DeserializeObject<List<Vehicle>>(content);
        }

    }
}
