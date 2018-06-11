using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Shared;

namespace VaccineCalendar.Models
{
    public class FamilyPerson: IGenericDBEntity<Guid>
    {
        public Guid PersonId { get; set; }
        public Guid FamilyId{ get; set; }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public Guid Key
        {
            get { return PersonId; }
            set { PersonId = value; }
        }

        [JsonIgnore]
        public string IdadeTexto
        {
            get { return Calendar.IdadeTexto(BirthDate); }
        }
    }

}

    