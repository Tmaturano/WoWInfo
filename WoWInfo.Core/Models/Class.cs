using Newtonsoft.Json;

namespace WoWInfo.Models
{
    //  /WOW/DATA/CHARACTER/CLASSES    
    public class Class
    {
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "powerType", NullValueHandling = NullValueHandling.Ignore)]
        public string PowerType { get; set; }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
