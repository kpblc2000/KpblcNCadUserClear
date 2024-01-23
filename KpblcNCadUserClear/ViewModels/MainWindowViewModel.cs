using KpblcNCadUserClear.Data;
using KpblcNCadUserClear.Repositories;
using KpblcNCadUserClear.ViewModels.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using KpblcNCadUserClear.Commands;

namespace KpblcNCadUserClear.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            Title = "Очистка версии";

            NCadApplicationRepository rep = new NCadApplicationRepository();
            ApplicationList = new List<NCadApplication>(rep.Get().OrderBy(o => o.Version));

            ClearCommand = new RelayCommand(OnClearCommandExecuted, CanClearCommandExecute);
        }

        public List<NCadApplication> ApplicationList
        {
            get => _applicationList;
            private set => Set(ref _applicationList, value);
        }

        public ICommand ClearCommand { get; }

        public void OnClearCommandExecuted(object p)
        {

        }

        public bool CanClearCommandExecute(object p)
        {
            return ApplicationList.Select(o => o.CheckedToClear).Any();
        }

        private List<NCadApplication> _applicationList;
    }
}
