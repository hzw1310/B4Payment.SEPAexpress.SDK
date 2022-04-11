using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleCreatePaymentInline : IScenario
    {
        public string StartTitle => "Start scenario - create payment in-line";

        public string StopTitle => "Scenario is done - payment is created";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ///// 2.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Creating payment");
            var createPaymentResponse = await CreatePaymentAsync(sepaExpressClient);
        }

        public async Task<CreatePaymentHttpResponse> CreatePaymentAsync(SepaExpressClient sepaExpressClient)
        {
            var createPaymentRequest = CreatePaymentRequest();
            var createPaymentResponse = await sepaExpressClient.PaymentsPOSTAsync(createPaymentRequest);

            return createPaymentResponse;
        }

        private static CreatePaymentHttpRequest CreatePaymentRequest() =>
            new CreatePaymentHttpRequest
            {
                Amount = 12,
                CurrencyCode = "EUR",
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