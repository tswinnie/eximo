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
    public class OnboardingViewModel : INotifyPropertyChanged
    {
        public ICommand LastPageViewedCommand { get; set; }
        public ICommand MoveCarouselToNextCommand { get; set; }
        public ICommand SkipToLastPageCommand { get; set; }
        public bool isGetStartedVisible { get; set; }
        public ObservableCollection<Walkthrough> WalkthroughItems { get => Load(); }    
        public event PropertyChangedEventHandler PropertyChanged;


        public OnboardingViewModel()
        {
            LastPageViewedCommand = new Command(ConfigureGetStarted);
            MoveCarouselToNextCommand = new Command<CarouselViewControl>(MoveCarouselToNext);
            SkipToLastPageCommand = new Command<CarouselViewControl>(SkipToLastPage);
            isGetStartedVisible = false;
        }


        private void SkipToLastPage(CarouselViewControl myCarouselRef)
        {
            myCarouselRef.Position = 2;
            
        }

        private void MoveCarouselToNext(CarouselViewControl myCarouselRef)
        {
            myCarouselRef.Position += 1;

            if(myCarouselRef.Position == 2)
            {
                isGetStartedVisible = true;
                //call command method that hides try it out and get started button
            }
        }

        private void ConfigureGetStarted(object obj)
        {
          
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

    
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
