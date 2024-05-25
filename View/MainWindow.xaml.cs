using RSCProgerss.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;

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
        public MainWindow()
        {
            InitializeComponent();
              
            Login login = new Login();
            login.ShowDialog();
            if (Employee == null)
            {
                Application.Current.Shutdown();
            }
           

            
            switch (Employee.Role)
            {
                case "Worker":
                    mainFrame.Navigate(new MainWorkerPage(Employee));
                    break;
                case "Master":
                    mainFrame.Navigate(new MainMasterPage(Employee));
                    break;
                case "Technolog":
                    mainFrame.Navigate(new Uri("View/MainTechnologPage.xaml", UriKind.Relative));
                    break;
                default:
                    break;

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
       
    }
}

