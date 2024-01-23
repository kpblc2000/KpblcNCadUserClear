using KpblcNCadUserClear.Data;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;

namespace KpblcNCadUserClear.Repositories
{
    internal class NCadApplicationRepository
    {
        public IEnumerable<NCadApplication> Get()
        {
            RegistryKey mainRegHive = Registry.CurrentUser.OpenSubKey(_hiveName);
            if (mainRegHive == null)
            {
                return null;
            }

            List<NCadApplication> res = new List<NCadApplication>();
            int index = mainRegHive.Name.IndexOf(@"\") + 1;

            foreach (string keyName in mainRegHive.GetSubKeyNames())
            {
                if (keyName.ToUpper().StartsWith("NANO"))
                {
                    using (RegistryKey subKey = mainRegHive.OpenSubKey(keyName))
                    {
                        foreach (string subKeyName in subKey.GetSubKeyNames())
                        {
                            res.Add(new NCadApplication(Path.Combine(subKey.Name, subKeyName).Substring(index)));
                        }
                    }
                }
            }

            return res;

        }

        private readonly string _hiveName = @"Software\Nanosoft";
    }
}
