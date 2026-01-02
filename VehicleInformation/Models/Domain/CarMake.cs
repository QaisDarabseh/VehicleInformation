using System.Text.Json.Serialization;

namespace VehicleInformation.Models.Domain
{


    public class CarMake
    {
        [JsonPropertyName("Make_ID")]
        public int MakeID { get; set; }

        [JsonPropertyName("Make_Name")]
        public string MakeName { get; set; }
    }


}
