using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Services.Dalc
{
    public  interface IDataStore
    {
        IUserDB GetUserDBProvider { get; }
        IFamilyPersonDB GetFamilyPersonDBProvider { get; }
        IVaccineDB GetVaccineDBProvider { get; }
        IVaccineBlendDB GetVaccineBlendDBProvider { get; }
        ISchemaDB GetSchemaDBProvider { get; }

    }


}
