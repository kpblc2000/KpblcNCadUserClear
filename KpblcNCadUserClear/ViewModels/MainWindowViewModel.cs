using KpblcNCadUserClear.Data;
using KpblcNCadUserClear.Repositories;
using KpblcNCadUserClear.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;

namespace KpblcNCadUserClear.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            Title = "Очистка версии";

            NCadApplicationRepository rep = new NCadApplicationRepository();
            ApplicationList = new List<NCadApplication>(rep.Get().OrderBy(o => o.Version));
        }

        public List<NCadApplication> ApplicationList
        {
            get => _applicationList;
            private set => Set(ref _applicationList, value);
        }

        private List<NCadApplication> _applicationList;
    }
}
