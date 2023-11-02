using GalaxyQuest.Models;
using GalaxyQuest.Interfaces;
using System.Text.Json;

namespace GalaxyQuest.Services
{
    public class MilkyWayGalaxy : IMilkyWayGalaxy
    {
        private static readonly HttpClient _httpClient;

        static MilkyWayGalaxy()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://swapi.dev/api/")
            };
        }



        static public List<Planet> Planets = new List<Planet>() {
            new Planet() { Name = "Mercury", Population = 1 },
            new Planet() { Name = "Venus", Population = 2 },
            new Planet() { Name = "Earth", Population = 7_888_000_000 },
            new Planet() { Name = "Mars", Population = 3 },
            new Planet() { Name = "Jupiter", Population = 1 },
            new Planet() { Name = "Saturn", Population = 1 },
            new Planet() { Name = "Uranus", Population = 0 },
            new Planet() { Name = "Neptune", Population = 0 }
        };

         async Task<List<Planet>> IMilkyWayGalaxy.PlanetsIndex()
        {
            string apiEndpoint = "/planets";
            var response = await _httpClient.GetAsync(apiEndpoint);
            response.EnsureSuccessStatusCode();
            var planetsJson = await response.Content.ReadAsStringAsync();

            var swapiResponse = System.Text.Json.JsonSerializer.Deserialize<SwapiPlanetsResponse>(planetsJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var result = new List<Planet>();

            if (swapiResponse?.Results != null)
            {
                foreach (var swapiPlanet in swapiResponse.Results)
                {
                    
                    bool isPopulationNumeric = long.TryParse(swapiPlanet.Population, out long population);

                    result.Add(new Planet
                    {
                        Name = swapiPlanet.Name,
                        Population = isPopulationNumeric ? population : 0 
                    });
                }
            }

            return result;
        }
    }
}
