using KpblcNCadUserClear.Data;
using System.Collections.Generic;

namespace KpblcNCadUserClear.Repositories
{
    internal class NCadApplicationRepository
    {
        public IEnumerable<NCadApplication> Get()
        {
            return new List<NCadApplication>
            {
                new NCadApplication(@"Компьютер\HKEY_CURRENT_USER\SOFTWARE\Nanosoft\nanoCAD x64\23.1"),
                new NCadApplication(@"Компьютер\HKEY_CURRENT_USER\SOFTWARE\Nanosoft\nanoCAD x64\23.0"),
                new NCadApplication(@"Компьютер\HKEY_CURRENT_USER\SOFTWARE\Nanosoft\nanoCAD x64\24.0"),
                new NCadApplication(@"Компьютер\HKEY_CURRENT_USER\SOFTWARE\Nanosoft\nanoCAD x64 Plus\20")
            };
        }
    }
}
