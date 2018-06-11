using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Services.Dalc
{
    interface IGenericRepository<T, KeyType> where T : IGenericDBEntity<KeyType> where KeyType : IComparable
    {
        T GetEntity(KeyType key);

        void SaveEntity(T entity);

        void SaveAllEntities(IEnumerable<T> entities);

        IEnumerable<T> GetAllEntities();

        IEnumerable<T> GetEntities(Func<T, bool> predicate);

    }
}
