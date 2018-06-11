using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VaccineCalendar.ViewModels
{
    public class FamilyViewModel: BaseViewModel
    {
        public User ResponsibleUser
        {
            get;
            private set;
        }

        public string ResponsibleUserName
        {
            get { return ResponsibleUser==null? "" : ResponsibleUser.Name; }
        }


        public ObservableCollection<FamilyPerson> FamilyPeople { get; set; }

        public Command LoadItemsCommand { get; set; }

        public FamilyViewModel()
        {
            Title = "Família";
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            FamilyPeople = new ObservableCollection<FamilyPerson>();
        }


        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                if (ResponsibleUser == null) 
                    ResponsibleUser = await UserViewModel.GetCurrentUser();

                FamilyPeople.Clear();
                var items = await CurrentDataStore.CurrentDALC.GetFamilyPersonDBProvider.GetFamilyPeople(ResponsibleUser);
                foreach (var item in items)
                {
                    FamilyPeople.Add(item);
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
