using VaccineCalendar.Services.Dalc;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Services.DalcFile
{
    public class FileDataStore : IDataStore
    {
        static IUserDB userDB;
        static IFamilyPersonDB familyPersonDB;
        static IVaccineDB vaccineDB;
        static IVaccineBlendDB vaccineBlendDB;
        static ISchemaDB schemaDB;


        public IUserDB GetUserDBProvider
        {
            get
            {
                if (userDB == null) userDB = new UserDB();
                return userDB;
            }
        }

        public IFamilyPersonDB GetFamilyPersonDBProvider
        {
            get
            {
                if (familyPersonDB == null) familyPersonDB = new FamilyPersonDB();
                return familyPersonDB;
            }
        }

        public IVaccineDB GetVaccineDBProvider
        {
            get
            {
                if (vaccineDB == null) vaccineDB = new VaccineDB();
                return vaccineDB;
            }
        }

        public IVaccineBlendDB GetVaccineBlendDBProvider
        {
            get
            {
                if (vaccineBlendDB == null) vaccineBlendDB = new VaccineBlendDB();
                return vaccineBlendDB;
            }
        }

        public ISchemaDB GetSchemaDBProvider
        {
            get
            {
                if (schemaDB == null) schemaDB = new SchemaDB();
                return schemaDB;
            }
        }

    }
}
