using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsnCraft.MemoryTest
{
    public class ItemsViewModel : CommandViewModel
    {
        public CommandViewModel Add { get; } 
            = new CommandViewModel("ADD", "Add Items");
        public CommandViewModel Remove { get; } 
            = new CommandViewModel("DEL", "Remove Items");
        public CommandViewModel Close { get; } 
            = new CommandViewModel("CLS", "Close View");

        public DataTable Items { get; set; } = new DataTable("Items");

        public ItemsViewModel(string name, string caption) : base(name, caption)
        {
            Add.BsnEvent += OnBsnEvent;
            Remove.BsnEvent += OnBsnEvent;
            Close.BsnEvent += OnBsnEvent;
            for (var i = 1; i < 10; i++)
            {
                Items.Columns.Add($"Item{i}", typeof(CommandViewModel));  
            }
        }

        public void AddItems(List<CommandViewModel> list)
        {
            var i = 0;
            var row = Items.NewRow();
            foreach (var item in list)
            {
                i++;
                item.BsnEvent += OnBsnEvent;
                row[$"Item{i}"] = item;
            }
            Items.Rows.Add(row);
        }

        public void ClearItems()
        {
            Items.Clear();
        }
    }
}
