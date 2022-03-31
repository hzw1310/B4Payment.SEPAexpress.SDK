using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/LocalizationTexts"/>
    /// </summary>
    internal class SampleGetLocalizationText : IScenario
    {
        public string StartTitle => "Start scenario - get localization text";

        public string StopTitle => "Scenario is done - get localization text";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Get localization text");
            var localizationTextResponse = await sepaExpressClient.LocalizationTextsAsync(
                key: "mandateIbanHl",
                languageCode: "de",
                countryCode: "de"
                );
        }
    }
}