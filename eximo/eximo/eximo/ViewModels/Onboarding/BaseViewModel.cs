using eximo.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace eximo.ViewModels.Onboarding
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isNextBtnVisible;
        private bool _isSkipBtnVisible;
        private int _myCarouselPosition;

        public event PropertyChangedEventHandler PropertyChanged;
        public EximoDataContext EximoDbContext => App._eximoDataContext;

        public bool IsNextBtnVisible 
        {
            get { return _isNextBtnVisible; }
            set { SetProperty(ref _isNextBtnVisible, value); }
        
        }

 
        public bool IsSkipBtnVisible 
        {
            get { return _isSkipBtnVisible; }
            set { SetProperty(ref _isSkipBtnVisible, value); } 
        }

        public int MyCarouselPosition 
        {
            get { return _myCarouselPosition; }
            set { SetProperty(ref _myCarouselPosition, value); } 
        }


        protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName]string propertyName = "",
        Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
