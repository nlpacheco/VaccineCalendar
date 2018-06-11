using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCalendar.Services.Dalc;

namespace VaccineCalendar.Models
{
    public class SchemaVaccine : IGenericDBEntity<Guid>
    {
        public Guid SchemaVaccineId { get; set; }

        public Guid SchemaId { get; set; }      
        public Guid VaccineId { get; set; }
        public string VaccineName { get; set; }
        public string VaccineTypeGroup { get; set; } //  3xDTPw or  3xDTPa or dTpa    (2x rotavírus monovalente or 3x  rotavírus pentavalente) 
        public Guid VaccineTypeId { get; set; }
        public string VaccineTypeName { get; set; }

        public bool Optional
        {
            get { return _optional.HasValue ? _optional.Value : false; }
            set { _optional = value; }
        }
        public string DoseName { get; set; }
        public string DateName { get; set; }
        public int DaysToStartOfPeriod { get; set; }
        public int DaysToEndOfPeriod { get; set; }


        public Guid Key
        {
            get { return SchemaVaccineId; }
            set { SchemaVaccineId = value; }
        }

        [JsonIgnore]
        bool? _optional;
    }
}
