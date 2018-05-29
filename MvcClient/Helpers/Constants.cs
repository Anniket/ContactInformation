using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MvcClient.Helpers
{
    public class Constants
    {
        public static string ApiBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["apiBaseUrl"].ToString();
            }
        }
    }
}