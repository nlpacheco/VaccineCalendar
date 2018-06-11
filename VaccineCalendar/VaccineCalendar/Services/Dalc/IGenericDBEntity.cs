using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.Services.Dalc
{
    public interface IGenericDBEntity<KeyType>
    {
        KeyType Key { get; set; }
    }
}
