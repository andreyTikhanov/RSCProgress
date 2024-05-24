using RSCProgerss.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSCProgerss.View
{
    public partial class Login : Window
    {
        Worker _worker;
        Master _master;
        Technolog _technolog;
        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNumber.Text)) return;
            if (string.IsNullOrEmpty(pbPassword.Password)) return;
            try
            {
                using (FactoryContext db = new FactoryContext())
                {
                    MainWindow.Employee = db.Employees.FirstOrDefault(e => e.Id == int.Parse(tbNumber.Text) && e.Password == pbPassword.Password);

                    if (MainWindow.Employee != null)
                    {
                        MainWindow mainWindow = new MainWindow(MainWindow.Employee);
                        
                    }
                    else 
                    {
                        lbError.Visibility = Visibility.Visible;
                        lbError.Content = "Вы ввели некорректные данные";
                        return;
                    }
                    this.Close();


                }

            }
            catch (Exception ex)
            {
                lbError.Visibility = Visibility.Visible;
                lbError.Content = "Произошла ошибка при доступе к базе данных";
                return;
            }

            
        }
    




    

    private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
