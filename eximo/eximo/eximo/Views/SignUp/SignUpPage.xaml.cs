using CommonServiceLocator;
using eximo.ViewModels.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo.Views.SignUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = ServiceLocator.Current.GetInstance<SignupViewModel>();
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(userName.Text))
            {
                userNameErrorText.IsVisible = true;
            }
            else
            {
                userNameErrorText.IsVisible = false;
            }

        }

        private void email_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(email.Text))
            {
                emailErrorText.IsVisible = true;

            }
            else if (!IsValidEmail(email.Text))
            {
                emailNotValidErrorText.IsVisible = true;

            }
            else
            {
                emailErrorText.IsVisible = false;
                emailNotValidErrorText.IsVisible = false;
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


        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text))
            {
                passwordErrorText.IsVisible = true;
            }
            else
            {
                passwordErrorText.IsVisible = false;
            }

            if (!string.Equals(password.Text, passwordConfirm.Text))
            {
                passwordConfirmNoMatch.IsVisible = true;
            }
            else
            {
                passwordConfirmNoMatch.IsVisible = false;
            }
        }

        private void passwordConfirm_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!string.Equals(password.Text, passwordConfirm.Text))
            {
                passwordConfirmNoMatch.IsVisible = true;
            }
            else
            {
                passwordConfirmNoMatch.IsVisible = false;
            }

            if (string.IsNullOrEmpty(passwordConfirm.Text))
            {
                passwordConfirmErrorText.IsVisible = true;
            }
            else
            {
                passwordConfirmErrorText.IsVisible = false;
            }

        }
    }
}