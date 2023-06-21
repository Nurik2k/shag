using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Philosopher
{
    public partial class MainWindow : Window
    {
        private const int MaxEatCount = 3;
        private Semaphore forkSemaphore = new Semaphore(2, 2);
        private int eatCount = 0;
        private int spaghettiPercent = 100;

        private BackgroundWorker animationWorker;

        public MainWindow()
        {
            InitializeComponent();
            InitializeProgressBars();
            InitializeAnimationWorker();
            StartButton.Click += StartButton_Click;
        }

        private void InitializeProgressBars()
        {
            pbSpaghetti.Value = spaghettiPercent;
            pbPhilosopher1.Value = 0;
            pbPhilosopher2.Value = 0;
            pbPhilosopher3.Value = 0;
            pbPhilosopher4.Value = 0;
            pbPhilosopher5.Value = 0;
        }

        private void InitializeAnimationWorker()
        {
            animationWorker = new BackgroundWorker();
            animationWorker.DoWork += AnimationWorker_DoWork;
            animationWorker.RunWorkerAsync();
        }

        private void AnimationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                AnimateProgressBar(pbPhilosopher1);
                AnimateProgressBar(pbPhilosopher2);
                AnimateProgressBar(pbPhilosopher3);
                AnimateProgressBar(pbPhilosopher4);
                AnimateProgressBar(pbPhilosopher5);

                if (spaghettiPercent <= 0)
                    break;
            }
        }

        private void AnimateProgressBar(ProgressBar progressBar)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                DoubleAnimation animation = new DoubleAnimation
                {
                    From = 0,
                    To = 100,
                    Duration = TimeSpan.FromSeconds(3)
                };

                progressBar.BeginAnimation(ProgressBar.ValueProperty, animation);
            });

            Thread.Sleep(500);
        }

        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;

            Task[] philosopherTasks =
            {
                Task.Run(() => PhilosopherLogic(pbPhilosopher1, "Philosopher #1", "Aqua")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher2, "Philosopher #2", "Red")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher3, "Philosopher #3", "BurlyWood")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher4, "Philosopher #4", "DarkOrange")),
                Task.Run(() => PhilosopherLogic(pbPhilosopher5, "Philosopher #5", "LawnGreen"))
            };

            await Task.WhenAll(philosopherTasks);

            animationWorker.CancelAsync();
            StartButton.IsEnabled = true;
        }

        private void PhilosopherLogic(ProgressBar progressBar, string philosopherName, string color)
        {
            while (spaghettiPercent > 0)
            {
                if (animationWorker.CancellationPending)
                    return;

                Think(philosopherName);

                forkSemaphore.WaitOne();

                if (forkSemaphore.WaitOne(0))
                {
                    Eat(philosopherName, progressBar);

                    forkSemaphore.Release();
                    forkSemaphore.Release();
                }
                else
                {
                    forkSemaphore.Release();
                }
            }
        }

        private void Eat(string philosopherName, ProgressBar progressBar)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                UpdateStatus(philosopherName, "Eating");
                progressBar.Value = eatCount * 100 / MaxEatCount;
                pbSpaghetti.Value -= 10;
            });

            Thread.Sleep(1000);

            eatCount++;
        }

        private void Think(string philosopherName)
        {
            Application.Current.Dispatcher.Invoke(() => UpdateStatus(philosopherName, "Thinking"));

            Thread.Sleep(new Random().Next(1000, 2001));
        }

        private void UpdateStatus(string philosopherName, string status)
        {
            switch (philosopherName)
            {
                case "Philosopher #1":
                    lblPhilosopher1.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #2":
                    lblPhilosopher2.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #3":
                    lblPhilosopher3.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #4":
                    lblPhilosopher4.Content = $"{philosopherName}: {status}";
                    break;
                case "Philosopher #5":
                    lblPhilosopher5.Content = $"{philosopherName}: {status}";
                    break;
            }
        }
    }
}
