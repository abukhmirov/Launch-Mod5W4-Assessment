using System.Text.Json.Serialization;

namespace GalaxyQuest.Models
{
    public class SwapiPlanet
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("population")]
        public string Population { get; set; }
    }
}
