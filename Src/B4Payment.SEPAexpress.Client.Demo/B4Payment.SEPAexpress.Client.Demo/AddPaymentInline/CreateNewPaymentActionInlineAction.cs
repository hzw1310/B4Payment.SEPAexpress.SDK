namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInline
{
    internal class CreateNewPaymentActionInlineAction
    {
        /// <summary>
        /// Scenario:
        ///     - create payment
        ///     - display result of the operation
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync()
        {
            try
            {
                ConsoleUtils.DisplayActionStart("Creating payment");

                // create payment
                var createPaymentRequest = CreatePaymentRequest();
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createPaymentResponse = await client.PaymentsPOSTAsync(createPaymentRequest);
            }
            catch (ApiException apiex)
            {
                ConsoleUtils.DisplayException(apiex);
            }
        }

        private static CreatePaymentHttpRequest CreatePaymentRequest()
        {
            return new CreatePaymentHttpRequest
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
}