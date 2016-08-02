using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimesCalculator
{
    public partial class PrimesCalculatorForm : Form
    {
        public static CancellationTokenSource CancellationTokenSource;

        public static CancellationToken CancellationToken;
    
        public List<long> ListOfPrimes { get; private set; }

        public PrimesCalculatorForm()
        {
            ListOfPrimes = new List<long>();
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            
            Thread t = new Thread(CalcPrimes);
            primeNumbersListBox.DataSource = null;
            var synchronizationContext = SynchronizationContext.Current;
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken = CancellationTokenSource.Token;

            Task.Run(() =>
            {
                CalcPrimes();
                synchronizationContext.Send(o =>
                {
                    primeNumbersListBox.DataSource = ListOfPrimes;
                }, null);
            });
            

        }

        private void CalcPrimes()
        {
            bool isPrime;
            long minNum, maxNum;
            long firstNum, secondNum;
            bool inputValid;

            ListOfPrimes.Clear();
            
            inputValid = long.TryParse(firstNumTextBox.Text, out firstNum);
            inputValid = long.TryParse(secondNumTextBox.Text, out secondNum) && inputValid;

            if (!inputValid)
            {

                MessageBox.Show(
                        "Input is not valid. Please try again.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

            minNum = Math.Min(firstNum, secondNum);
            maxNum = Math.Max(firstNum, secondNum);

            minNum = minNum < 1 ? 2 : minNum;
            for (long i = minNum; i <= maxNum; i++)
            {
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
                    ListOfPrimes.Add(i);
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();
        }
    }
}
