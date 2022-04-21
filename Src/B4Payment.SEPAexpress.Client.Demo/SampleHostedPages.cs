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

            //// view a hosted page
            ConsoleUtils.DisplayActionStart("Get hosted page HTML");
            await ViewHostedPageAsync(hostedPage.HostedPage.Id);

            await ViewHostedPage1Async(sepaExpressClient, hostedPage.HostedPage.Id);
        }

        private async Task ViewHostedPageAsync(string hostedPageId)
        {
            var pageUrl = $"{Globals.BaseUrl}/api/services/v2/HostedPages/{hostedPageId}/sample";
            var pageResponse = await Globals.HttpClient.GetAsync(pageUrl);
            var pageHtml = await pageResponse.Content.ReadAsStringAsync();

            Console.WriteLine(pageHtml);
        }

        private async Task ViewHostedPage1Async(SepaExpressClient sepaExpressClient, string hostedPageId)
        {
            const string successUrl = "https://succesUrl.com";
            const string failureUrl = "https://failedUrl.com";
            try
            {
                await sepaExpressClient.ViewAsync(hostedPageId, successUrl, failureUrl);
            }
            catch (ApiException apix) when (apix.Message == "HTTP redirect.")
            {
                Console.WriteLine($"Redirect {apix.Response}");
            }
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
                ApprovalBy = "click",
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