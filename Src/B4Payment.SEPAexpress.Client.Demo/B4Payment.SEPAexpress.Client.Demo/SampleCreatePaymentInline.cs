﻿using B4Payment.SEPAexpress.Client.Demo.ApiClient;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
    /// </summary>
    internal class SampleCreatePaymentInline
    {
        internal async Task CreatePaymentInlineAsync()
        {
            ConsoleUtils.StartStopScenario("Start scenario - create payment in-line");

            var sepaExpressApiClient = new SepaExpressApiClient(Globals.BaseUrl, Globals.HttpClient);

            ///// 2.1 create a new payment referencing on this mandate
            ConsoleUtils.DisplayActionStart("Creating payment");
            var createPaymentRequest = CreatePaymentRequest();
            var createPaymentResponse = await sepaExpressApiClient.PaymentsPOSTAsync(createPaymentRequest);

            ConsoleUtils.StartStopScenario("Scenario is done - payment is created");
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