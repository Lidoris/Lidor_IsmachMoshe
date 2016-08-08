using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator_Async
{ 
    public partial class PrimesCalculatorForm : Form
    {
        private int _amountOfPrimes;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        
        public PrimesCalculatorForm()
        {
            InitializeComponent();
        }
         
        private async void calculateButton_Click(object sender, EventArgs e)
        {
            string outputFileName;
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;
            outputFileName = outputFileTextBox.Text;
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                MessageBox.Show("Invalid output file name,  Please try again.");
            }
            else
            {
                await Task.Run(() =>
                {
                    CountPrimesAsync(_cancellationToken);
                }, _cancellationToken);
                amountOfPrimesLabel.Text = $"Amount of primes:{_amountOfPrimes}";
                using (StreamWriter streamWriter = new StreamWriter(outputFileName.Trim() + ".txt"))
                {
                    streamWriter.WriteLine($"Amount of primes:{_amountOfPrimes}");
                }
            }
        }

        private void CountPrimesAsync(CancellationToken cancellationToken)
        {
            bool isPrime;
            long minNum, maxNum;
            long firstNum, secondNum;
            bool inputValid;

            _amountOfPrimes = 0;
            inputValid = long.TryParse(StartTextBox.Text, out firstNum);
            inputValid = long.TryParse(EndTextBox.Text, out secondNum) && inputValid;
            if (!inputValid)
            {
                MessageBox.Show("Input is not valid. Please try again.");
            }

            minNum = Math.Min(firstNum, secondNum);
            maxNum = Math.Max(firstNum, secondNum);
            minNum = minNum < 2 ? 2 : minNum;
            for (long i = minNum; i <= maxNum; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }
                isPrime = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    _amountOfPrimes++;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }
        }
    }
}
