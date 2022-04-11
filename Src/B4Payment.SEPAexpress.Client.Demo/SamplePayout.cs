using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class SamplePayout : IScenario
    {
        public string StartTitle => "Start scenario - payout";

        public string StopTitle => "End scenario - payout";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Create payout in-line");
            var createPayoutRequest = CreatePayoutRequest();
            var createPayoutResponse = sepaExpressClient.PayoutsPOSTAsync(createPayoutRequest);
        }

        private CreatePayoutHttpRequest CreatePayoutRequest() =>
            new CreatePayoutHttpRequest
            {
                ConnectorId = Globals.ConnectorId,
                CurrencyCode = "EUR",
                Amount = 1,
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
            };
    }
}
