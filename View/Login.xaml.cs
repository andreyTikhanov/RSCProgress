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

        Master _master;
        Worker _worker;
        public Login()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text)) return;
            if (string.IsNullOrEmpty(pbPassword.Password)) return;
            try
            {
                using (FactoryContext db = new FactoryContext())
                {
                    _worker = db.Workers.FirstOrDefault(w => w.Login == tbLogin.Text && w.Password == pbPassword.Password);

                    _master = db.Masters.FirstOrDefault(m => m.Login == tbLogin.Text && m.Password == pbPassword.Password);
                }
            }
            catch (Exception ex)
            {
                lbError.Visibility = Visibility.Visible;
                lbError.Content = "Произошла ошибка при доступе к базе данных";
                return;
            }

            if (_worker != null)
            {
                MainWindow mainWindow = new MainWindow(_worker);
                mainWindow.Show();
                this.Close(); // Закрываем текущее окно
                return;
            }

            if (_master != null)
            {
                MainWindow mainWindow = new MainWindow(_master);
                mainWindow.Show();
                this.Close(); // Закрываем текущее окно
                return;
            }

            lbError.Visibility = Visibility.Visible;
            lbError.Content = "Вы ввели некорректные данные";
        }
    




    

    private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
