using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void BtnReadFile_Click(object sender, EventArgs e)
        {
            //string data =await ReadFileAsync();

            

            string data = String.Empty;

            Task<String> okuma = ReadFileAsync2();

            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");

            data = await okuma;
            
            richTextBox1.Text = data;
        }

        private void BtnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader S = new StreamReader("dosya.txt"))
            {
                //Ana bloğu bloklar ve 5 saniye bekler bu 5 saniye boyunca işlem gerçkleşene kadar herşey donar.
                Thread.Sleep(5000);


                data = S.ReadToEnd();
            }

            return data;
        }

        //Asenkron metotlar geriye birşey dönebilir veya dönmeyedebilir.
        //Asenkron metotlar geriye birşey Dönmeyecekse sadece Task keyword'ü kullanılır.
        //senkron metotta bierşey dönmeyeceksek void Keyword ünü kullanırız.
        //Senkron void Asenkron da Task
        //Senkron da string Asenkron da Task<string>
        //Kodlama kültüründe Asenkron bir metot oluşturuyorsak Metod isminin sonuna Async yazarak okunabilirliği artırırız 
        //Asenkron metot çağırımı gerçekleştireceğimiz zaman async ve await keyword'ü kullanmak zorundayız
        //Task ve await arasında yapılan işlem bağımzsızdır
        //Asenkron metotlar illaki yapacağı iş ile ilgili ek bir thread kullanmasına gerek yoktur.
      
        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Task<string> mytask = s.ReadToEndAsync();
                //10sn

                //5 saniye bekle Bir bloklama işlemi olmaz bir gescikme işlemi sağlar
                await Task.Delay(5000);

                data = await mytask;

                return data;
            }
        }


        //yapacağın ekstra bir işlem yoksa async ve await i kullanmak zorunda değilsin
        private Task<string> ReadFileAsync2()
        {
                StreamReader s = new StreamReader("dosya.txt");

                return s.ReadToEndAsync();
            
        }
    }
}
