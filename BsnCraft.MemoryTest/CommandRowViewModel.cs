using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsnCraft.MemoryTest
{
    public class CommandRowViewModel : ViewModelBase
    {
        public CommandViewModel Item1 { get; set; }
        public CommandViewModel Item2 { get; set; }
        public CommandViewModel Item3 { get; set; }
        public CommandViewModel Item4 { get; set; }
        public CommandViewModel Item5 { get; set; }
        public CommandViewModel Item6 { get; set; }
        public CommandViewModel Item7 { get; set; }
        public CommandViewModel Item8 { get; set; }
        public CommandViewModel Item9 { get; set; }

        public void SetItem(int id, object item)
        {
            switch (id)
            {
                case 1:
                    Item1 = (CommandViewModel)item;
                    break;
                case 2:
                    Item2 = (CommandViewModel)item;
                    break;
                case 3:
                    Item3 = (CommandViewModel)item;
                    break;
                case 4:
                    Item4 = (CommandViewModel)item;
                    break;
                case 5:
                    Item5 = (CommandViewModel)item;
                    break;
                case 6:
                    Item6 = (CommandViewModel)item;
                    break;
                case 7:
                    Item7 = (CommandViewModel)item;
                    break;
                case 8:
                    Item8 = (CommandViewModel)item;
                    break;
                case 9:
                    Item9 = (CommandViewModel)item;
                    break;
            }
        }
    }
}
