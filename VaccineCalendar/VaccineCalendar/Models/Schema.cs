using System;
using System.Collections.Generic;
using System.Text;
using VaccineCalendar.Services.Dalc;

namespace VaccineCalendar.Models
{
    public class Schema : IGenericDBEntity<Guid>
    {
        public Guid SchemaId { get; set; }
        public Guid? OwnerId { get; set; }
        public string SchemaName { get; set; }
        public Guid? BaseSchemaId { get; set; }
        public DateTime Timestamp { get; set; }
        public IEnumerable<SchemaVaccine> SchemaVaccines { get; set; }

        public Guid Key
        {
            get { return SchemaId; }
            set { SchemaId = value; }
        }

    }
}
