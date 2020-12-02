using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;

namespace BsnCraft.MemoryTest
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            this.Load += ViewForm_Load;
        }

        ElementHost ctrlHost; 
        void ViewForm_Load(object sender, EventArgs e)
        {
            if (ctrlHost == null) CreateHost();
        }

        void CreateHost()
        {
            ctrlHost = new ElementHost();
            ctrlHost.Dock = DockStyle.Fill;
            this.Controls.Add(ctrlHost);
        }

        public void ResizeForm(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        public void AddView(object wpfControl)
        {
            if (ctrlHost == null) CreateHost();

            ctrlHost.Child = (UIElement)wpfControl;
        }
    }
}
