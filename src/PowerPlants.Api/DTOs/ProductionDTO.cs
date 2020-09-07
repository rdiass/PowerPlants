using System.Text.Json.Serialization;

namespace PowerPlants.Api.DTOs
{
    public class ProductionDTO
    {
        [JsonPropertyName("name")]
        public string NamePowerPlant { get; set; }
        [JsonIgnore]
        public double PricePerUnit { get; set; }
        [JsonPropertyName("p")]
        public double TotalEnergy { get; set; }
        [JsonIgnore]
        public double TotalPrice { get; set; }
    }
}
