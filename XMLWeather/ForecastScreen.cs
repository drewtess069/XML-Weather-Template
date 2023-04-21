using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLWeather
{
    public partial class ForecastScreen : UserControl
    {
        public ForecastScreen()
        {
            InitializeComponent();
            displayForecast();
        }

        public void displayForecast()
        {
            date1.Text = Form1.days[0].dayOfWeek;
            date1Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].tempLow))) + "°C";
            date1Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].tempHigh))) + "°C";
            picture(Form1.days[0].weatherID, date1Icon);

            date2.Text = Form1.days[1].dayOfWeek;
            date2Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[1].tempLow))) + "°C";
            date2Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[1].tempHigh))) + "°C";
            picture(Form1.days[1].weatherID, date2Icon);

            date3.Text = Form1.days[2].dayOfWeek;
            date3Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[2].tempLow))) + "°C";
            date3Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[2].tempHigh))) + "°C";
            picture(Form1.days[2].weatherID, date3Icon);

            date4.Text = Form1.days[3].dayOfWeek;
            date4Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[3].tempLow))) + "°C";
            date4Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[3].tempHigh))) + "°C";
            picture(Form1.days[3].weatherID, date4Icon);

            date5.Text = Form1.days[4].dayOfWeek;
            date5Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[4].tempLow))) + "°C";
            date5Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[4].tempHigh))) + "°C";
            picture(Form1.days[4].weatherID, date5Icon);

            date6.Text = Form1.days[5].dayOfWeek;
            date6Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[5].tempLow))) + "°C";
            date6Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[5].tempHigh))) + "°C";
            picture(Form1.days[5].weatherID, date6Icon);

            date7.Text = Form1.days[6].dayOfWeek;
            date7Min.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[6].tempLow))) + "°C";
            date7Max.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[6].tempHigh))) + "°C";
            picture(Form1.days[6].weatherID, date7Icon);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            CurrentScreen cs = new CurrentScreen();
            f.Controls.Add(cs);
        }

        public void picture(string idNumber, PictureBox p)
        {
            int id = Convert.ToInt32(idNumber);

            if(id >=200 && id <= 232)
            {
                //thunderstorm
                p.BackgroundImage = Properties.Resources.thunder;
            }
            else if(id >= 300 && id<= 531)
            {
                //rain
                p.BackgroundImage = Properties.Resources.rain;
            }
            else if(id >= 600 && id <= 622)
            {
                //snow
                p.BackgroundImage = Properties.Resources.cold;
            }
            else if(id >= 700 && id <= 781)
            {
                //atmosphere
                p.BackgroundImage = Properties.Resources.wind;
            }
            else if(id == 800)
            {
                //clear sky
                p.BackgroundImage = Properties.Resources.clear;
            }
            else if(id >=801 && id <= 804)
            {
                //cloudy
                p.BackgroundImage = Properties.Resources.cloud;
            }
        } 
    }
}
