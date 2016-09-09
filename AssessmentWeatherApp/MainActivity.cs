using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AssessmentWeatherApp
{
    [Activity(Label = "AssessmentWeatherApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        RESTHandler objRest;
        RESTHandlerForecast objRestFor;
        RootObject objRootList;
        ResponseForecast.RootObjectForecast objRootListFor;

        ListView lvForecast;

        List<ResponseForecast.List> lstForecast;

        TextView txtMax, txtMin, txtTemp, txtCity, txtDateTime, txtMessage;

        ImageView imgCondition;

        string temp, tempMax, tempMin, message, icon, Location;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            
            lvForecast = FindViewById<ListView>(Resource.Id.lvForecast);

            

            txtMax = FindViewById<TextView>(Resource.Id.txtMax);
            txtMin = FindViewById<TextView>(Resource.Id.txtMin);
            txtTemp = FindViewById<TextView>(Resource.Id.txtTemp);
            txtCity = FindViewById<TextView>(Resource.Id.txtCity);
            txtDateTime = FindViewById<TextView>(Resource.Id.txtDateTime);
            txtMessage = FindViewById<TextView>(Resource.Id.txtMessage);
            imgCondition = FindViewById<ImageView>(Resource.Id.imgCondition);

            try
            {
                Location = "Hamilton";
                LoadWeatherByLocation(Location);               

            }
            catch (Exception e)
            {
                Toast.MakeText(this, "Error : " + e.Message, ToastLength.Long);
            }
        }       
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            menu.Add("Auckland");
            menu.Add("Christchurch");
            menu.Add("Hamilton");
            menu.Add("Wellington");
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {

            var itemTitle = item.TitleFormatted.ToString();            

            switch (itemTitle)
            {
                case "Auckland":
                    Location = "Auckland";
                    LoadWeatherByLocation(Location);
                    break;

                case "Christchurch":
                    Location = "Christchurch";
                    LoadWeatherByLocation(Location);
                    break;

                case "Hamilton":
                    Location = "Hamilton";
                    LoadWeatherByLocation(Location);
                    break;

                case "Wellington":
                    Location = "Wellington";
                    LoadWeatherByLocation(Location);
                    break;
            }
            

            return base.OnOptionsItemSelected(item);
        }

        public void LoadWeatherByLocation(string city)
        {
            objRest = new RESTHandler(@"http://api.openweathermap.org/data/2.5/weather?");

            objRest.AddParameter("q", city +",NZ");
            objRest.AddParameter("units", "metric");
            objRest.AddParameter("appid", "5284e966d7b963bd0b0ae0e0b339492d");

            objRootList = objRest.ExecuteRequest();

            temp = objRootList.main.temp.ToString();
            txtTemp.Text = temp + "°C";

            tempMin = objRootList.main.temp_min.ToString() + "°C";
            txtMin.Text = tempMin;

            tempMax = objRootList.main.temp_max.ToString() + "°C";
            txtMax.Text = tempMax;

            city = objRootList.name;
            txtCity.Text = city;

            string currenttime = DateTime.Now.AddHours(16).ToString("dd'/'MM'/'yyyy HH:mm:ss");
            txtDateTime.Text = currenttime;

            message = objRootList.weather[0].description.ToString();
            txtMessage.Text = message;

            icon = objRootList.weather[0].icon;


//***************************************************************************************************************************************************************


            objRestFor = new RESTHandlerForecast(@"http://api.openweathermap.org/data/2.5/forecast/daily?");
            objRestFor.AddParameter("q", city +",NZ");
            objRestFor.AddParameter("units", "metric");
            objRestFor.AddParameter("cnt", "6");
            objRestFor.AddParameter("appid", "5284e966d7b963bd0b0ae0e0b339492d");

            objRootListFor = objRestFor.ExecuteRequestForecast();
            lstForecast = objRootListFor.list;
            lvForecast.Adapter = new DataAdapter(this, lstForecast);

            FindImage(icon);
        }

//***************************************************************************************************************************************************************

        private void FindImage(string Icon)
        {
            if (Icon == "01d")
            {
                imgCondition.SetImageResource(Resource.Drawable.ClearDay);
            }
            else if (Icon == "02d")

            {
                imgCondition.SetImageResource(Resource.Drawable.Overcast);
            }
            else if (Icon == "03d")

            {
                imgCondition.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "04d")

            {
                imgCondition.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "09d")

            {
                imgCondition.SetImageResource(Resource.Drawable.RainLight);
            }
            else if (Icon == "10d")

            {
                imgCondition.SetImageResource(Resource.Drawable.Rain);
            }
            else if (Icon == "11d")

            {
                imgCondition.SetImageResource(Resource.Drawable.Thunder);
            }
            else if (Icon == "13d")

            {
                imgCondition.SetImageResource(Resource.Drawable.SnowHeavy);
            }
            else if (Icon == "50d")

            {
                imgCondition.SetImageResource(Resource.Drawable.FogHeavy);
            }
            else if (Icon == "01n")

            {
                imgCondition.SetImageResource(Resource.Drawable.ClearNight);
            }
            else if (Icon == "02n")

            {
                imgCondition.SetImageResource(Resource.Drawable.CloudyNight);
            }
            else if (Icon == "03n")

            {
                imgCondition.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "04n")

            {
                imgCondition.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "09n")

            {
                imgCondition.SetImageResource(Resource.Drawable.RainLight);
            }
            else if (Icon == "10n")

            {
                imgCondition.SetImageResource(Resource.Drawable.Rain);
            }
            else if (Icon == "11n")

            {
                imgCondition.SetImageResource(Resource.Drawable.Thunder);
            }
            else if (Icon == "13n")

            {
                imgCondition.SetImageResource(Resource.Drawable.SnowHeavy);
            }
            else if (Icon == "50n")

            {
                imgCondition.SetImageResource(Resource.Drawable.FogHeavy);
            }
            else
            {
                imgCondition.SetImageResource(Resource.Drawable.Unknown);
            }

        }

    }       
        
 }

        



