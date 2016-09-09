using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Net;
using Android.Graphics;
using Java.IO;
using Android.Graphics.Drawables;
using Android.Util;
using System.Net;
using System.IO;
using SQLite;

namespace AssessmentWeatherApp
{

    public class DataAdapter : BaseAdapter<ResponseForecast.List>
    {

        ImageView imgConditionForecast;

        List<ResponseForecast.List> items;

        Activity context;
        public DataAdapter(Activity context, List<ResponseForecast.List> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override ResponseForecast.List this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            string iconForecast;
            MainActivity objMainActivity = new MainActivity();

            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            //UnixTimeStampToDateTime(item.list[0].dt);

            //view.FindViewById<TextView>(Resource.Id.txtDate).Text = ;

            view.FindViewById<TextView>(Resource.Id.txtDate).Text = UnixTimeStampToDateTime(item.dt).ToString("dd'/'MM'/'yyyy HH:mm:ss");

            view.FindViewById<TextView>(Resource.Id.txtCondition).Text = item.weather[0].description.ToString();

            view.FindViewById<TextView>(Resource.Id.txtMax).Text = item.temp.max.ToString() + "°C";

            view.FindViewById<TextView>(Resource.Id.txtMin).Text = item.temp.min.ToString() + "°C";

            view.FindViewById<TextView>(Resource.Id.txtMorning).Text ="Morning : " + item.temp.morn.ToString() + "°C";

            view.FindViewById<TextView>(Resource.Id.txtDay).Text = "Day : " + item.temp.day.ToString() + "°C";

            view.FindViewById<TextView>(Resource.Id.txtEvening).Text = "Evening : " + item.temp.eve.ToString() + "°C";

            view.FindViewById<TextView>(Resource.Id.txtNight).Text = "Night : " + item.temp.night.ToString() + "°C";

            

            iconForecast = item.weather[0].icon.ToString();
            imgConditionForecast = view.FindViewById<ImageView>(Resource.Id.imgConditionForecast);

            FindImageForecast(iconForecast);

            return view;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();


            return dtDateTime;
        }

        private void FindImageForecast(string Icon)
        {
            if (Icon == "01d")
            {
                imgConditionForecast.SetImageResource(Resource.Drawable.ClearDay);
            }
            else if (Icon == "02d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Overcast);
            }
            else if (Icon == "03d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "04d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "09d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.RainLight);
            }
            else if (Icon == "10d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Rain);
            }
            else if (Icon == "11d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Thunder);
            }
            else if (Icon == "13d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.SnowHeavy);
            }
            else if (Icon == "50d")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.FogHeavy);
            }
            else if (Icon == "01n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.ClearDay);
            }
            else if (Icon == "02n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Overcast);
            }
            else if (Icon == "03n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "04n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Cloudy);
            }
            else if (Icon == "09n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.RainLight);
            }
            else if (Icon == "10n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Rain);
            }
            else if (Icon == "11n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Thunder);
            }
            else if (Icon == "13n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.SnowHeavy);
            }
            else if (Icon == "50n")

            {
                imgConditionForecast.SetImageResource(Resource.Drawable.FogHeavy);
            }
            else
            {
                imgConditionForecast.SetImageResource(Resource.Drawable.Unknown);
            }

        }

    }
}