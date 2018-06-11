using System;
using System.Collections.Generic;
using System.Text;
using VaccineCalendar.Services.Dalc;

namespace VaccineCalendar.Models
{
    public class VaccineType : IGenericDBEntity<Guid>
    {
        public Guid VaccineTypeId { get; set; }
        public Guid VaccineId { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public Guid Key
        {
            get { return VaccineTypeId; }
            set { VaccineTypeId = value; }
        }

    }
}
