using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;
using System.Threading.Tasks;

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
            ConsoleUtils.ShowQuestion("Get reconciliations by payment [1] or by reference [2]");
            var queryMethodSelection = ConsoleUtils.ReadCharFromUser();

            if (queryMethodSelection == '1')
            {
                // ask user for paymentId
                var paymentId = ConsoleUtils.GetPaymentId();
                ///// 3.1 create a new payment referencing on this mandate
                ConsoleUtils.DisplayActionStart("Get reconciliations data");
                var reconciliationsData1 = await sepaExpressClient.Reconciliations2Async(paymentId: paymentId);
            }
            else if (queryMethodSelection == '2')
            {
                // ask user for reference
                var referenceId = ConsoleUtils.GetReferenceId();
                ///// 3.1 create a new payment referencing on this mandate
                ConsoleUtils.DisplayActionStart("Get reconciliations data");
                var reconciliationsData2 = await sepaExpressClient.Reconciliations2Async(reference: referenceId);
            }
        }
    }
}