using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Refund"/>
    /// </summary>
    internal class SampleCreateRefund : IScenario
    {
        public string StartTitle => "Start scenario - create refund";

        public string StopTitle => "Scenario is done - refund is created";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            // ask user for paymentId
            var paymentId = ConsoleUtils.GetPaymentId();

            ///// 6.1 create a new refund
            ConsoleUtils.DisplayActionStart("Create refund");
            var createRefundHttpRequest = CreateRefundRequest(paymentId);
            var refund = await sepaExpressClient.RefundsPOSTAsync(createRefundHttpRequest);
        }

        private CreateRefundHttpRequest CreateRefundRequest(string paymentId) =>
            new CreateRefundHttpRequest
            {
                PaymentId = paymentId,
                CurrencyCode = "EUR",
                Amount = 1,
                SoftDescriptor = "refunding the voll after"
            };
    }
}