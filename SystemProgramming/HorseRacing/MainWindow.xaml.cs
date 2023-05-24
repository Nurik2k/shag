using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HorseRacing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker[] workers;
        private bool isRunning;
        private Random random;
        public MainWindow()
        {
            InitializeComponent();
            workers = new BackgroundWorker[3];
            random = new Random();
            isRunning = false;

            for (int i = 0; i < 3; i++)
            {
                workers[i] = new BackgroundWorker();
                workers[i].WorkerReportsProgress = true;
                workers[i].DoWork += Worker_DoWork;
                workers[i].ProgressChanged += Worker_ProgressChanged;
                workers[i].RunWorkerCompleted += Worker_RunWorkerCompleted;
            }


        }

        private void StartRace_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;

                for (int i = 0; i < 3; i++)
                {
                    workers[i].RunWorkerAsync(i);
                }
            }
        }
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int workerIndex = (int)e.Argument;
            BackgroundWorker worker = (BackgroundWorker)sender;

            for (int i = 0; i <= 100; i++)
            {
                if (!isRunning)
                {
                    e.Cancel = true;
                    break;
                }

                Thread.Sleep(random.Next(100, 150));

                worker.ReportProgress(i, workerIndex);
            }
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int workerIndex = (int)e.UserState;
            ProgressBar progressBar = GetProgressBar(workerIndex);
            progressBar.Value = e.ProgressPercentage;
        }
        private ProgressBar GetProgressBar(int index)
        {
            switch (index)
            {
                case 0:
                    return Horse1;
                case 1:
                    return Horse2;
                case 2:
                    return Horse3;
                default:
                    throw new ArgumentOutOfRangeException("Invalid progress bar index.");
            }
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool allWorkersCompleted = true;
            int winningWorkerIndex = -1;
            int highestProgress = -1;

            for (int i = 0; i < 3; i++)
            {
                if (workers[i].IsBusy)
                {
                    allWorkersCompleted = false;
                    break;
                }

                ProgressBar progressBar = GetProgressBar(i);
                int progress = (int)progressBar.Value;

                if (progress > highestProgress)
                {
                    highestProgress = progress;
                    winningWorkerIndex = i;
                }
            }

            if (allWorkersCompleted)
            {
                isRunning = false;

                if (winningWorkerIndex != -1)
                {
                    string winnerText = $"Winner: Horse {winningWorkerIndex + 1}";
                    tbWinner.Text = winnerText;
                }
            }
        }
    }
}
