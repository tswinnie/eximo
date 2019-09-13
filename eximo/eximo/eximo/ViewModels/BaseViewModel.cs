using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace eximo.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _isNextBtnVisible;
        private bool _isSkipBtnVisible;

        public event PropertyChangedEventHandler PropertyChanged;


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
