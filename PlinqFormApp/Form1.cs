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

namespace PlinqFormApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource cts;   
        public Form1()
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private bool Hesapla(int x)
        {
            Thread.SpinWait(500);
            return x % 12 == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Task.Run(() =>
                {
                    try
                    {
                        Enumerable.Range(1, 1000).AsParallel().WithCancellation(cts.Token).Where(Hesapla)
                            .ToList().ForEach(x =>
                            {
                                Thread.Sleep(100);
                                cts.Token.ThrowIfCancellationRequested();
                                listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(x); });
                            });
                    }
                    catch (OperationCanceledException ex)
                    {
                        MessageBox.Show("İşlem iptal edildi.");
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Genel bir hata meydana geldi");
                    }
                   
                });
           
        }
    }
}
