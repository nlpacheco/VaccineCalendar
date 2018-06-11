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
	public partial class SchemaDetailPage : ContentPage
	{
        SchemaDetailViewModel viewModel;


        public SchemaDetailPage(Schema schema)
        {
            InitializeComponent();
            BindingContext = viewModel = new SchemaDetailViewModel(schema);

        }



        private View ContentBuilder()
        {
            var scrollview = new ScrollView();
            var mainsStackLayout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    new ListView
                    {
                        ItemsSource = viewModel.GroupByVaccine,
                        IsGroupingEnabled = true,
                        GroupDisplayBinding = new Binding("Heading"),
                        GroupShortNameBinding  = new Binding("Heading"),
                        HasUnevenRows = true
                    }


                }
            };


            scrollview.Content = mainsStackLayout;
            return scrollview;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.BuildGroups();
            SchemaList.BeginRefresh();
            SchemaList.ItemsSource = viewModel.GroupByVaccine;
            SchemaList.EndRefresh();

        }

    }
}