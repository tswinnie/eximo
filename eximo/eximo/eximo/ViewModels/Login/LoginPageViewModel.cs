using eximo.Views.SignUp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand NavigateToSignUp { get; set; }
        public LoginPageViewModel()
        {

            NavigateToSignUp = new Command(NavigateToSignUpPage);

        }

        private async void NavigateToSignUpPage(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}
