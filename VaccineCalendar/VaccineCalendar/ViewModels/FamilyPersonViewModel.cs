using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VaccineCalendar.Models;
using VaccineCalendar.Services.Dalc;
using Xamarin.Forms;

namespace VaccineCalendar.ViewModels
{
    public class FamilyPersonViewModel: BaseViewModel
    {

        public FamilyPerson FamilyPerson
        {
            get;
            private set;
        }

        public static DateTime Today
        {
            get { return Shared.Calendar.Today; }
        }

        private string _name;
        public string Name {
            get { return _name; }
            set {
                FamilyPerson.Name = value;
                SetProperty<string>(ref _name, value);
            }
        }

        private DateTime _birthDate;
        public DateTime BirthDate {
            get { return _birthDate; }
            set {
                FamilyPerson.BirthDate = value;
                SetProperty<DateTime>(ref _birthDate, value);
                //Age = Shared.Calendar.IdadeTexto(_birthDate);
            }
        }


        public ICommand SaveItemCommand { get; set; }
        public ICommand BirthDateChanged { get; set; }




        public FamilyPersonViewModel(User responsibleUser) : 
            this(new FamilyPerson() {   FamilyId = responsibleUser.FamilyId,
                                        BirthDate = Today })
        {
        }

        public FamilyPersonViewModel(FamilyPerson familyPerson)
        {
            FamilyPerson = familyPerson;
            Name = FamilyPerson.Name;
            BirthDate = FamilyPerson.BirthDate;

            SaveItemCommand = new Command(ExecuteSaveItemCommand);
        }


        void ExecuteSaveItemCommand()
        {
            FamilyPerson.Name = Name;
            FamilyPerson.BirthDate = BirthDate;
            CurrentDataStore.CurrentDALC.GetFamilyPersonDBProvider.SaveFamilyPerson(FamilyPerson);
        }



    }
}
