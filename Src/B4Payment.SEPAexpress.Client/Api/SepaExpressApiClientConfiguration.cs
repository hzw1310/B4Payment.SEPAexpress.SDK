using B4Payment.SEPAexpress.Client.Utils;
using System;
using System.Net.Http;
using System.Text.Json;

namespace B4Payment.SEPAexpress.Client.Api
{
    /// <summary>
    /// That class only helps with JSON formatting in requests and responses.
    /// </summary>
    public partial class SepaExpressClient
    {
        public event EventHandler<RequestEventArgs> PrepareRequestEvent;

        public event EventHandler<ResponseEventArgs> PrepareResponseEvent;

        partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => 
            JsonClientUtil.UpdateJsonSerializerSettings(settings);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) =>
            PrepareRequestEvent?.Invoke(this, new RequestEventArgs(client, request, url));

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response) =>
            PrepareResponseEvent?.Invoke(this, new ResponseEventArgs(client, response));
    }
}