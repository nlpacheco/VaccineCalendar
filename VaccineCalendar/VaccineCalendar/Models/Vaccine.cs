using System;
using System.Collections.Generic;
using System.Text;
using VaccineCalendar.Services.Dalc;

namespace VaccineCalendar.Models
{
    public class Vaccine : IGenericDBEntity<Guid>
    {
        public Guid VaccineId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<VaccineType> VaccineTypes { get; set; }


        public Vaccine()
        {
            VaccineTypes = new List<VaccineType>();
        }

        public Guid Key
        {
            get { return VaccineId; }
            set { VaccineId = value; }
        }

    }
}
