using CarouselView.FormsPlugin.Abstractions;
using eximo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels
{
    public class OnboardingViewModel : BaseViewModel
    {
        public ICommand LastPageViewedCommand { get; set; }
        public ICommand MoveCarouselToNextCommand { get; set; }
        public ICommand SkipToLastPageCommand { get; set; }
        public CarouselViewControl _myCarouselRef { get; set; }
        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }    


        public OnboardingViewModel()
        {
            //LastPageViewedCommand = new Command(CheckActiveCarouselPage);
            MoveCarouselToNextCommand = new Command<CarouselViewControl>(MoveCarouselToNext);
            SkipToLastPageCommand = new Command<CarouselViewControl>(SkipToLastPage);
            IsNextBtnVisible = true;
            IsSkipBtnVisible = true;

        }

        private void CheckActiveCarouselPage(object sender)
        {

            if(_myCarouselRef.Position != 2)
            {
                IsNextBtnVisible = true;
                IsSkipBtnVisible = true;
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
                    Image = "onboarding_one.png",
                    IsGetStartedVisible = false,
                    IsTryNowVisible = false,
                
                },
                new Walkthrough
                {
                    Heading = "Pick A Plan",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    Image = "onboarding_two.png",
                    IsGetStartedVisible = false,
                    IsTryNowVisible = false,
             
                },
                new Walkthrough
                {
                    Heading = "Give Authorization",
                    Caption = "Exploer the worlds of mountains from the point of view of who cares!",
                    Image = "onboarding_three.png",
                    IsGetStartedVisible = true,
                    IsTryNowVisible = true,
          
                },
            });
        }

  

    }
}
