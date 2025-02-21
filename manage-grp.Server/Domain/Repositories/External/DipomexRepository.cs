using manage_grp.Server.Domain.Interfaces.External;
using manage_grp.Server.DTOs.External;
using manage_grp.Server.DTOs;
using Newtonsoft.Json;
using System;

namespace manage_grp.Server.Domain.Repositories.External
{
    public class DipomexRepository : IDipomexRepository
    {
        public async Task<IEnumerable<StateDipomexDto>> GetAllStatesAsync(string url, string apiKey)
        {           
            try
            {
                using HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("APIKEY", apiKey);

                string responseData = await client.GetStringAsync(url);

                var response = JsonConvert.DeserializeObject<DipomexApiResponse>(responseData);

                return response?.Estados ?? new List<StateDipomexDto>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la petición: {e.Message}");

                return new List<StateDipomexDto>(); 
            }
        }


        public async Task<IEnumerable<MunicipalityDipomexDto>> GetAllMunicipalitiesByStateIdAsync(string url, string apiKey, string stateId)
        {
            using HttpClient client = new HttpClient();

            try
            {
                client.DefaultRequestHeaders.Add("APIKEY", apiKey);

                string requestUrl = $"{url}?id_estado={stateId}";

                string responseData = await client.GetStringAsync(requestUrl);

                var response = JsonConvert.DeserializeObject<DipomexApiResponse>(responseData);

                return response?.Municipios ?? new List<MunicipalityDipomexDto>();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la petición: {e.Message}");

                return new List<MunicipalityDipomexDto>();
            }
        }        
    }
}
