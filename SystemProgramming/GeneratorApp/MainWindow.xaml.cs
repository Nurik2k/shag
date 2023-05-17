using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GeneratorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Thread thread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btxGenerateThread_Click(object sender, RoutedEventArgs e)
        {
            int lowerBound = string.IsNullOrEmpty(tbxNum1.Text) ? 2 : int.Parse(tbxNum1.Text);
            int? upperBound = string.IsNullOrEmpty(tbxNum2.Text) ? null : int.Parse(tbxNum2.Text);
            thread = new Thread(() => GeneratePrimeNumbers(lowerBound, upperBound));
            thread.Start();
        }
        private void GeneratePrimeNumbers(int min, int? max)
        {
            int number = min;

            while ((!max.HasValue || number <= max.Value))
            {
                if (IsPrime(number))
                {
                    // Update UI with prime number
                    Dispatcher.Invoke(() => lbResultThread.Items.Add(number));
                }

                number++;
                Thread.Sleep(100);
            }
        }
        private bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }

        private void btxGenerateFibonachi_Click(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(tbxNumber.Text);
            thread = new Thread(()=>GenerateFibonacciNumbers(num));
            thread.Start();
        }
        private void GenerateFibonacciNumbers(int num)
        {
            int previous = 0;
            int current = 1;
            while (current <= num)
            {
                Dispatcher.Invoke(() => lbResultFibonacci.Items.Add(current));

                int next = previous + current;
                previous = current;
                current = next;
            }
        }
    }
}
