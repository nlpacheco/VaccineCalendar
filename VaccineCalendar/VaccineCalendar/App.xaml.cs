using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using VaccineCalendar.Shared.NavController;
using VaccineCalendar.Views;
using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Services.DalcFile;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace VaccineCalendar
{
    public partial class App : Application

    {
        public static App Instance => (App)Current;
        public readonly INavigationService NavigationService;
        public readonly INavController NavController;

        public App()
        {
            InitializeComponent();

            var labelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter{Property = Label.FontFamilyProperty, Value = (Device.RuntimePlatform == Device.Android ? "Candara.ttf#Candara" :
                                                                            (Device.RuntimePlatform == Device.iOS ? "Candara" : null)) }
                }
            };
            var entryStyle = new Style(typeof(Entry))
            {
                Setters =
                {
                    new Setter{Property = Label.FontFamilyProperty, Value = (Device.RuntimePlatform == Device.Android ? "Candara.ttf#Candara" :
                                                                            (Device.RuntimePlatform == Device.iOS ? "Candara" : null)) }
                }
            };
            var cellStyle = new Style(typeof(Cell))
            {
                Setters =
                {
                    new Setter{Property = Label.FontFamilyProperty, Value = (Device.RuntimePlatform == Device.Android ? "Candara.ttf#Candara" :
                                                                            (Device.RuntimePlatform == Device.iOS ? "Candara" : null)) }
                }
            };

            if (Resources == null)
                Resources = new ResourceDictionary();
            Resources.Add(labelStyle);
            Resources.Add(entryStyle);
            Resources.Add(cellStyle);

            CurrentDataStore.CurrentDALC = new FileDataStore();
            MockVaccineDatabase.MockVaccineDataStore();

            
            //IDictionary<NavigationController.Map, Type> fullmap = new Dictionary<NavigationController.Map, Type>
            //{
            //    { NavigationController.Map.Create(0, typeof(Views.MainPage)), typeof(AboutPage) },
            //    { NavigationController.Map.Create(1, typeof(Views.MainPage)), typeof(VaccineListViewPage) }
            //};


            //NavigationService = new NavigationService(new MainPage());
            //NavController = new NavigationController(NavigationService, fullmap);


            MainPage = new MainMasterDetailPage(); //MainPage();

            //BeginInvokeOnMainThread
            //Device.BeginInvokeOnMainThread(async () => {
            //    await Navigation.PushAsync(new SchedulePage());
            //});
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
