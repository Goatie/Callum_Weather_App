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
using RestSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace AssessmentWeatherApp
{
    class RESTHandlerForecast
    {
        private string url;
        private IRestResponse response;
        private RestRequest request;

        public RESTHandlerForecast()
        {
            url = "";
        }
        public RESTHandlerForecast(string lurl)
        {
            url = lurl;
            request = new RestRequest();
        }
        public void AddParameter(string name, string value)
        {
            if (request != null)
            {
                request.AddParameter(name, value);
            }
        }
        public ResponseForecast.RootObjectForecast ExecuteRequestForecast()
        {
            var client = new RestClient(url);

            response = client.Execute(request);

            ResponseForecast.RootObjectForecast objRootForecast = new ResponseForecast.RootObjectForecast();
            objRootForecast = JsonConvert.DeserializeObject<ResponseForecast.RootObjectForecast>(response.Content);

            return  objRootForecast;
        }
        public async Task<ResponseForecast.RootObjectForecast> ExecuteRequestAsync()
        {
            var client = new RestClient(url);
            var request = new RestRequest();

            response = await client.ExecuteTaskAsync(request);

            ResponseForecast.RootObjectForecast objRootForecast = new ResponseForecast.RootObjectForecast();
            objRootForecast = JsonConvert.DeserializeObject<ResponseForecast.RootObjectForecast>(response.Content);

            return objRootForecast;
        }
    }
}