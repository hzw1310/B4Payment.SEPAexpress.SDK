using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleGetPaymentData : IScenario
    {
        public string StartTitle => "Start scenario - get payment data";

        public string StopTitle => "Scenario is done - payment data is displayed";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            // ask user for paymentId
            var paymentId = ConsoleUtils.GetPaymentId();

            ///// 3.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Get payment data");
            var paymentData = await sepaExpressClient.PaymentsGET2Async(id: paymentId);
        }
    }
}