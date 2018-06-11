using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using VaccineCalendar.Models;

namespace VaccineCalendar.Services.Dalc
{
    public interface IVaccineDB
    {
        Task<IEnumerable<Vaccine>> GetAllVaccines();

        Task SaveVaccine(Vaccine vaccine);
        Task SaveAllVaccines(IEnumerable<Vaccine> vaccines);
    }
}
