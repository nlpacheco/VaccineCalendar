using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VaccineCalendar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMasterDetailPageDetail : ContentPage
    {
        public MainMasterDetailPageDetail()
        {
            InitializeComponent();
            //This is a detail page. To get the 'triple' line icon on each platform add a icon to each platform and update the 'Master' page with an Icon that references it.
        }
    }
}