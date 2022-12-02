using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskCancellationFormApp
{
    public partial class Form1 : Form
    {
        CancellationTokenSource ct = new CancellationTokenSource();
        public Form1()
        {
            InitializeComponent();
        }

       

        private async void button1_Click(object sender, EventArgs e)
        {
            Task<HttpResponseMessage> mytask;
            try
            {

                mytask = new HttpClient().GetAsync("https://localhost:44366/api/home", ct.Token);

                await mytask;

                var content = await mytask.Result.Content.ReadAsStringAsync();

                richTextBox1.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  

         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
