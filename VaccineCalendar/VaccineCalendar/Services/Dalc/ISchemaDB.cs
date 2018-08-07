using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using VaccineCalendar.Models;

namespace VaccineCalendar.Services.Dalc
{
    public interface ISchemaDB
    {
        Schema GetSchema(Guid schemaId);

        /// <summary>
        /// Get Schemas ownered by OwnerId. It should return also the public schemas.
        /// </summary>
        /// <param name="OwnerPersonId"></param>
        /// <returns></returns>
        IEnumerable<Schema> GetSchemas(Guid? OwnerPersonId, bool includePublicSchemas);
        void SaveSchema(Schema schema);

        Task<Schema> GetSchemaAsync (Guid schemaId);
        Task<IEnumerable<Schema>> GetSchemasAsync(Guid? OwnerPersonId);
        Task SaveSchemaAsync(Schema schema);
    }
}
