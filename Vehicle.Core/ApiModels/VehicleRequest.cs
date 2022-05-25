using System.Text.Json.Serialization;

namespace Vehicle.Core.ApiModels
{
    public class VehicleRequest
    {
        [JsonPropertyName("latitude")]
        public decimal Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public decimal Longitude { get; set; }

        [JsonPropertyName("speed")]
        public int Speed { get; set; }
    }
}
