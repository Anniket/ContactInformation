using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Configuration;
using MvcClient.Helpers;

namespace MvcClient
{
    public static class ApiHelper
    {
        public static HttpClient WebApiClient = new HttpClient();

        static ApiHelper()
        {
            WebApiClient.BaseAddress = new Uri(Constants.ApiBaseUrl);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}