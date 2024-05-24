using RSCProgerss.Model;
using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RSCProgerss.View
{
    public partial class MainWorkerPage : Page
    {
        private DispatcherTimer timer;
        Worker _worker;
        public MainWorkerPage(Worker worker)
        {
            InitializeComponent();
            _worker = worker;   
            Show();
        }
        public void ShowPhotoWorker()
        {
            if (_worker.Photo == null) return;
            using (var ms = new MemoryStream(_worker.Photo))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = ms;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.EndInit();
                WorkerImage.Source = image;
            }
        }
        public void Show()
        {
            lbNameWorker.Content = $"Удачной работы, {_worker.FirstName}!";
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
