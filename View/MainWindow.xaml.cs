using RSCProgerss.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Navigation;

namespace RSCProgerss.View
{


    public partial class MainWindow : Window
    {
        ObservableCollection<Worker> workers;
        ObservableCollection<Master> masters;
        ObservableCollection<Technolog> technologs;
        Worker _worker;
        Master _master;
        Technolog _technolog;
        public static Employee Employee;
        public MainWindow(Employee employee)
        {
            InitializeComponent();

            if(employee == null)
            {
                MessageBox.Show("none found");
            }
            if (employee.Role == "Worker")
            {
                _worker = (Worker)employee;
                MainWorkerWindow window = new MainWorkerWindow(_worker);
                window.ShowDialog();
            }

            /*
            technologs = new ObservableCollection<Technolog>
            {
                new Technolog
                {
                    FirstName="john",
                    SecondName="deer",
                    Experiance=new DateTime(2010, 3 ,19),
                    Password="1",


                },
                new Technolog
                {
                    FirstName="mike",
                    SecondName="gomes",
                    Experiance=new DateTime(2020, 11 ,4),
                    Password="2", 

                }
            };
            using (FactoryContext db = new FactoryContext())
            {
                db.AddRange(technologs);
                db.SaveChanges();
            };
            */



        }

        private object MainWorkerPage(Worker worker)
        {
            throw new NotImplementedException();
        }
    }
}

