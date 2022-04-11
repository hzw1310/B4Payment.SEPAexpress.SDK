using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleGetReconciliations : IScenario
    {
        public string StartTitle => "Start scenario - get reconciliations data";

        public string StopTitle => "Scenario is done - reconciliations data is displayed";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Get reconciliations by payment");
            // create payment
            var createPaymentSample = new SampleCreatePaymentInline();
            var payment = await createPaymentSample.CreatePaymentAsync(sepaExpressClient);
            var paymentId = payment.Payment.Id;

            ///// 3.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Get reconciliations data");
            var reconciliationsData1 = await sepaExpressClient.Reconciliations2Async(paymentId: paymentId);

            ConsoleUtils.DisplayActionStart("Get reconciliations by reference");

            // ask user for reference
            var referenceId = Globals.GetUniqueString();
            ///// 3.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Get reconciliations data");
            var reconciliationsData2 = await sepaExpressClient.Reconciliations2Async(reference: referenceId);
        }
    }
}