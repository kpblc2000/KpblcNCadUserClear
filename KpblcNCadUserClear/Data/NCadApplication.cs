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
    }
}
