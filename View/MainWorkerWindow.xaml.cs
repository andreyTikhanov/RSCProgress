using RSCProgerss.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace RSCProgerss.View
{
    public partial class MainWorkerWindow : Window
    {
        private DispatcherTimer timer;
        Worker _worker;
        public MainWorkerWindow(Worker worker)
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
