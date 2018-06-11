using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCalendar.Services.Dalc
{
    public interface IFamilyPersonDB
    {
        Task <IEnumerable<FamilyPerson>> GetFamilyPeople(User user);
        Task SaveFamilyPerson(FamilyPerson familyPerson);
        Task CancelFamilePerson(FamilyPerson familyPerson);
        Task SaveAllFamily(IEnumerable<FamilyPerson> people);
    }
}
