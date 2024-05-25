using RSCProgerss.Model;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RSCProgerss.View
{
    public partial class MainMasterPage : Page
    {

        private DispatcherTimer timer;
        Master _master;
        public MainMasterPage()
        {

        }
        public MainMasterPage(Employee employee)
        {
            using (FactoryContext db = new FactoryContext())
            {
                _master =(Master)db.Employees.FirstOrDefault(m => m.Id == employee.Id && m.Password == employee.Password);
            }
            InitializeComponent();
            ShowPhotoMaster();
            Show();
        }
        public void ShowPhotoMaster()
        {
            if (_master.Photo == null) return;
            using (var ms = new MemoryStream(_master.Photo))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                MasterImage.Source = image;
            }
        }
        public void Show()
        {
            lbNameWorker.Content = $"Доброго дня! Удачной работы, {_master.FirstName}!";
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lbTime.Content = DateTime.Now.ToString("dd.MM.yyyy   HH:mm");
        }

    }
}
