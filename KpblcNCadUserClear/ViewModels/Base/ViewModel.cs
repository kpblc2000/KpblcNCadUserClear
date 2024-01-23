using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace KpblcNCadUserClear.ViewModels.Base
{
    public abstract class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
        }

        public virtual bool Set<T>(ref T Field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(Field, value))
            {
                return false;
            }
            Field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public virtual string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private string _title;
    }
}
