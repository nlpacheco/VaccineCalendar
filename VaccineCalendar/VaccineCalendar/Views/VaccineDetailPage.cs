using VaccineCalendar.Models;
using VaccineCalendar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
//    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class VaccineDetailPage : ContentPage
    {
        public VaccineDetailViewModel viewModel;

        public VaccineDetailPage(Vaccine vaccine)
        {
            //InitializeComponent();
            //BindingContext = viewModel = new VaccineDetailViewModel(vaccine);
            viewModel = new VaccineDetailViewModel(vaccine);
            Content = ContentBuilder(vaccine);
        }

        private View ContentBuilder(Vaccine vaccine)
        {
            var scrollview = new ScrollView();
            var mainsStackLayout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children =
                {
                    // Dados da vacina
                    new StackLayout
                    {
                        Spacing = 0,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new StackLayout
                            {
                                Orientation= StackOrientation.Horizontal,
                                Children =
                                {
                                    new Label { Text = "Vacina:", FontSize = 12 },
                                    new Label { Text = vaccine.Name, FontSize = 12}
                                }
                            },
                            new Label { Text = "Descrição:", FontSize = 12 },
                            new Label { Text = vaccine.Description, FontSize = 10 },
                        }

                    }
                }
            };

            var tipoVacinaStackLayout = new StackLayout
            {
                Padding = 10,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            foreach (var vacType in vaccine.VaccineTypes)
            {
                tipoVacinaStackLayout.Children.Add(
                    new StackLayout
                    {
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            new Label { Text = vacType.Name, FontSize=12},
                            new Label { Text = vacType.Description, FontSize=12}
                        }
                    });

            }

            mainsStackLayout.Children.Add(tipoVacinaStackLayout);

            scrollview.Content = mainsStackLayout;
            return scrollview;
        }
    }
}