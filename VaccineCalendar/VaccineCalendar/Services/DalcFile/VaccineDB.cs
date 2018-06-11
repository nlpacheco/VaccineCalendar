using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCalendar.Services.DalcFile
{
    public class VaccineDB : IVaccineDB
    {
        private const string _filename = "AGVVaccine.json";
        GenericFileRepository<Vaccine, Guid> _repository = new GenericFileRepository<Vaccine, Guid>(_filename);

        public async Task<IEnumerable<Vaccine>> GetAllVaccines()
        {
            return await _repository.GetAllEntitiesAsync();
        }

        public async Task SaveVaccine(Vaccine vaccine)
        {
            await _repository.SaveEntityAsync(vaccine);
        }

        public async Task SaveAllVaccines(IEnumerable<Vaccine> vaccines)
        {
            await _repository.SaveAllEntitiesAsync(vaccines);
        }
    }
}
