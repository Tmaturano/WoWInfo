using Newtonsoft.Json;

namespace WoWInfo.Models
{
    public class ClassJson
    {
        [JsonProperty(PropertyName = "classes")]
        public Class[] Class { get; set; }
    }
}
