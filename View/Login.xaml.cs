using RSCProgerss.Model;
using System.Windows;

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
                    Employee employee = db.Employees.FirstOrDefault(e => e.Id == int.Parse(tbNumber.Text) && e.Password == pbPassword.Password);

                    if (employee == null)
                    {
                        MessageBox.Show("Что то пошло не так");
                        lbError.Visibility = Visibility.Visible;
                        lbError.Content = "Вы ввели некорректные данные";
                        return;
                    }
                    MainWindow.Employee = employee;
                    Close();



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
