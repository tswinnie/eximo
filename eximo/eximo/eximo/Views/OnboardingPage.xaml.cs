using eximo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnboardingPage : ContentPage
    {
        public Timer timer;
        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }
        public OnboardingPage()
        {
            InitializeComponent();
            this.BindingContext = this;

          
        }

        protected override void OnAppearing()
        {
            //timer = new Timer(TimeSpan.FromSeconds(5).TotalMilliseconds) { AutoReset = true, Enabled = true };
            //timer.Elapsed += Timer_Elapsed;         
            base.OnAppearing();

        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {

                if(onboardingWalkThrough.Position == 2)
                {
                    onboardingWalkThrough.Position = 0;
                    
                    return;
                }

                onboardingWalkThrough.Position += 1;

            });
        }

        protected override void OnDisappearing()
        {
            timer?.Dispose();
            base.OnDisappearing();
        }

        private ObservableCollection<Walkthrough> Load()
        {
            return new ObservableCollection<Walkthrough>(new[]
            {
                new Walkthrough
                {
                    Heading = "Create Profile",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    Image = "onboarding_one.png"
                },
                new Walkthrough
                {
                    Heading = "Pick A Plan",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    Image = "onboarding_two.png"
                },
                new Walkthrough
                {
                    Heading = "Give Authorization",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    Image = "onboarding_three.png"
                },
            });
        }

        private void GetStartedButton_Clicked(object sender, EventArgs e)
        {
            var ButtonClickHandler = (Button)sender;
            StackLayout parentStackLayout = (StackLayout)ButtonClickHandler.Parent;
            Button getStartedBTN = (Button)parentStackLayout.Children[0];
            getStartedBTN.IsVisible = false;
        }

        private void TryOut_Clicked(object sender, EventArgs e)
        {

        }

        private void NextButton_Clicked(object sender, EventArgs e)
        {

             
                if (onboardingWalkThrough.Position == 2)
                {
                    //var ButtonClickHandler = (Button)sender;
                    //StackLayout parentStackLayout = (StackLayout)ButtonClickHandler.Parent;
                    //StackLayout Sibling = (StackLayout)parentStackLayout.;
                    //StackLayout firstChildStackLayout = (StackLayout)ParentGridofStackLayout.Children[0];
                    //Button getStartedBTN = (Button)firstChildStackLayout.Children[0];
                    //getStartedBTN.IsVisible = true;

                }

                onboardingWalkThrough.Position += 1;

        }
    }
}