using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;
using PuppeteerSharp;

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
        }

        private async Task ViewHostedPageAsync(string hostedPageId)
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            await using var page = await browser.NewPageAsync();
            var pageUrl = $"{Globals.BaseUrl}/api/services/v2/HostedPages/{hostedPageId}/sample";
            await page.GoToAsync(pageUrl);
            var pageHtml = await page.GetContentAsync();

            Console.WriteLine("----- Hosted page: -----");
            Console.WriteLine(pageHtml);
            
            Console.WriteLine();
            Console.WriteLine("----- Simulate user confirmation: -----");
            await page.ClickAsync("#sepaExpressButton");
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