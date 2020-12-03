using System.Collections;
using System.Windows;
using BsnCraft.MemoryTest;

namespace MemoryTestHarness
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel Model { get; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            Model.BsnEvent += (sender, args) =>
            {
                switch (((CommandViewModel) sender).Name)
                {
                    case "ADD":
                        AddItems();
                        break;
                    case "NEW":
                        NewView();
                        break;
                    case "DEL":
                        Model.ClearItems();
                        break;
                    case "CLS":
                        Model.CloseView();
                        break;
                    case "EXT":
                        Application.Current.Shutdown();
                        break;
                }
            };
            Loaded += (sender, args) => { Main.DataContext = Model; };
        }

        private void AddItems()
        {
            for (var i = 1; i <= 1000; i++)
            {
                var item = Model.CurrentView;
                var items = new ArrayList();
                for (var j = 1; j < 10; j++)
                {
                    var obj = new CommandViewModel($"{item.Name}_ITEM_{i}_{j}",
                        $"{item.Caption} Item {i} {j}");

                    MainViewModel.AddMemoryLeak(ref obj,
                        $"{item.Name}_ITEM_{i}_{j}",
                        $"{item.Caption} Item {i} {j}");

                    items.Add(obj);
                }

                Model.AddItems(items);
            }
        }

        private void NewView()
        {
            var cnt = Model.ViewCount;
            cnt++;
            var item = new ItemsViewModel($"VIEW{cnt}", $"View {cnt}");
            Model.AddView(item);
        }
    }
}