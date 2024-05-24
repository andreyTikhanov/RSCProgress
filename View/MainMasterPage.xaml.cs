using RSCProgerss.Model;
using System.Windows.Controls;

namespace RSCProgerss.View
{
    public partial class MainMasterPage : Page
    {
        Master _master;
        public MainMasterPage(Master master)
        {
            _master = master;
            InitializeComponent();
        }
    }
}
