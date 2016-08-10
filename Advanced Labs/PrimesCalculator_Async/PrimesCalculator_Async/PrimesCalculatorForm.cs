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
            cancelButton.Enabled = true;
            if (string.IsNullOrWhiteSpace(outputFileName))
            {
                MessageBox.Show("Invalid output file name,  Please try again.");
            }
            else
            {
                 var x = await CountPrimesAsync(_cancellationToken);// why int?
                
                amountOfPrimesLabel.Text = $"Amount of primes:{x}";
                using (StreamWriter streamWriter = new StreamWriter(outputFileName.Trim() + ".txt"))
                {
                    streamWriter.WriteLine($"Amount of primes:{x}");
                }
            }
        }

        private async Task<int> CountPrimesAsync(CancellationToken cancellationToken)
        {
            var result = await Task<int>.Factory.StartNew( t=> CountPrimes(cancellationToken), cancellationToken );
            return result;
        }

        private int CountPrimes(CancellationToken cancellationToken)
        {
            bool isPrime;
            long minNum, maxNum;
            long firstNum, secondNum;
            bool inputValid;
            int amountOfPrimes;
             

            amountOfPrimes = 0;
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
                    return amountOfPrimes;
                }
                isPrime = true;
                for (int j = 2; j*j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    amountOfPrimes++;
                }
            }

            return amountOfPrimes;
        }
        
        private void cancelButton_Click(object sender, EventArgs e)
        {
            cancelButton.Enabled = false;
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
            }
        }
    }
}
