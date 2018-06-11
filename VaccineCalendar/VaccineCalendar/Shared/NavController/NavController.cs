using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VaccineCalendar.Shared.NavController
{
    public class NavResult
    {
        public int StateId { get; set; } = 0; // Optional StateId
        public object Parameter { get; set; } // Optional Data you want sending
        public static NavResult Empty() => new NavResult();
    }

    public interface INavController
    {
        Task Complete(NavResult result);
        Task Complete(NavResult result, Object[] parameters);
        Task Cancel();
    }


    public class NavigationController : INavController
    {
        readonly INavigationService _navigationService;

        public NavigationController(INavigationService navigationService, IDictionary<Map,Type> fullMap )
        {
            _navigationService = navigationService;
            _workflow = fullMap;
        }
        public struct Map
        {
            public static Map Create(int stateId, Type page)
            {
                return new Map()
                {
                    StateId = stateId,
                    Page = page
                };
            }
            public int StateId;
            public Type Page;
        }

        // From -> To
        IDictionary<Map, Type> _workflow;

        IDictionary<Map, Type> Workflow
        {
            get {
                if (_workflow == null) _workflow = new Dictionary<Map, Type>();
                return _workflow;
            }
        }


        public async Task Complete(NavResult result)
        {
            var toPage = Workflow.First(x => x.Key.StateId == result.StateId && x.Key.Page == _navigationService.CurrentPage).Value;
            await _navigationService.Push((Page)Activator.CreateInstance(toPage));
        }

        public async Task Complete(NavResult result, Object[] parameters)
        {
            var toPage = Workflow.First(x => x.Key.StateId == result.StateId && x.Key.Page == _navigationService.CurrentPage).Value;
            await _navigationService.Push((Page)Activator.CreateInstance(toPage, parameters));
        }

        public async Task Cancel()
        {
            await _navigationService.Pop();
        }
    }

}
