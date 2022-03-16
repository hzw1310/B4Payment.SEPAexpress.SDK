using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Refund"/>
    /// </summary>
    internal class SampleCreateRefund
    {
        internal async Task ExecuteAsync()
        {
            ConsoleUtils.StartStopScenario("Start scenario - create refund");

            var client = new SepaExpressClient(Globals.BaseUrl, Globals.HttpClient);

            client.PrepareRequestEvent += (object? sender, RequestEventArgs e) =>
                JsonClientUtil.PrepareRequest(e.Client, e.Request, e.Url);

            client.PrepareResponseEvent += (object? sender, ResponseEventArgs e) =>
                JsonClientUtil.ProcessResponse(e.Client, e.Response);

            try
            {
                // ask user for paymentId
                var paymentId = ConsoleUtils.GetPaymentId();

                ///// 6.1 create a new refund
                ConsoleUtils.DisplayActionStart("Create refund");
                var createRefundHttpRequest = CreateRefundRequest(paymentId);
                var refund = await client.RefundsPOSTAsync(createRefundHttpRequest);
            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
                throw;
            }

            ConsoleUtils.StartStopScenario("Scenario is done - refund is created");
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