using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace VaccineCalendar.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Sobre";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://varalzinhobaby.com.br/")));
        }

        public ICommand OpenWebCommand { get; }
    }
}