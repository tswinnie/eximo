using eximo.data.Services;
using eximo.Models.ServicePlan;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eximo.ViewModels.Signup
{
    public class SelectPlanViewModel : BaseViewModel
    {
        private IPlanService _planService;

        public ICommand SelectPlan { get; set; }
        public ObservableCollection<Plan> ServicePlans { get => Load(); }

        public SelectPlanViewModel(IPlanService planService)
        {
            _planService = planService;

            SelectPlan = new Command(SavePlanTitle);
        }

        private async void SavePlanTitle(object obj)
        {
            await Application.Current.MainPage.DisplayAlert("User Not Added", "User was not added", "Ok");

        }

        private ObservableCollection<Plan> Load()
        {
            return new ObservableCollection<Plan>(new[]
            {
                new Plan
                {
                    PlanTitle = "Basic",
                    PlanPrice = "$10",
                    PlanFeatures = new List<Feature>()
                    {
                        new Feature{ Name = "Remove your personal information from 50+ websites" },
                        new Feature{ Name ="Locate your personal data" },
                        new Feature{ Name ="Provide detailed reporting of information removed" },
                    }
                },
                new Plan
                {
                    PlanTitle = "Basic Plus",
                    PlanPrice = "$25",
                    PlanFeatures = new List<Feature>()
                    {
                        new Feature{ Name ="Remove your personal data from email marketers" },
                        new Feature{ Name ="Provide monthly scans of sites you've been removed from" },
                        new Feature{ Name ="Provide removal of personal information from 100+ websites for 2 additional user profiles" },
                        new Feature{ Name ="Manual remove of information from tough sites" },
                        new Feature{ Name ="Remove your personal information from 100+ websites" },
                        new Feature{ Name ="Locate your personal data" },
                        new Feature{ Name ="Provide detailed reporting of information removed" },

                    }
                },
                new Plan
                {
                    PlanTitle = "Select",
                    PlanPrice = "$50",
                    PlanFeatures = new List<Feature>()
                    {
                        new Feature{ Name ="Provide monthly privacy reports" },
                        new Feature{ Name ="Provide removal of personal information from 100+ websites for 4 additional user profiles" },
                        new Feature{ Name ="Provide removal of personal information from email marketers for 4 additional user profiles" },
                        new Feature{ Name ="Remove your personal information from 100+ websites" },
                        new Feature{ Name ="Locate your personal data" },
                        new Feature{ Name ="Provide detailed reporting of information removed" },
                        new Feature{ Name ="Remove your personal data from email marketers" },
                        new Feature{ Name ="Provide monthly scans of sites you've been removed from" },
                    }

                },
            });
        }
    }
}
