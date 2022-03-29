using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;
using System.Threading;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Payment"/>
    /// </summary>
    internal class SampleCreateRecurringPayment : IScenario
    {
        public string StartTitle => "Start scenario - create recurring payment";

        public string StopTitle => "Scenario is done - payment is created";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ///// 2.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Creating first payment");
            var createPaymentRequest = CreatePaymentRequest();
            var createPaymentResponse = await sepaExpressClient.PaymentsPOSTAsync(createPaymentRequest);

            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                ConsoleUtils.DisplayActionStart($"Creating payment recurring payment: {i} ");
                var recurruingPaymentRequest = CreateRecurringPayment(createPaymentResponse.Payment.MandateId);
                var nextPayment = await sepaExpressClient.PaymentsPOSTAsync(recurruingPaymentRequest);
            }
        }

        private CreatePaymentHttpRequest CreateRecurringPayment(string mandateId) =>
            new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = mandateId,
                CurrencyCode = "EUR",
                Mandate = null
            };

        private static CreatePaymentHttpRequest CreatePaymentRequest() =>
            new CreatePaymentHttpRequest
            {
                Amount = 12,
                CurrencyCode = "EUR",
                Mandate = new CreateMandateHttpRequest
                {
                    ConnectorId = Globals.ConnectorId,
                    Type = "recurring",
                    BankAccount = new CreateBankAccountHttpRequest
                    {
                        Memo = "test123",
                        Iban = Globals.Iban,
                        Customer = new CreateCustomerHttpRequest
                        {
                            MerchantId = Globals.MerchandId,
                            GivenName = "Max",
                            FamilyName = "Mustermann",
                            AddressLine1 = "Musterstraße 1",
                            CountryCode = "DE",
                            LanguageCode = "DE",
                            EmailAddress = "max@mustermann.de"
                        }
                    }
                }
            };
    }
}