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

            for (int i = 0; i < viewModel.GenderArray.Length; i++)
                GenderPicker.Items.Add(viewModel.GenderArray[i]);

            foreach (var schemaName in viewModel.SchemaNamesAvailable)
            {
                SchemaPicker.Items.Add(schemaName);
            }
            BindingContext = viewModel;
        }
        private async void Save_Clicked(object sender, EventArgs e)
        {
            viewModel.ExecuteSaveItemCommand();
            await this.Navigation.PopModalAsync();

        }

        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync();

        }
    }
}