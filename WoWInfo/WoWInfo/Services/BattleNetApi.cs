using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WoWInfo.Models;
using Xamarin.Forms;

[assembly: Dependency(typeof(WoWInfo.Services.BattleNetApi))]
namespace WoWInfo.Services
{
    public class BattleNetApi : IBattleNetApi
    {
        private const string BaseUrl = "https://us.api.battle.net/wow/";
        private const string WowInfoBattleNetApiKey = "zeq6gebfq2z57zxqbnvfm5s7yz685nw5";
        public async Task<ClassJson> GetCharacterClasses()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //var json = await httpClient.GetStringAsync($"{BaseUrl}data/character/classes?locale=en_US&apikey={WowInfoBattleNetApiKey}").ConfigureAwait(false);
            //var converted = JsonConvert.DeserializeObject<ClassJson>(json);
                                 
            var response = await httpClient.GetAsync($"{BaseUrl}data/character/classes?locale=en_US&apikey={WowInfoBattleNetApiKey}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<ClassJson>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<Character> GetCharacterProfileByNameAndRealm(string name, string realm)
        {            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{BaseUrl}character/{realm}/{name}?locale=en_US&apikey={WowInfoBattleNetApiKey}").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<Character>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<RaceJson> GetCharacterRaces()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await httpClient.GetAsync($"{BaseUrl}data/character/races?locale=en_US&apikey={WowInfoBattleNetApiKey}").ConfigureAwait(false); 
            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<RaceJson>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
    }
}
