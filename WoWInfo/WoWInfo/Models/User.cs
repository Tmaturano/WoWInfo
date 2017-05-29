using Newtonsoft.Json;

namespace WoWInfo.Models
{
    public class User
    {
        //Install-package azure mobile client sdk
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }
}
