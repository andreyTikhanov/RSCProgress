using RSCProgerss.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace RSCProgerss.View
{


    public partial class MainWindow : Window
    {
        ObservableCollection<Worker> workers;
        ObservableCollection<Master> masters;
        Worker _worker;
        Master _master;
        public MainWindow(Worker worker)
        {
            InitializeComponent();
            _worker = worker;
            MainFrame.NavigationService.Navigate(new MainWorkerPage(_worker));
        }
        public MainWindow(Master master)
        {
            InitializeComponent ();
            _master = master;
            MainFrame.NavigationService.Navigate(new MainMasterPage(_master));
        }
        public MainWindow()
        {
            InitializeComponent();
            using (FactoryContext db = new FactoryContext())
            {
                db.SaveChanges();
            }

            using (FactoryContext db = new FactoryContext())
            {
                db.AddRange(masters);
                db.SaveChanges();
            }
        }

    }
}
