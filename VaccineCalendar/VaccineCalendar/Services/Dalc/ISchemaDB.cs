using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using VaccineCalendar.Models;

namespace VaccineCalendar.Services.Dalc
{
    public interface ISchemaDB
    {
        Task<Schema> GetSchema(Guid schemaId);
        Task<IEnumerable<Schema>> GetSchemas(Guid? OwnerPersonId);
        Task SaveSchema(Schema schema);
    }
}
