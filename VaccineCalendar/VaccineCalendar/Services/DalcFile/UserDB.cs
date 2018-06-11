using VaccineCalendar.Services.Dalc;
using VaccineCalendar.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace VaccineCalendar.Services.DalcFile
{
    public class UserDB : IUserDB
    {
        private const string _filename = "AGVusers.json";
        GenericFileRepository<User, string> _repository = new GenericFileRepository<User, string>(_filename);

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await _repository.GetEntityAsync(userEmail);
        }

        public async Task SaveUser(User user)
        {
            await _repository.SaveEntityAsync(user);
        }
    }
}
