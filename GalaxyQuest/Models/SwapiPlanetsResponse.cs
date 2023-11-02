using System.Text.Json.Serialization;

namespace GalaxyQuest.Models
{
    public class SwapiPlanetsResponse
    {
        [JsonPropertyName("results")]
        public List<SwapiPlanet> Results { get; set; }
    }
}
