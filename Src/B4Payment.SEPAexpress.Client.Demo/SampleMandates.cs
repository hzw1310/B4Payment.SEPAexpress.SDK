using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Mandate"/>
    /// </summary>
    internal class SampleMandates : IScenario
    {
        public string StartTitle => "Start scenario - approve / discard mandate";

        public string StopTitle => "Scenario is done - approve / discard mandate";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ConsoleUtils.DisplayActionStart("Creating mandate");
            var createMandateRequest = CreateMandateRequest();
            var createMandateResponse = await sepaExpressClient.MandatesPOSTAsync(createMandateRequest);

            ConsoleUtils.DisplayActionStart("Discard mandate");
            var discardedMandate = await sepaExpressClient.DiscardAsync(createMandateResponse.Mandate.Id);
        }

        private static CreateMandateHttpRequest CreateMandateRequest() =>
            new CreateMandateHttpRequest
            {
                ConnectorId = Globals.ConnectorId,
                ApprovalBy = "email",
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