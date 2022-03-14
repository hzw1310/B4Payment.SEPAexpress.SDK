using B4Payment.SEPAexpress.Client.Demo.ApiClient;
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

            var sepaExpressApiClient = new SepaExpressApiClient(Globals.BaseUrl, Globals.HttpClient);

            try
            {
                ///// 3.1 create a new payment referencing on this mandate
                ConsoleUtils.DisplayActionStart("Get payment data");
                var paymentData = await sepaExpressApiClient.PaymentsGET2Async(false, false, false, false, false, false, paymentId);
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