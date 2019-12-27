using eximo.data;
using eximo.data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace eximo.ViewModels.Signup
{
    public class BaseViewModel : INotifyPropertyChanged
    {
      

        public event PropertyChangedEventHandler PropertyChanged;
        public EximoDataContext EximoDbContext => App._eximoDataContext;

        public BaseViewModel()
        {
            
        }


    }
}
