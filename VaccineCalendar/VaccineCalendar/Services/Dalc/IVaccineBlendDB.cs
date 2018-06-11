using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace VaccineCalendar.Services.Dalc
{
    public interface IVaccineBlendDB
    {
        Task<IEnumerable<VaccineBlend>> GetAllBlends();

        Task SaveBlend(VaccineBlend blend);

        Task SaveAllBlends(IEnumerable<VaccineBlend> blends);
    }
}
