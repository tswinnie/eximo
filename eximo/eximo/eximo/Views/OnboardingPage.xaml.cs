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


      


    }
}