using VaccineCalendar.Models;
using VaccineCalendar.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VaccineListViewPage : ContentPage
    {
        NavigationPage navigationPage;

        NavigationPage GetNavigationPage
        {
            get
            {
                if (navigationPage == null)
                {
                    navigationPage = new NavigationPage(this);
                }
                return navigationPage;
                //if (!(App.Current.MainPage is NavigationPage))
                //    App.Current.MainPage = new NavigationPage(App.Current.MainPage);
                //return App.Current.MainPage as NavigationPage;
            }           
        }

        public ObservableCollection<string> Vaccines { get; set; }

        VaccineViewModel viewModel;

        public VaccineListViewPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new VaccineViewModel();
            //VaccineListView.ItemsSource = Items;
            IsBusy = false;

        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        async void AddNewItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Add Item", "Add button clicked.", "OK");
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Vaccine vaccine))
                return;

            Page page = new VaccineDetailPage(vaccine);
            var vaccineDetailNav = new NavigationPage(page);
            await this.Navigation.PushAsync(vaccineDetailNav);
         
            //vaccineDetailNav.PushAsync()
            //IsPresented = false;

            //await viewModel.OpenVaccineDetail(new VaccineViewModel.Parametro(2,vaccine));
            //            await GetNavigationPage.PushAsync(new VaccineDetailPage(vaccine));

            // Manually deselect item.
            VaccineListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Vaccines.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

    }
}
