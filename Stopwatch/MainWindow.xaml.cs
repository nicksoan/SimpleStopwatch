using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace Stopwatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan time;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            time = TimeSpan.Zero;
            lblTime.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time = time.Add(timer.Interval);
            lblTime.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            time = TimeSpan.Zero;
            lblTime.Text = time.ToString(@"hh\:mm\:ss");
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }

        private void lblTime_LostFocus(object sender, RoutedEventArgs e)
        {
            string timeString = lblTime.Text;
            TimeSpan timeSpan;
            if (TimeSpan.TryParse(timeString, out timeSpan))
            {
                time = TimeSpan.FromSeconds(timeSpan.TotalSeconds);
            }
            else
            {
                time = TimeSpan.Zero;
            }
        }
    }
}
