using Newtonsoft.Json;

namespace WoWInfo.Models
{
    public class RaceJson
    {
        [JsonProperty(PropertyName = "races")]
        public Race[] Race { get; set; }
    }
}
