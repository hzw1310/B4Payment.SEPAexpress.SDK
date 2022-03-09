using System.Text.Json;
using System.Text.Json.Serialization;

namespace B4Payment.SEPAexpress.Client.Demo
{
    public partial class Client
    {
        partial void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
        {
            settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        }
    }
}
