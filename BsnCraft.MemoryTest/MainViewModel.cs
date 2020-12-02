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
        public CommandViewModel Close { get; } 
            = new CommandViewModel("CLS", "Close");

        public ObservableCollection<CommandRowViewModel> Items { get; } 
            = new ObservableCollection<CommandRowViewModel>();

        public void AddItem(CommandRowViewModel list)
        {
            list.Item1.BsnEvent += OnBsnEvent;
            list.Item2.BsnEvent += OnBsnEvent;
            list.Item3.BsnEvent += OnBsnEvent;
            list.Item4.BsnEvent += OnBsnEvent;
            list.Item5.BsnEvent += OnBsnEvent;
            list.Item6.BsnEvent += OnBsnEvent;
            list.Item7.BsnEvent += OnBsnEvent;
            list.Item8.BsnEvent += OnBsnEvent;
            list.Item9.BsnEvent += OnBsnEvent;
            Items.Add(list);
        }

        public void ClearItems()
        {
            Items.Clear();
        }

        public MainViewModel()
        {
            Add.BsnEvent += OnBsnEvent;
            Remove.BsnEvent += OnBsnEvent;
            Close.BsnEvent += OnBsnEvent;
        }
    }
}