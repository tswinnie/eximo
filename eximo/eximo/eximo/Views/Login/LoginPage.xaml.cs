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
        }
    }
}