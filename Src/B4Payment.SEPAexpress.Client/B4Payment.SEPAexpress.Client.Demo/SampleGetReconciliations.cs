using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleGetReconciliations
    {
        internal async Task ExecuteAsync()
        {
            ConsoleUtils.StartStopScenario("Start scenario - get reconciliations data");

            var client = new SepaExpressClient(Globals.BaseUrl, Globals.HttpClient);

            client.PrepareRequestEvent += (object? sender, RequestEventArgs e) =>
                JsonClientUtil.PrepareRequest(e.Client, e.Request, e.Url);

            client.PrepareResponseEvent += (object? sender, ResponseEventArgs e) =>
                JsonClientUtil.ProcessResponse(e.Client, e.Response);

            try
            {
                ConsoleUtils.ShowQuestion("Get reconciliations by payment [1] or by reference [2]");
                var queryMethodSelection = ConsoleUtils.ReadCharFromUser();

                if (queryMethodSelection == '1')
                {
                    // ask user for paymentId
                    var paymentId = ConsoleUtils.GetPaymentId();
                    ///// 3.1 create a new payment referencing on this mandate
                    ConsoleUtils.DisplayActionStart("Get reconciliations data");
                    var reconciliationsData1 = await client.Reconciliations2Async(paymentId: paymentId);
                }
                else if (queryMethodSelection == '2')
                {
                    // ask user for reference
                    var referenceId = ConsoleUtils.GetReferenceId();
                    ///// 3.1 create a new payment referencing on this mandate
                    ConsoleUtils.DisplayActionStart("Get reconciliations data");
                    var reconciliationsData2 = await client.Reconciliations2Async(reference: referenceId);
                }


            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
                throw;
            }

            ConsoleUtils.StartStopScenario("Scenario is done - reconciliations data is displayed");
        }
    }
}