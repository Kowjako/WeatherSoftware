using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q=Minsk&appid=387aec9952fe0d8dac04b50e87264bd8");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using(Stream s = response.GetResponseStream())
            {
                using(StreamReader sr = new StreamReader(s))
                {
                    answer = await sr.ReadToEndAsync();
                }
            }
            response.Close();
            OpenWeather.OpenWeather ow = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);
            panel1.BackgroundImage = ow.weather[0].Icon;
            label1.Text = ow.weather[0].main;
            label2.Text = "Opis : " + ow.weather[0].description;
            label3.Text = "Temperatura : " + ow.main.temp.ToString("0.##");
            label4.Text = "Wilgoc : " + ow.main.humidity.ToString() + "%";
            label5.Text = "Cisnienie : " + (ow.main.pressure).ToString("0.#");
            label6.Text = "Szybkosc wiatru : " + ow.wind.speed.ToString() + " m/s";
            label7.Text = "Kierunek : " + ow.wind.deg.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string miasto = textBox1.Text;
            WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/weather?q={miasto}&appid=387aec9952fe0d8dac04b50e87264bd8");
            request.Method = "POST";
            request.ContentType = "application/x-www-urlencoded";
            WebResponse response = await request.GetResponseAsync();
            string answer = string.Empty;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    answer = await sr.ReadToEndAsync();
                }
            }
            response.Close();
            OpenWeather.OpenWeather ow = JsonConvert.DeserializeObject<OpenWeather.OpenWeather>(answer);
            panel1.BackgroundImage = ow.weather[0].Icon;
            label1.Text = ow.weather[0].main;
            label2.Text = "Opis : " + ow.weather[0].description;
            label3.Text = "Temperatura : " + ow.main.temp.ToString("0.##");
            label4.Text = "Wilgoc : " + ow.main.humidity.ToString() + "%";
            label5.Text = "Cisnienie : " + (ow.main.pressure).ToString("0.#");
            label6.Text = "Szybkosc wiatru : " + ow.wind.speed.ToString() + " m/s";
            label7.Text = "Kierunek : " + ow.wind.deg.ToString();


        }
    }
}
