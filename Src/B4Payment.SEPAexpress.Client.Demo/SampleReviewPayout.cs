using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleReviewPayout : IScenario
    {
        public string StartTitle => "Start scenario - review payout";

        public string StopTitle => "Scenario is done - review payout";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Accept payout");
            string payoutId = string.Empty;

            var payout = await sepaExpressClient.Review3Async(
                payoutId,
                new ReviewPayoutHttpRequest
                {
                    Action = "accept", // or "reject"
                    Memo = "memo note"
                });
        }

    }
}