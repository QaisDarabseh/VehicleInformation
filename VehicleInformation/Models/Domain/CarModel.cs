using System.Text.Json.Serialization;

namespace VehicleInformation.Models.Domain
{
    public class CarModel
    {
        [JsonPropertyName("Make_ID")]
        public int MakeID { get; set; }

        [JsonPropertyName("Make_Name")]
        public string MakeName { get; set; }

        [JsonPropertyName("Model_ID")]
        public int ModelID { get; set; }

        [JsonPropertyName("Model_Name")]
        public string ModelName { get; set; }


    }
}
