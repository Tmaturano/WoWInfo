using Newtonsoft.Json;

namespace WoWInfo.Models
{
    //   /WOW/DATA/CHARACTER/RACES
    public class Race
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "side", NullValueHandling = NullValueHandling.Ignore)]
        public string Faction { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
