using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsnCraft.MemoryTest
{
    public class MainViewModel : ViewModelBase
    {
        public CommandViewModel Add { get; } 
            = new CommandViewModel("ADD", "Add Items");
        public CommandViewModel Remove { get; } 
            = new CommandViewModel("DEL", "Remove Items");

        public ObservableCollection<CommandViewModel> Items { get; } 
            = new ObservableCollection<CommandViewModel>();

        public MainViewModel()
        {
            Add.BsnEvent += OnBsnEvent;
            Remove.BsnEvent += OnBsnEvent;
        }
    }
}