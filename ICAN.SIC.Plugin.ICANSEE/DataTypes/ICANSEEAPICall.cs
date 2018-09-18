namespace ICAN.SIC.Plugin.ICANSEE
{
    public class ICANSEEAPICall
    {
        public string uri;
        public string uriSuffix;
        public string postData;
        public string header;

        public string Uri { get { return uri; } }
        public string UriSuffix { get { return uriSuffix; } }
        public string PostData { get { return postData; } }
        public string Header { get { return header; } }

        public ICANSEEAPICall(string uri, string uriSuffix, string postData, string header)
        {
            this.uri = uri;
            this.uriSuffix = uriSuffix;
            this.postData = postData;
            this.header = header;
        }

        public void SetPostData(string postData)
        {
            this.postData = postData;
        }

        public void SetHeader(string header)
        {
            this.header = header;
        }
    }
}