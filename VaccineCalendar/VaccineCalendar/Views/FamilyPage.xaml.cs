using VaccineCalendar.Models;
using VaccineCalendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.StyleSheets;
using System.Reflection;

namespace VaccineCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FamilyPage : ContentPage
	{
        FamilyViewModel viewModel;

		public FamilyPage ()
		{
			InitializeComponent ();
            //<StyleSheet Source="/Vaccine.css" />
            // this.Resources.Add(StyleSheet.FromAssemblyResource(IntrospectionExtensions.GetTypeInfo(typeof(FamilyPage)).Assembly, "VaccineCalendar.Vaccine.css"));


            BindingContext = viewModel = new FamilyViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.FamilyPeople.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void IncluirPessoa_clicked(object sender, EventArgs e)
        {
            Page page = new FamiliPersonPage(viewModel.ResponsibleUser);
            var familyPersonNav = new NavigationPage(page);
            await this.Navigation.PushModalAsync(familyPersonNav);

            //            await Navigation.PushModalAsync(new NavigationPage(new FamiliPersonPage(viewModel.ResponsibleUser)));
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is FamilyPerson person))
                return;
            Page page = new FamiliPersonPage(person);
            var familyPersonNav = new NavigationPage(page);
            await this.Navigation.PushModalAsync(familyPersonNav);
            // await Navigation.PushModalAsync(new NavigationPage(new FamiliPersonPage(person)));

            // Manually deselect item.
            FamilyListView.SelectedItem = null;
        }

    }
}