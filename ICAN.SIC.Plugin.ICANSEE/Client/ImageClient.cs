using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ICAN.SIC.Plugin.ICANSEE.Client
{
    public class ImageClientUrlHelper
    {
        string host;
        int port;

        public ImageClientUrlHelper(string host, int port)
        {
            this.host = host;
            this.port = port;
        }

        public const string UriGetPath = "task";
        public const string UriPostTaskPath = "task";
        public const string UriDeleteTaskPath = "task";

        public string GenerateUri()
        {
            return "http://" + host + ":" + port;
        }

        public string GETUri { get { return GenerateUri() + "/" + UriGetPath; } }
        public string POSTTASKUri { get { return GenerateUri() + "/" + UriPostTaskPath; } }
        public string DELETETASKUri { get { return GenerateUri() + "/" + UriDeleteTaskPath; } }
    }

    public class ImageClient
    {
        string host;
        int port;
        ImageClientUrlHelper urlSource;
        WebClient webClient;

        public ImageClient(string host = "localhost", int port = 5000)
        {
            this.host = host;
            this.port = port;
            urlSource = new ImageClientUrlHelper(host, port);

            webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
        }

        public bool Ping()
        {
            throw new NotImplementedException();
        }

        public string MakeGetCall()
        {
            return webClient.DownloadString(urlSource.GETUri);
        }

        public string MakeGetCall(string Url)
        {
            return webClient.DownloadString(Url);
        }

        public string MakePostCall(string body)
        {
            return webClient.UploadString("http://" + host + ":" + port + "/task", body);
        }

        public string MakePostCall(string Url, string body)
        {
            return webClient.UploadString(Url, body);
        }
    }
}
