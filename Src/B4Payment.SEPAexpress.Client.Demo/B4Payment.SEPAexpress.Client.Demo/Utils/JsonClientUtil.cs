using System.Text.Json;
using System.Text.Json.Serialization;

namespace B4Payment.SEPAexpress.Client.Demo.Utils
{
    internal static class JsonClientUtil
    {
        public static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
            settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        }

        public static void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
        {
            var jsonBody = request.Content?.ReadAsStringAsync().Result ?? "";
            var jsonDocument = JsonDocument.Parse(jsonBody);
            ConsoleUtils.DisplayRequestObject(url, jsonDocument);
        }

        public static void ProcessResponse(HttpClient client, HttpResponseMessage response)
        {
            if (response != null && response.IsSuccessStatusCode)
            {
                var requestUri = response?.RequestMessage?.RequestUri?.ToString() ?? "";
                var jsonBody = response.Content.ReadAsStringAsync().Result ?? "";

                var jsonDocument = JsonDocument.Parse(jsonBody);

                ConsoleUtils.DisplayResponseObject(requestUri, jsonDocument);
            }
        }
    }
}
