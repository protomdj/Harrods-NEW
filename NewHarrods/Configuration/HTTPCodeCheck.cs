using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewHarrods.Configuration
{
    public class HTTPCodeCheck
    {
        public string GetStatusCode(string href)
        { //HTTP checking service config    
            try
            {
                ServicePointManager.UseNagleAlgorithm = true;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.CheckCertificateRevocationList = true;
                ServicePointManager.DefaultConnectionLimit = 2000;
                //HTTP response check
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(href);
                //webRequest.AllowAutoRedirect = false;
                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                string returnresponse = response.StatusCode.ToString();
                return returnresponse;
            }
            catch(Exception e)
            {
                string error = "Error Code Found : " + e;
                return error;
            }
        }
    }
}
