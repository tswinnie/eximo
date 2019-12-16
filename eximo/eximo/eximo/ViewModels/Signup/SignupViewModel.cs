using eximo.core.Models;
using eximo.Views.Login;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels.Signup
{
    public class SignupViewModel : BaseViewModel
    {
        public ICommand ValidateUserSignup { get; set; }
        public ICommand NavigateToLogin { get; set; }

        public SignupViewModel()
        {
            ValidateUserSignup = new Command(CheckIfUserDataIsValid);
            NavigateToLogin = new Command(NavigateToLoginPage);

        }

        private async void NavigateToLoginPage(object obj)
        {
            //navigate to login page
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
        }

        private async void CheckIfUserDataIsValid(object signUpPage)
        {
            var page = signUpPage as ContentPage;

            Entry userName = (Entry)page.Content.FindByName("userName");
            Entry email = (Entry)page.Content.FindByName("email");
            Entry password = (Entry)page.Content.FindByName("password");
            Entry passwordConfirm = (Entry)page.Content.FindByName("passwordConfirm");
            Label userNameErrorText = (Label)page.Content.FindByName("userNameErrorText");
            Label emailErrorText = (Label)page.Content.FindByName("emailErrorText");
            Label passwordErrorText = (Label)page.Content.FindByName("passwordErrorText");
            Label passwordConfirmErrorText = (Label)page.Content.FindByName("passwordConfirmErrorText");
            Label passwordConfirmNoMatch = (Label)page.Content.FindByName("passwordConfirmNoMatch");
            Label emailNotValidErrorText = (Label)page.Content.FindByName("emailNotValidErrorText");




            //check if fields are valid
            if (string.IsNullOrEmpty(userName.Text))
            {
                userNameErrorText.IsVisible = true;
            }

            if (string.IsNullOrEmpty(email.Text) || !IsValidEmail(email.Text) )
            {
                emailErrorText.IsVisible = true;
                emailNotValidErrorText.IsVisible = true;
            }

            if (string.IsNullOrEmpty(password.Text))
            {
                passwordErrorText.IsVisible = true;

            }

            if (string.IsNullOrEmpty(passwordConfirm.Text))
            {
                passwordConfirmErrorText.IsVisible = true;
            }

            if(!string.IsNullOrEmpty(userName.Text) && !string.IsNullOrEmpty(email.Text) 
                && !string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(passwordConfirm.Text) && IsValidEmail(email.Text))
            {
                userNameErrorText.IsVisible = false;
                emailErrorText.IsVisible = false;
                passwordErrorText.IsVisible = false;
                passwordConfirmErrorText.IsVisible = false;
                emailNotValidErrorText.IsVisible = false;

                var newUser = new User();
                try
                {
                    newUser.UserName = userName.Text;
                    newUser.Email = userName.Text;
                    newUser.Password = userName.Text;

                   object[] response = await EximoDbContext.AddUserAsync(newUser);
                    if (response[1].Equals(true))
                    {
                        //navigate to login page
                        await Application.Current.MainPage.Navigation.PushAsync(new LoginPage());
                    }
                    else
                    {
                        //user was not added
                        await Application.Current.MainPage.DisplayAlert("User Not Added", "User was not added", "Ok");
                        userName.Text = String.Empty;
                        password.Text = String.Empty;
                        email.Text = String.Empty;
                        passwordConfirm.Text = String.Empty;


                    }

                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }

            }





        }

        bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
