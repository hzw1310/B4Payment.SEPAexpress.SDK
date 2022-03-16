using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleGetPaymentData
    {
        internal async Task GetPaymentDataAsync()
        {
            ConsoleUtils.StartStopScenario("Start scenario - get payment data");

            // ask user for paymentId
            var paymentId = ConsoleUtils.GetPaymentId();

            var client = new SepaExpressClient(Globals.BaseUrl, Globals.HttpClient);

            client.PrepareRequestEvent += (object? sender, RequestEventArgs e) =>
                JsonClientUtil.PrepareRequest(e.Client, e.Request, e.Url);

            client.PrepareResponseEvent += (object? sender, ResponseEventArgs e) =>
                JsonClientUtil.ProcessResponse(e.Client, e.Response);

            try
            {
                ///// 3.1 create a new payment referencing on this mandate
                ConsoleUtils.DisplayActionStart("Get payment data");
                var paymentData = await client.PaymentsGET2Async(id: paymentId);
            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
                throw;
            }

            ConsoleUtils.StartStopScenario("Scenario is done - payment data is displayed");
        }
    }
}