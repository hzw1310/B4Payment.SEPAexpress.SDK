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

            ConsoleUtils.DisplayActionStart("Reinstate mandate");
            var reinstatedMandate = await sepaExpressClient.ReinstateAsync(createMandateResponse.Mandate.Id);

            ConsoleUtils.DisplayActionStart("Resend approval tan");
            var resendResponse = await sepaExpressClient.ResendAsync(createMandateResponse.Mandate.Id);

            ConsoleUtils.DisplayActionStart("Approve mandate");
            string tan = "x";
            var approvedMandate = await sepaExpressClient.ApproveAsync(
                createMandateResponse.Mandate.Id,
                new ApproveMandateHttpRequest
                {
                    Tan = tan,
                    Memo = "memo note"
                });

            ConsoleUtils.DisplayActionStart("Accept or reject mandate");
            var mandateReview = await sepaExpressClient.ReviewAsync(
                createMandateResponse.Mandate.Id,
                new ReviewMandateHttpRequest
                {
                    Action = "accept" // or "reject"
                });
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