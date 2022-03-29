using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class SampleHostedPages : IScenario
    {
        public string StartTitle => "Start scenario - hosted pages";

        public string StopTitle => "Scenario is done - hosted pages";

        /// <summary>
        /// Hosted pages usage <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/HostedPages"/>
        /// </summary>
        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            ///// create a hosted page
            ConsoleUtils.DisplayActionStart("Creating a new hosted page");
            var createHostedPageHttpRequest = GetCreateHostedPageHttpRequest();
            var hostedPage = await sepaExpressClient.HostedPagesPOSTAsync(createHostedPageHttpRequest);
        }

        private CreateHostedPageHttpRequest GetCreateHostedPageHttpRequest() =>
            new CreateHostedPageHttpRequest
            {
                Type = "createMandate",
                Memo = "x",
                Mandate = CreateMandateRequest()
            };

        private CreateMandateHttpRequest CreateMandateRequest() =>
            new CreateMandateHttpRequest
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
            };
    }
}