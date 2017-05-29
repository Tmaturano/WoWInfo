using System.Collections.Generic;
using System.Threading.Tasks;
using WoWInfo.Models;

namespace WoWInfo.Services
{
    public interface IBattleNetApi
    {
        Task<Character> GetCharacterProfileByNameAndRealm(string name, string realm);
        Task<RaceJson> GetCharacterRaces();
        Task<ClassJson> GetCharacterClasses();
    }
}
