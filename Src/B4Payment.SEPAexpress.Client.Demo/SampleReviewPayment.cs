using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleReviewPayment : IScenario
    {
        public string StartTitle => "Start scenario - review payment";

        public string StopTitle => "Scenario is done - review payment";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Accept payment");
            string paymentId = string.Empty;

            var payment = await sepaExpressClient.Review2Async(
                paymentId,
                new ReviewPaymentHttpRequest
                {
                    Action = "accept", // or "reject"
                    Memo = "memo note"
                });
        }

    }
}