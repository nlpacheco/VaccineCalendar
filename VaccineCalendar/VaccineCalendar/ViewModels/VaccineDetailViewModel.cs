using VaccineCalendar.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace VaccineCalendar.ViewModels
{
    public class VaccineDetailViewModel : BaseViewModel

    {

        public Vaccine Vaccine { get; private set; }

        public VaccineDetailViewModel(Vaccine vaccine)
        {
            Title = vaccine.Name;
            Vaccine = vaccine;
        }
    }
}
