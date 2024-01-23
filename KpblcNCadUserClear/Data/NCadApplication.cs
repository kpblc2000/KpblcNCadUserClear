using System;
using System.IO;
using Microsoft.Win32;

namespace KpblcNCadUserClear.Data
{
    public class NCadApplication
    {
        public NCadApplication(string RegistryHiveName)
        {
            RegistryName = RegistryHiveName;
            string[] splited = RegistryHiveName.Split('\\');
            Version = splited[splited.Length - 1];
            ApplicationFullName = splited[splited.Length - 2] + " " + Version;
        }
        /// <summary> Имя узла в реестре, начиная с Software </summary>
        public string RegistryName { get; }
        /// <summary> Полное имя приложения для показа в окне </summary>
        public string ApplicationFullName { get; }
        /// <summary> "Версия" приложения. Сделана строкой, т.к. может быть нечто типа "23.1 (backup)", что помешает нормальному преобразованию </summary>
        public string Version { get; }
        /// <summary> Надо ли очищать данные </summary>
        public bool CheckedToClear { get; set; }
        /// <summary> Каталог внутри %AppData% с данными по текущему дополнению / платформе </summary>
        public string AppDataSubFolder
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryName))
                {
                    if (key == null)
                    {
                        return string.Empty;
                    }

                    var value = key.GetValue("UserDataDir");
                    if (value == null)
                    {
                        string path = Path.Combine(Environment.GetEnvironmentVariable("appdata"), ApplicationFullName);
                        if (Directory.Exists(path))
                        {
                            return path;
                        }

                        return string.Empty;
                    }

                    return key.GetValue("UserDataDir").ToString();
                }
            }
        }
    }
}
