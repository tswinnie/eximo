using CarouselView.FormsPlugin.Abstractions;
using eximo.Models.Onboarding;
using eximo.Views.SignUp;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels.Onboarding
{
    public class OnboardingViewModel : BaseViewModel
    {
        public ICommand LastPageViewedCommand { get; set; }
        public ICommand MoveCarouselToNextCommand { get; set; }
        public ICommand SkipToLastPageCommand { get; set; }
        public CarouselViewControl _myCarouselRef { get; set; }
        public ICommand GetStartedCommand { get; set; }

        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }    


        public OnboardingViewModel()
        {
            LastPageViewedCommand = new Command(CheckActiveCarouselPage);
            MoveCarouselToNextCommand = new Command<CarouselViewControl>(MoveCarouselToNext);
            SkipToLastPageCommand = new Command<CarouselViewControl>(SkipToLastPage);
            IsNextBtnVisible = true;
            IsSkipBtnVisible = true;

        }

   
 

        private void CheckActiveCarouselPage(object obj)
        {

            if(MyCarouselPosition != 2)
            {
                IsNextBtnVisible = true;
                IsSkipBtnVisible = true;
            }
            else
            {
                IsNextBtnVisible = false;
                IsSkipBtnVisible = false;
            }

        }

        private void SkipToLastPage(CarouselViewControl myCarouselRef)
        {
            myCarouselRef.Position = 2;
            IsNextBtnVisible = false;
            IsSkipBtnVisible = false;
            _myCarouselRef = myCarouselRef;
        }

        private void MoveCarouselToNext(CarouselViewControl myCarouselRef)
        {
            myCarouselRef.Position += 1;

            if(myCarouselRef.Position == 2)
            {
                IsNextBtnVisible = false;
                IsSkipBtnVisible = false;
                _myCarouselRef = myCarouselRef;
            }
          
        }

        private void ConfigureGetStarted(PositionSelectedEventArgs carousel)
        {
          if(carousel.NewValue == 2)
            {

            }
        }

        private ObservableCollection<Walkthrough> Load()
        {
            return new ObservableCollection<Walkthrough>(new[]
            {
                new Walkthrough
                {
                    Heading = "Create Profile",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    IsGetStartedVisible = false,
                    IsTryNowVisible = false,
                    CarouselImageSource = "resource://eximo.Resources.Images.Onboarding.CreateProfile.svg"


                },
                new Walkthrough
                {
                    Heading = "Pick A Plan",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    IsGetStartedVisible = false,
                    IsTryNowVisible = false,
                    CarouselImageSource = "resource://eximo.Resources.Images.Onboarding.Payment.svg"


                },
                new Walkthrough
                {
                    Heading = "Give Authorization",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    IsGetStartedVisible = true,
                    IsTryNowVisible = true,
                    CarouselImageSource = "resource://eximo.Resources.Images.Onboarding.Authorization.svg"

                },
            });
        }

  

    }
}
