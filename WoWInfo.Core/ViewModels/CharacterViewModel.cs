using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoWInfo.Helpers;
using WoWInfo.Models;
using WoWInfo.Services;
using Xamarin.Forms;

namespace WoWInfo.ViewModels
{
    public class CharacterViewModel : BaseViewModel
    {
        #region Properties and variables
        private readonly IBattleNetApi _battleNetApi;

        private string _nameToSearch;

        public string NameToSearch
        {
            get { return _nameToSearch; }
            set
            {
                SetProperty(ref _nameToSearch, value);
                SearchCharacterCommand.ChangeCanExecute();
            }
        }

        private string _realmToSearch;

        public string RealmToSearch
        {
            get { return _realmToSearch; }
            set
            {
                SetProperty(ref _realmToSearch, value);
                SearchCharacterCommand.ChangeCanExecute();
            }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);                
            }
        }

        private string _realm;

        public string Realm
        {
            get { return _realm; }
            set
            {
                SetProperty(ref _realm, value);
            }
        }

        private int _level;

        public int Level
        {
            get { return _level; }
            set
            {
                SetProperty(ref _level, value);
            }
        }

        #region Class
        private string _className;

        public string ClassName
        {
            get { return _className; }
            set
            {
                SetProperty(ref _className, value);
            }
        }

        private string _powerType;

        public string PowerType
        {
            get { return _powerType; }
            set
            {
                SetProperty(ref _powerType, value);
            }
        }

        #endregion

        #region Race

        private string _raceName;

        public string RaceName
        {
            get { return _raceName; }
            set
            {
                SetProperty(ref _raceName, value);
            }
        }

        private string _faction;

        public string Faction
        {
            get { return _faction; }
            set
            {
                SetProperty(ref _faction, value);
            }
        }

        #endregion

        private string _gender;

        public string Gender
        {
            get { return _gender; }
            set
            {
                SetProperty(ref _gender, value);
            }
        }

        private long _totalHonorableKills;

        public long TotalHonorablekills
        {
            get { return _totalHonorableKills; }
            set
            {
                SetProperty(ref _totalHonorableKills, value);
            }
        }

        private string _avatarUrl;

        public string AvatarUrl
        {
            get { return _avatarUrl; }
            set
            {
                SetProperty(ref _avatarUrl, value);
            }
        }

        private bool _isGridCharacterInfoVisible;

        public bool IsGridCharacterInfoVisible
        {
            get { return _isGridCharacterInfoVisible; }
            set
            {
                SetProperty(ref _isGridCharacterInfoVisible, value);
            }
        }

        private bool _isMessageVisible;

        public bool IsMessageVisible
        {
            get { return _isMessageVisible; }
            set
            {
                SetProperty(ref _isMessageVisible, value);
            }
        }
        
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        #endregion

        public Command SearchCharacterCommand { get; }

        public CharacterViewModel()
        {
            Message = string.Empty;
            IsBusy = false;
            IsGridCharacterInfoVisible = false;
            _battleNetApi = DependencyService.Get<IBattleNetApi>();
            SearchCharacterCommand = new Command(ExecuteSearchCharacterCommandAsync, CanExecuteSearchCharacterCommand);
        }

        #region Methods

        private bool CanExecuteSearchCharacterCommand()
        {
            return !string.IsNullOrWhiteSpace(NameToSearch) && !string.IsNullOrWhiteSpace(RealmToSearch);
        }

        private async void ExecuteSearchCharacterCommandAsync()
        {
            try
            {
                IsBusy = true;
                Message = string.Empty;                
                IsGridCharacterInfoVisible = false;
                var characterInfo = await _battleNetApi.GetCharacterProfileByNameAndRealm(NameToSearch, RealmToSearch);

                if (characterInfo == null)
                {
                    Message = "Char or Realm not found";
                    IsMessageVisible = true;
                    IsBusy = false;
                    return;
                }

                IsMessageVisible = false;
                Level = characterInfo.Level;
                Name = characterInfo.Name;
                Realm = characterInfo.Realm;

                var thumbnailProfile = characterInfo.Thumbnail.Replace("avatar", "profilemain");
                AvatarUrl = $"{Settings.UrlRenderCharacter}/{thumbnailProfile}";

                var classes = await GetClasses();
                ClassName = classes.Class.Where(a => a.Id == characterInfo.ClassId).FirstOrDefault()?.Name;
                PowerType = classes.Class.Where(a => a.Id == characterInfo.ClassId).FirstOrDefault()?.PowerType;

                var races = await GetRaces();
                RaceName = races.Race.Where(r => r.Id == characterInfo.RaceId).FirstOrDefault()?.Name;
                Faction = races.Race.Where(r => r.Id == characterInfo.RaceId).FirstOrDefault()?.Faction;

                Gender = characterInfo.Gender;
                TotalHonorablekills = characterInfo.TotalHonorableKills;

                IsGridCharacterInfoVisible = true;

            }
            catch (Exception ex)
            {
                //Log

            }

            IsBusy = false;
        }

        private async Task<ClassJson> GetClasses()
        {
            try
            {
                return await _battleNetApi.GetCharacterClasses();
            }
            catch (Exception ex)
            {
                //Log                
            }

            return null;
        }

        private async Task<RaceJson> GetRaces()
        {
            try
            {
                return await _battleNetApi.GetCharacterRaces();
            }
            catch (Exception ex)
            {
                //Log
            }

            return null;
        }


        #endregion
    }
}
