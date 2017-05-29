using Newtonsoft.Json;

namespace WoWInfo.Models
{
    // /WOW/CHARACTER/:REALM/:CHARACTERNAME
    public class Character
    {
        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "realm", NullValueHandling = NullValueHandling.Ignore)]
        public string Realm { get; set; }

        [JsonProperty(PropertyName = "level", NullValueHandling = NullValueHandling.Ignore)]
        public int Level { get; set; }

        [JsonProperty(PropertyName = "class", NullValueHandling = NullValueHandling.Ignore)]
        public int ClassId { get; set; }
                
        public Class Class { get; set; }

        [JsonProperty(PropertyName = "race", NullValueHandling = NullValueHandling.Ignore)]
        public int RaceId { get; set; }

        public Race Race { get; set; }

        [JsonProperty(PropertyName = "gender", NullValueHandling = NullValueHandling.Ignore)]
        public int GenderId { get; set; } //0 male ; 1 female

        public string Gender => GenderId == 0 ? "Male" : "Female";

        [JsonProperty(PropertyName = "totalHonorableKills", NullValueHandling = NullValueHandling.Ignore)]
        public long TotalHonorableKills { get; set; }

        [JsonProperty(PropertyName = "thumbnail", NullValueHandling = NullValueHandling.Ignore)]
        public string Thumbnail { get; set; }
    }
}
