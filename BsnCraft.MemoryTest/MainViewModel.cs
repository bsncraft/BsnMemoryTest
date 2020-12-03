using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using DevExpress.Xpf.Grid.GroupRowLayout;

namespace BsnCraft.MemoryTest
{
    public class MainViewModel : ViewModelBase
    {
        public CommandViewModel New { get; }
            = new CommandViewModel("NEW", "New View");

        public CommandViewModel Exit { get; }
            = new CommandViewModel("EXT", "Exit App");

        public ItemsViewModel CurrentView { get; set; }

        public ObservableCollection<ItemsViewModel> Views { get; set; }
            = new ObservableCollection<ItemsViewModel>();

        public int ViewCount { get; private set; }

        public void AddItems(ArrayList list)
        {
            CurrentView.AddItems(list.Cast<CommandViewModel>().ToList());
        }

        public void ClearItems()
        {
            CurrentView.ClearItems();
        }

        public void AddView(ItemsViewModel items)
        {
            Views.Add(items);
            CurrentView = items;
            CurrentView.BsnEvent += (s, e) =>
            {
                if (e.Name.StartsWith("VIEW"))
                {
                    CurrentView = (ItemsViewModel) s;
                    return;
                }
                OnBsnEvent(s, e);
            };
            ViewCount++;
        }

        public static void AddMemoryLeak(ref CommandViewModel cmd, string name, string caption)
        {
            cmd.Name = name;
            cmd.Caption = caption;
        }

        public void CloseView()
        {
            Views.Remove(CurrentView);
            CurrentView.ClearItems();
            CurrentView = null;
            CurrentView = Views.FirstOrDefault();
        }

        public MainViewModel()
        {
            New.BsnEvent += OnBsnEvent;
            Exit.BsnEvent += OnBsnEvent;
            AddView(new ItemsViewModel("VIEW1", "View 1"));
        }
    }
}