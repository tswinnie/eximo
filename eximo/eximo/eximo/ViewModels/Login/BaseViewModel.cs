using eximo.data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace eximo.ViewModels.Login
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public EximoDataContext EximoDbContext => App._eximoDataContext;

        public BaseViewModel()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
