using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VaccineCalendar.Shared.NavController;

namespace VaccineCalendar.ViewModels
{
    public class VaccineViewModel : BaseViewModel
    {
        public class Parametro
        {
            public int StateId;
            public Vaccine Vaccine;

            public Parametro (int stateId, Vaccine vaccine)
            {
                StateId = stateId;
                Vaccine = vaccine;
            }
        }

        INavController _controller => App.Instance.NavController;

        public ObservableCollection<Vaccine> Vaccines { get; set; }
        public Command LoadItemsCommand { get; set; }

        public VaccineViewModel()
        {
            Title = "Vacinas";
            Vaccines = new ObservableCollection<Vaccine>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadVaccineCommand());

            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var _item = item as Item;
            //    Items.Add(_item);
            //    await DataStore.AddItemAsync(_item);
            //});


        }

        //public Command<Parametro> NavigationCommand => new Command<Parametro>((parametro) =>
        //{
        //    OpenVaccineDetail(parametro);
        //    //_controller.Complete(new NavResult() { StateId = Convert.ToInt32(parametro.stateId) }, new Object[] { parametro.vaccine });
        //});

        public async Task OpenVaccineDetail(Parametro parametro)
        {
            await _controller.Complete(new NavResult() { StateId = Convert.ToInt32(parametro.StateId) }, new Object[] { parametro.Vaccine });
        }



        async Task ExecuteLoadVaccineCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Vaccines.Clear();

                var vaccineTmp = await CurrentDataStore.CurrentDALC.GetVaccineDBProvider.GetAllVaccines(); 
                foreach (var vacinaItem in vaccineTmp)
                {
                    Vaccines.Add(vacinaItem);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
