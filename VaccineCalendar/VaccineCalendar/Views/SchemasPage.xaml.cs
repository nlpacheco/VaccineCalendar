using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using VaccineCalendar.Models;
using VaccineCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchemasPage : ContentPage
    {
        SchemasViewModel viewModel;
       

        public SchemasPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new SchemasViewModel();
            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.VaccineSchemas.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void MyListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Schema schema = e.SelectedItem as Schema;
            if (schema == null)
                return;

            Page page = new SchemaDetailPage(schema);
            var schemaDetailNav = new NavigationPage(page);
            await this.Navigation.PushAsync(schemaDetailNav);

            ((ListView)sender).SelectedItem = null;

        }
    }
}
