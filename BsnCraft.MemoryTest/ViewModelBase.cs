using System;
using System.ComponentModel;

namespace BsnCraft.MemoryTest
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public event BsnEventHandler BsnEvent;
        public void OnBsnEvent(object sender, BsnEventArgs e)
        {
            BsnEvent?.Invoke(sender, e);
        }
    }
}
