using eximo.data;
using eximo.Models;
using eximo.Services;
using eximo.Views;
using eximo.Views.Onboarding;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo
{
    public partial class App : Application
    {
        public static EximoDataContext EximoDataContext;

        public Repo Repository { get; }

        public App(string dbPath)
        {
            Debug.WriteLine($"Database located at: {dbPath}");
            new EximoDataContext(dbPath);
            
            //init IOC Container
            IocContainer.Initialize();

            InitializeComponent();
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
