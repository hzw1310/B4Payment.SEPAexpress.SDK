using System;
using System.Net.Http;

namespace B4Payment.SEPAexpress.Client
{
    public class RequestEventArgs: EventArgs
    {
        public RequestEventArgs(HttpClient client, HttpRequestMessage request, string url)
        {
            Client = client;
            Request = request;
            Url = url;
        }

        public HttpClient Client { get; }
        public HttpRequestMessage Request { get; }
        public string Url { get; }
    }
}