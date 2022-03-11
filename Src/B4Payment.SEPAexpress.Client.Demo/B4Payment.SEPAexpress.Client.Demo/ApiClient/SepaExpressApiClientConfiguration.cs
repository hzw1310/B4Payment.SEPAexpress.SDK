using B4Payment.SEPAexpress.Client.Demo.Utils;
using System.Text.Json;

namespace B4Payment.SEPAexpress.Client.Demo.ApiClient
{
    /// <summary>
    /// That class only helps with JSON formatting in requests and responses.
    /// </summary>
    public partial class SepaExpressApiClient
    {
        partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings) => JsonClientUtil.UpdateJsonSerializerSettings(settings);

        partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url) => JsonClientUtil.PrepareRequest(client, request, url);

        partial void ProcessResponse(HttpClient client, HttpResponseMessage response) => JsonClientUtil.ProcessResponse(client, response);
    }
}