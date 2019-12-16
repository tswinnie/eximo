using eximo.core.Models;
using eximo.Views.SelectPlan;
using eximo.Views.SignUp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        public ICommand NavigateToSignUp { get; set; }
        public ICommand ProcessLogin { get; set; }

        public LoginPageViewModel()
        {

            NavigateToSignUp = new Command(NavigateToSignUpPage);
            ProcessLogin = new Command(LoginUser);
        }

        private async void LoginUser(object loginPage)
        {
            var page = loginPage as ContentPage;
            Entry userName = (Entry)page.Content.FindByName("userName");
            Entry password = (Entry)page.Content.FindByName("password");
            Label userNameErrorText = (Label)page.Content.FindByName("userNameErrorText");
            Label passwordErrorText = (Label)page.Content.FindByName("passwordErrorText");
            Label loginFailedErrotText = (Label)page.Content.FindByName("loginFailed");

            if (!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(password.Text))
            {
                userNameErrorText.IsVisible = false;
                passwordErrorText.IsVisible = false;
                loginFailedErrotText.IsVisible = false;

         
                //try to check if the user is a valid user
                try
                {
                    var user = EximoDbContext.Users.Where(u => u.UserName == userName.Text && u.Password == password.Text).FirstOrDefault();
                    if(user != null)
                    {
                        //navigate to dashboard page if the user is not going through the get started process
                        if (user.IsRegistered)
                        {
                            //user has registered and navigate to dashboard page
                            //await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());

                        }
                        else
                        {
                            //user has not registered continue through to pick a plan
                            await Application.Current.MainPage.Navigation.PushAsync(new SelectPlanPage());
                        }

                    }
                    else
                    {
                        //display error msg
                        loginFailedErrotText.IsVisible = true;
                        userNameErrorText.IsVisible = false;
                        passwordErrorText.IsVisible = false;   
                        
                    }

                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }

            }

        }

        private async void NavigateToSignUpPage(object obj)
        {
            await Application.Current.MainPage.Navigation.PushAsync(new SignUpPage());
        }
    }
}
