using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineCalendar.Models;
using VaccineCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FamiliPersonPage : ContentPage
	{
        FamilyPersonViewModel viewModel;

		public FamiliPersonPage(User responsibleUser)
		{
			InitializeComponent ();
            viewModel = new FamilyPersonViewModel(responsibleUser);
            BindingContext = viewModel;
		}

        public FamiliPersonPage(FamilyPerson familyPerson)
        {
            InitializeComponent();
            viewModel = new FamilyPersonViewModel(familyPerson);
            BindingContext = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await((NavigationPage)(this.Parent)).PopAsync();
        }
    }
}