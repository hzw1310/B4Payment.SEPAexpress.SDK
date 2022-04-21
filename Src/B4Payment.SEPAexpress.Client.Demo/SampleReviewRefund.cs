using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleReviewRefund : IScenario
    {
        public string StartTitle => "Start scenario - review refund";

        public string StopTitle => "Scenario is done - review refund";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Accept refund");
            string refundId = string.Empty;

            var refund = await sepaExpressClient.Review4Async(
                refundId,
                new ReviewRefundHttpRequest
                {
                    Action = "accept", // or "reject"
                    Memo = "memo note"
                });
        }

    }
}