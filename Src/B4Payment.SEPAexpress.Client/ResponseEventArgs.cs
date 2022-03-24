using System;
using System.Net.Http;

namespace B4Payment.SEPAexpress.Client
{
    public class ResponseEventArgs: EventArgs
    {
        public ResponseEventArgs(HttpClient client, HttpResponseMessage response)
        {
            Client = client;
            Response = response;
        }

        public HttpClient Client { get; }
        public HttpResponseMessage Response { get; }
    }
}