using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Idempotency-Keys"/>
    /// </summary>
    internal class SampleUseIdempotentKeys : IScenario
    {
        public string StartTitle => "Start scenario - use idempotent keys";

        public string StopTitle => "Scenario is done - use idempotent keys";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            var createPaymentRequest = CreatePaymentRequest();

            ConsoleUtils.DisplayActionStart("Creating payment");
            var createPaymentResponse1 = await sepaExpressClient.PaymentsPOSTAsync(createPaymentRequest);

            ConsoleUtils.DisplayActionStart("First request was successful");

            ConsoleUtils.DisplayActionStart("Creating payment again with the same idempotent key");
            var createPaymentResponse2 = await sepaExpressClient.PaymentsPOSTAsync(createPaymentRequest);
        }

        private static CreatePaymentHttpRequest CreatePaymentRequest() =>
            new CreatePaymentHttpRequest
            {
                Amount = 12,
                CurrencyCode = "EUR",
                IdempotencyKey = "1234",
                Mandate = new CreateMandateHttpRequest
                {
                    ConnectorId = Globals.ConnectorId,
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