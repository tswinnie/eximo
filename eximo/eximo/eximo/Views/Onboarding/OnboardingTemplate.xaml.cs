using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eximo.Views.SignUp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo.Views.Onboarding
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingTemplate : ContentView
    {
        public OnboardingTemplate()
        {
            InitializeComponent();
        }


        private async void GetStarted_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new SignUpPage());

        }

    
    }
}