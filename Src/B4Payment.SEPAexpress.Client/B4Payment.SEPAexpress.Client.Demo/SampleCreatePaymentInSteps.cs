using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class SampleCreatePaymentInSteps : IScenario
    {
        public string StartTitle => "Start scenario - create payment in steps";

        public string StopTitle => "Scenario is done - payment is created";

        /// <summary>
        /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
        /// </summary>
        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            // optionally you can add your reference identifier
            var referenceId = Guid.NewGuid().ToString().Replace("-", string.Empty);

            ///// 1.1 create a new customer
            ConsoleUtils.DisplayActionStart("Creating customer");
            var createCustomerHttpRequest = CreateCustomerHttpRequest();
            var createCustomerResponse = await sepaExpressClient.CustomersPOSTAsync(createCustomerHttpRequest);

            ///// 1.2 create a new bank account for this customer
            ConsoleUtils.DisplayActionStart("Creating bank account");
            var createNewBankAccountRequest = CreateBankAccountRequest(createCustomerResponse.Customer.Id);
            var createBankAccountResponse = await sepaExpressClient.BankAccountsPOSTAsync(createNewBankAccountRequest);

            ///// 1.3 create a new mandate for this bank account
            ConsoleUtils.DisplayActionStart("Creating mandate");
            var createMandateRequest = CreateMandateRequest(createBankAccountResponse.BankAccount.Id, referenceId);
            var createMandateResponse = await sepaExpressClient.MandatesPOSTAsync(createMandateRequest);

            ///// 1.4 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Creating payment");
            var createPaymentRequest = CreatePaymentRequest(createMandateResponse.Mandate.Id, referenceId);
            var createPaymentResponse = await sepaExpressClient.PaymentsPOSTAsync(createPaymentRequest);
        }

        private CreateCustomerHttpRequest CreateCustomerHttpRequest() =>
            new CreateCustomerHttpRequest
            {
                MerchantId = Globals.MerchandId,
                GivenName = "Max",
                FamilyName = "Mustermann",
                AddressLine1 = "Musterstraße 1",
                CountryCode = "DE",
                LanguageCode = "DE",
                EmailAddress = "max@mustermann.de"
            };

        private CreateBankAccountHttpRequest CreateBankAccountRequest(string customerId) =>
            new CreateBankAccountHttpRequest
            {
                Memo = "test999",
                Iban = Globals.Iban,
                CustomerId = customerId,
                Customer = null
            };

        private CreateMandateHttpRequest CreateMandateRequest(string bankAccountId, string referenceId) =>
            new CreateMandateHttpRequest
            {
                BankAccountId = bankAccountId,
                ConnectorId = Globals.ConnectorId,
                Memo = "test999 1",
                ApprovalBy = "click",
                Amount = 1900,
                CurrencyCode = "EUR",
                BankAccount = null,
                Reference = referenceId
            };

        private static CreatePaymentHttpRequest CreatePaymentRequest(string mandateId, string referenceId) =>
            new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = mandateId,
                CurrencyCode = "EUR",
                Mandate = null,
                Reference = referenceId
            };
    }
}