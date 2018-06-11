using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;

namespace VaccineCalendar.ViewModels
{

    public class UserViewModel
    {
        static private User _user;

        public static async Task<User> GetCurrentUser()
        {
            if (_user == null)           
                _user = await CurrentDataStore.CurrentDALC.GetUserDBProvider.GetUserByEmail("norberto.luciano.pacheco@gmail.com");
            return _user;
        }

    }
}
