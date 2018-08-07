using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VaccineCalendar.Models;
using VaccineCalendar.Shared;
using VaccineCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;
using Xamarin.Forms.Xaml;
using static VaccineCalendar.ViewModels.SchemaDetailViewModel;

namespace VaccineCalendar.Views
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchemaDetailPage : ContentPage
    {
        SchemaDetailViewModel viewModel;


        public SchemaDetailPage(Schema schema)
        {
            viewModel = new SchemaDetailViewModel(schema);
            try
            {
                this.Resources.Add(StyleSheet.FromAssemblyResource(IntrospectionExtensions.GetTypeInfo(typeof(SchemaDetailPage)).Assembly,
                                                                "VaccineCalendar.Vaccine.css"));
            }
            catch (Exception ex)
            {
               
                throw;
            }
            
            //Content = ContentBuilder();
        }



        private View ContentBuilder()
        {
            var scrollview = new ScrollView();

            var externLayout = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Vertical
            };

            
            externLayout.Children.Add(new Label { Text = "Esquema " + viewModel.SchemaName, StyleClass = new string[] { "PageTitle" } });

            
            foreach (var vaccine in viewModel.GroupByVaccineNameType)
            {
                externLayout.Children.Add(CreateVaccineView(vaccine));
            }
            scrollview.Content = externLayout;
            return scrollview;

        }



        private View CreateVaccineView(VaccineGroupByVaccineType vaccine)
        {


            var internalLayout = new StackLayout
            {
                Spacing = 0,
                Orientation = StackOrientation.Vertical,

                Children =
                {
                    new Label { Text = vaccine.VaccineName, StyleClass = new string[] { "schemaVaccineTitle" } }
                }
            };




            //label2.StyleClass.Add("detailPageTitle");

            bool hasVariants = vaccine.VaccineTypeGroups.Count() > 1;


            foreach (var vaccineSchemaVariant in vaccine.VaccineTypeGroups)
            {
                

                if (hasVariants)
                {
             
                    internalLayout.Children.Add(new Label { Text = "Variante " + vaccineSchemaVariant.Key, StyleClass = new string[] { "schemaVariantTitle" } });
                }

                foreach (var vaccineType in vaccineSchemaVariant)
                {
                    internalLayout.Children.Add(new Label { Text = vaccineType.VaccineTypeName + "  " + vaccineType.DateName, StyleClass = new string[] { "schemaVaccineDate" } });
                }

            }

            return internalLayout;

        }



        protected override async void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                await viewModel.BuildGroups();
                Content = ContentBuilder();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}