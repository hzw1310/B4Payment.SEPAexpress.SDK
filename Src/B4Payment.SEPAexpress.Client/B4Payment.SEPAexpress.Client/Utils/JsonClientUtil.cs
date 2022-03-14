using System.Text.Json;
using System.Text.Json.Serialization;

namespace B4Payment.SEPAexpress.Client.Utils
{
    internal static class JsonClientUtil
    {
        public static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
            settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        }
    }
}
