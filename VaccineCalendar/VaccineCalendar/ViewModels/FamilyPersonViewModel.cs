using System;
using System.Collections.Generic;
using System.Linq;
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

        private FamilyPerson FamilyPerson
        {
            get;
            set;
        }


        public string[] GenderArray = { "Menina", "Menino" };
        private string[] GenderId = { "F", "M" };


    
        private int _genderIndex;
        public int GenderIndex
        {
            get { return _genderIndex; }
            set {
                if (_genderIndex != value)
                    SetProperty<int>(ref _genderIndex, value); }
        }



        public static DateTime Today
        {
            get { return Shared.Calendar.Today; }
        }

        private string _name;
        public string Name {
            get { return _name; }
            set { SetProperty<string>(ref _name, value);   }
        }

        private DateTime _birthDate;
        public DateTime BirthDate {
            get { return _birthDate; }
            set {
                SetProperty<DateTime>(ref _birthDate, value);
                //Age = Shared.Calendar.IdadeTexto(_birthDate);
            }
        }


        public IEnumerable<Schema> Schemas;
        public IEnumerable<string> SchemaNamesAvailable;

        public int _schemaIndex;
        public int SchemaIndex
        {
            get { return _schemaIndex; }
            set
            {
                if (_schemaIndex != value)
                {
                    SetSchemaByIndex(value);
                    SetProperty<int>(ref _schemaIndex, value);
                }
            }
        }


        private Schema _myschema;
        //private string _schemaName;

        //public  string SchemaName
        //{
        //    get { return _myschema == null ? null : _myschema.SchemaName; }
        //    set
        //    {
        //        if (_schemaName == value) return;
        //        if (_myschema != null && _myschema.SchemaName == value) return;
        //        SetSchemaByName(value);
        //    }

        //}



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
            //Gender = familyPerson.Gender;
            SetGenderIndex();
            Schemas = CurrentDataStore.CurrentDALC.GetSchemaDBProvider.GetSchemas(FamilyPerson.PersonId, true);
            BuildSchemaNameList();
            if (FamilyPerson.SchemaId != null && FamilyPerson.SchemaId != Guid.Empty)
                SetSchemaByName( GetSchemaById(FamilyPerson.SchemaId).SchemaName);
            else
                SchemaIndex = -1;

            SaveItemCommand = new Command(ExecuteSaveItemCommand);

        }



        public void ExecuteSaveItemCommand()
        {
            FamilyPerson.Name = Name;
            FamilyPerson.BirthDate = BirthDate;
            if (GenderIndex > -1 && GenderIndex < GenderId.Length)
                FamilyPerson.Gender = GenderId[GenderIndex];
            else
                FamilyPerson.Gender = "";

            if ((_myschema.OwnerId == null || _myschema.OwnerId == Guid.Empty) &&  _myschema.SchemaId != FamilyPerson.SchemaId)
            {
                _myschema.SchemaId = Guid.NewGuid();
                _myschema.OwnerId = FamilyPerson.PersonId;
                _myschema.SchemaName = FamilyPerson.Name + " (" + _myschema.SchemaName + ")";
                CurrentDataStore.CurrentDALC.GetSchemaDBProvider.SaveSchema(_myschema);
                FamilyPerson.SchemaId = _myschema.SchemaId;
            }

            CurrentDataStore.CurrentDALC.GetFamilyPersonDBProvider.SaveFamilyPerson(FamilyPerson);
        }



        private void SetSchemaByName(string schemaName)
        {
            if (schemaName == null)
            {
                _myschema = null;
                //SchemaName = null;
                return;

            }

            if (_myschema != null && _myschema.SchemaName == schemaName)
                return;

            Schema schema = Schemas.FirstOrDefault(e => e.SchemaName == schemaName);
            if (schema == null)
            {
                // TODO: Schema not found
            }
            else
            {

                _myschema = schema;


                int index = -1;
                bool schemaLocalizado = false;
                foreach (var name in SchemaNamesAvailable)
                {
                    index++;
                    if (name == schemaName)
                    {
                        schemaLocalizado = true;
                        break;
                    }
                }

                if (schemaLocalizado)
                    SchemaIndex = index;
                else
                {
                    //TODO: schema not found
                }

            }
        }



        private void SetSchemaByIndex(int index)
        {
            if (index < 0)
            {
                //SchemaName = null;
                _myschema = null;
                return;
            }

            string schemaNameSelected = null;
            foreach (var name in SchemaNamesAvailable)
            {
                if (index-- == 0)
                {
                    schemaNameSelected = name;
                    break;
                }
            }
            if (schemaNameSelected == null)
            {
                //TODO: schema not found
            }
            else
                SetSchemaByName(schemaNameSelected);
        }


        private Schema GetSchemaById(Guid id)
        {
            return Schemas.FirstOrDefault(s => s.SchemaId == id);
        }


        private void BuildSchemaNameList()
        {
            SchemaNamesAvailable = Schemas.Select((schema, index) => schema.SchemaName);
        }


        private void SetGenderIndex()
        {
            for(int i =0; i< GenderId.Length; i++)
                if (GenderId[i] == FamilyPerson.Gender)
                {
                    GenderIndex = i;
                    return;
                }
            GenderIndex = -1;
        }

    }
}
