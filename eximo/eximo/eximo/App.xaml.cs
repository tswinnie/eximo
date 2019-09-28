using eximo.Services;
using eximo.Views;
using eximo.Views.Onboarding;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //init IOC Container
            IocContainer.Initialize();
            MainPage = new NavigationPage(new OnboardingPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
