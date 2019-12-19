using CommonServiceLocator;
using eximo.ViewModels.Signup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eximo.Views.SelectPlan
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectPlanPage : ContentPage
    {
        public SelectPlanPage()
        {
            InitializeComponent();
            this.BindingContext = ServiceLocator.Current.GetInstance<SignupViewModel>();
        }

     
    }
}