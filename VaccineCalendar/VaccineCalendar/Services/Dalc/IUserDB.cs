using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace VaccineCalendar.Services.Dalc
{
    public interface IUserDB
    {
        Task<User> GetUserByEmail(string userEmail);

        Task SaveUser(User user);

    }
}
