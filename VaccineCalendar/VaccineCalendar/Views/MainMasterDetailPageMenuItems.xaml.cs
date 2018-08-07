using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPageMenuItems : ContentPage
    {
        public ListView ListView;
        public MainMasterDetailPageMenuItems()
        {
            InitializeComponent();
            BindingContext = new VaccineMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

    }


    public class VaccineMasterDetailPageMasterViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<VaccineMasterDetailPageMenuItem> MenuItems { get; set; }


        public VaccineMasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<VaccineMasterDetailPageMenuItem>(new[]
                {
                    new VaccineMasterDetailPageMenuItem { Id = 0, Title = "Vacinas", TargetType = typeof(VaccineListViewPage) },
                    new VaccineMasterDetailPageMenuItem { Id = 1, Title = "Família", TargetType = typeof(FamilyPage) },
                    new VaccineMasterDetailPageMenuItem { Id = 2, Title = "Agenda" },
                    new VaccineMasterDetailPageMenuItem { Id = 3, Title = "Esquemas Vacinas", TargetType = typeof(SchemasPage) },
                    new VaccineMasterDetailPageMenuItem { Id = 4, Title = "Sobre Nós", TargetType = typeof(AboutPage) },
                });


        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

}

