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
            // create payment
            var createPaymentSample = new SampleCreatePaymentInline();
            var payment = await createPaymentSample.CreatePaymentAsync(sepaExpressClient);
            var paymentId = payment.Payment.Id;

            await WaitForPaymentIsCreatedAsync(sepaExpressClient, paymentId);

            ///// 6.1 create a new refund
            ConsoleUtils.DisplayActionStart("Create refund");
            var createRefundHttpRequest = CreateRefundRequest(paymentId);
            var refund = await sepaExpressClient.RefundsPOSTAsync(createRefundHttpRequest);

            // discard refund
            var discarded = await sepaExpressClient.Review4Async(refund.Refund.Id, new ReviewRefundHttpRequest
            {
                Id = refund.Refund.Id,
                Action = "reject",
                Memo = "x",
            });
        }

        private static async Task WaitForPaymentIsCreatedAsync(SepaExpressClient sepaExpressClient, string paymentId)
        {
            const int waitSencods = 40;
            for (int i = 0; i < waitSencods; i++)
            {
                Console.WriteLine($"Wait to process payment {waitSencods - i}");
                await Task.Delay(TimeSpan.FromSeconds(1)); // wait for the payment to be processed

                try
                {
                    var paymentData = await sepaExpressClient.PaymentsGET2Async(paymentId);
                    if (paymentData.Payment.State == "paid")
                    {
                        Console.WriteLine("The payment is created");
                        break;
                    }
                }
                catch (ApiException apix) when (apix.StatusCode == 404)
                {
                    Console.WriteLine("Payment is processing...");
                }
            }
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