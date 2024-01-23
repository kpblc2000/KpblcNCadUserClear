using KpblcNCadUserClear.Data;
using KpblcNCadUserClear.Repositories;
using KpblcNCadUserClear.ViewModels.Base;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using KpblcNCadUserClear.Commands;
using Microsoft.Win32;

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
            foreach (NCadApplication application in ApplicationList.Where(o => o.CheckedToClear))
            {
                string parentPath = Path.GetDirectoryName(application.RegistryName);
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(parentPath, true))
                {
                    key.DeleteSubKeyTree(application.RegistryName.Substring(parentPath.Length + 1));
                }

                if (Directory.Exists(application.AppDataSubFolder))
                {
                    Directory.Delete(application.AppDataSubFolder, true);
                }
            }
        }

        public bool CanClearCommandExecute(object p)
        {
            return ApplicationList.Where(o => o.CheckedToClear).Any();
        }

        private List<NCadApplication> _applicationList;
    }
}
