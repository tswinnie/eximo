using CommonServiceLocator;
using eximo.ViewModels.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            this.BindingContext = ServiceLocator.Current.GetInstance<LoginPageViewModel>();
            //disable the submit button
            loginButton.IsEnabled = false;
        }

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(userName.Text) || string.IsNullOrEmpty(password.Text))
            {
                //disable the submit button
                loginButton.IsEnabled = false;
            }
            else
            {
                //disable the submit button
                loginButton.IsEnabled = true;
            }


        }

        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(password.Text) || string.IsNullOrEmpty(userName.Text))
            {
                //disable the submit button
                loginButton.IsEnabled = false;
            }
            else
            {
                //disable the submit button
                loginButton.IsEnabled = true;
            }
        }
    }
}