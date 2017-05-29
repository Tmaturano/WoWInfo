using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WoWInfo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private bool _isBusy;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {                
                SetProperty(ref _isBusy, value);
            }
        }

        public BaseViewModel()
        {
            IsBusy = false;
        }

        /// <summary>
        /// Método para facilitar o desenvolvimento, setando o valor e propagando a alteração (se tiver) 
        /// </summary>
        /// <param name="storage">valor do backend field (os private _)</param>
        /// <param name="value">Valor da property mesmo</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            //se teve alteração no valor propaga, senão não propaga
            //EqualityComparer serve justamente caso algum parâmetro venha null
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }                
    }
}
