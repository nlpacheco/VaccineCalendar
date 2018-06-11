using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using Xamarin.Forms;

namespace VaccineCalendar.ViewModels
{
    public class SchemasViewModel: BaseViewModel
    {

        public ObservableCollection<Schema> VaccineSchemas { get; set; }

        public Command LoadItemsCommand { get; set; }

        public SchemasViewModel()
        {
            Title = "Esquemas";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            VaccineSchemas = new ObservableCollection<Schema>();
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                VaccineSchemas.Clear();
                var items = await CurrentDataStore.CurrentDALC.GetSchemaDBProvider.GetSchemas(null);
                foreach (var item in items)
                {
                    VaccineSchemas.Add(item);
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
