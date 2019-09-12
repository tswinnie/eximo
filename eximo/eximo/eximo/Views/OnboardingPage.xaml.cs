using eximo.Models;
using eximo.ViewModels;
using eximo.Views.Onboarding;
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



        public OnboardingPage()
        {
            InitializeComponent();
            this.BindingContext = new OnboardingViewModel();

      
        }

    
        private void OnboardingWalkThrough_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {


            //if(e.NewValue == 2)
            //{
            //    nextButton.IsVisible = false;
             

            //}
        }

        private void AddTryAndGetStartedBTN()
        {
            Button newButton = new Button { Text = "New Button" };

            // Creating a binding
            //newButton.SetBinding(Button.CommandProperty, new Binding("ViewModelProperty"));

            // Set the binding context after SetBinding method calls for performance reasons
            //newButton.BindingContext = viewModel;

            // Set StackLayout in XAML to the class field
            var parent = onboardingWalkThrough;

            // Add the new button to the StackLayout
            //parent.Children.Add(newButton);
        }
    }
}