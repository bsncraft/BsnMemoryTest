using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BsnCraft.MemoryTest
{
    public delegate void BsnEventHandler(object sender, BsnEventArgs e);

    public class BsnEventArgs : EventArgs
    {
        public BsnEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public object Arg { get; set; }
        public bool Handled { get; set; }
    }
}
