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
    public partial class CurrentScreen : UserControl
    {
        public CurrentScreen()
        {
            InitializeComponent();
            DisplayCurrent();
        }

        public void DisplayCurrent()
        {
            Refresh();

            cityOutput.Text = Form1.days[0].location.ToString();
            currentOutput.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].currentTemp))) + "°C";

            minOutput.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].tempLow))) + "°C";
            maxOutput.Text = Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].tempHigh))) + "°C";

            feelLabel.Text = "Feels Like: \n\n" + Convert.ToString(Math.Round(Convert.ToDouble(Form1.days[0].feelsLike))) + "°C";
            humidityLabel.Text = "Humidity: \n\n" + Form1.days[0].humidity + "%";
            windLabel.Text = "Wind: \n" + Form1.days[0].windSpeed + "m/s\n" + Form1.days[0].windDirection;
            visibleLabel.Text = "Pressure: \n\n" + Form1.days[0].pressure + " hPa";

            int id = Convert.ToInt32(Form1.days[0].weatherID);

            if (id >= 200 && id <= 232)
            {
                //thunderstorm
                this.BackgroundImage = Properties.Resources.thunder1;
            }
            else if (id >= 300 && id <= 531)
            {
                //rain
                this.BackgroundImage = Properties.Resources.rain1;
            }
            else if (id >= 600 && id <= 622)
            {
                //snow
                this.BackgroundImage = Properties.Resources.snow;
            }
            else if (id >= 700 && id <= 781)
            {
                //atmosphere
                this.BackgroundImage = Properties.Resources.windy;
            }
            else if (id == 800)
            {
                //clear sky
                this.BackgroundImage = Properties.Resources.sun;
            }
            else if (id >= 801 && id <= 804)
            {
                //cloudy
                this.BackgroundImage = Properties.Resources.cloud1;
            }
        }

        private void forecastLabel_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);

            ForecastScreen fs = new ForecastScreen();
            f.Controls.Add(fs);
        }

        private void CurrentScreen_Paint(object sender, PaintEventArgs e)
        {
            Pen whitePen = new Pen(Color.White, 5);
            Rectangle humidityRec = new Rectangle(humidityLabel.Location.X, humidityLabel.Location.Y, humidityLabel.Width, humidityLabel.Height);
            e.Graphics.DrawRectangle(whitePen, humidityRec);

            Rectangle windRec = new Rectangle(windLabel.Location.X, windLabel.Location.Y, windLabel.Width, windLabel.Height);
            e.Graphics.DrawRectangle(whitePen, windRec);

            Rectangle feelRec = new Rectangle(feelLabel.Location.X, feelLabel.Location.Y, feelLabel.Width, feelLabel.Height);
            e.Graphics.DrawRectangle(whitePen, feelRec);

            Rectangle visibleRec = new Rectangle(visibleLabel.Location.X, visibleLabel.Location.Y, visibleLabel.Width, visibleLabel.Height);
            e.Graphics.DrawRectangle(whitePen, visibleRec);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            citySearch.Visible = true;
            countrySearch.Visible = true;

            cityOutput.Visible = false;

            citySearch.Focus();


        }

        private void citySearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && citySearch.Text != "")
            {
                countrySearch.Focus(); ;

            }
        }

        private void countrySearch_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && citySearch.Text != "")
            {
                string currentCity = Form1.city;
                string currentCountry = Form1.country;
                try
                {
                    Form1.country = countrySearch.Text;
                    Form1.city = citySearch.Text;

                    Form1.days.Clear();
                    Form1.ExtractForecast();
                    Form1.ExtractCurrent();

                    DisplayCurrent();

                    citySearch.Visible = false;
                    countrySearch.Visible = false;

                    cityOutput.Visible = true;

                    cityOutput.Text = Form1.city;

                    citySearch.Clear();
                    countrySearch.Clear();
                }
                catch
                {
                    citySearch.Clear();
                    countrySearch.Clear();

                    citySearch.Visible = false;
                    countrySearch.Visible = false;

                    cityOutput.Visible = true;

                    Form1.city = currentCity;
                    Form1.country = currentCountry;

                    Form1.ExtractForecast();
                    Form1.ExtractCurrent();
                }
            }
        }
    }
}
