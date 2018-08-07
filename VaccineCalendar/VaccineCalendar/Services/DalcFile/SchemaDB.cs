using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VaccineCalendar.Services.DalcFile
{
    public class SchemaDB : ISchemaDB
    {
        private const string _filename = "AGVSchema.json";

        GenericFileRepository<Schema, Guid> _repository = new GenericFileRepository<Schema, Guid>(_filename);

        public Schema GetSchema(Guid schemaId)
        {
           return _repository.GetEntity(schemaId);
        }

        public IEnumerable<Schema> GetSchemas(Guid? OwnerPersonId, bool includePublicSchemas)
        {
            return _repository.GetEntities(s => (OwnerPersonId.HasValue && s.OwnerId.HasValue && s.OwnerId.Value == OwnerPersonId.Value) || ((includePublicSchemas || !OwnerPersonId.HasValue) && !s.OwnerId.HasValue) );
        }

        public void SaveSchema(Schema schema)
        {
            _repository.SaveEntity(schema);
        }

        public async Task<Schema> GetSchemaAsync(Guid schemaId)
        {
            return await _repository.GetEntityAsync(schemaId);
        }

        public async Task<IEnumerable<Schema>> GetSchemasAsync(Guid? OwnerPersonId)
        {
            return await _repository.GetEntitiesAsync(s => (OwnerPersonId.HasValue && s.OwnerId.HasValue && s.OwnerId.Value == OwnerPersonId.Value) || (!OwnerPersonId.HasValue && !s.OwnerId.HasValue));
        }

        public async Task SaveSchemaAsync(Schema schema)
        {
            await _repository.SaveEntityAsync(schema);
        }

    }
}
