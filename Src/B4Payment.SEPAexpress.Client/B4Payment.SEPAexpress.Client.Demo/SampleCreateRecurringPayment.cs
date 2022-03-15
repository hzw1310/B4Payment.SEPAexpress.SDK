using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Scenario create payment <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Payment"/>
    /// </summary>
    internal class SampleCreateRecurringPayment
    {
        internal async Task ExecuteAsync()
        {
            ConsoleUtils.StartStopScenario("Start scenario - create recurring payment");

            var sepaExpressApiClient = new SepaExpressClient(Globals.BaseUrl, Globals.HttpClient);
            sepaExpressApiClient.PrepareRequestEvent += (object? sender, RequestEventArgs e) =>
                JsonClientUtil.PrepareRequest(e.Client, e.Request, e.Url); 

            sepaExpressApiClient.PrepareResponseEvent += (object? sender, ResponseEventArgs e) =>
                JsonClientUtil.ProcessResponse(e.Client, e.Response); 

            try
            {
                ///// 2.1 create a new payment referencing on this mandate
                ConsoleUtils.DisplayActionStart("Creating first payment");
                var createPaymentRequest = CreatePaymentRequest();
                var createPaymentResponse = await sepaExpressApiClient.PaymentsPOSTAsync(createPaymentRequest);

                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    ConsoleUtils.DisplayActionStart($"Creating payment recurring payment: {i} ");
                    var recurruingPaymentRequest = CreateRecurringPayment(createPaymentResponse.Payment.MandateId);
                    var nextPayment = await sepaExpressApiClient.PaymentsPOSTAsync(recurruingPaymentRequest);
                }
            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
                throw;
            }

            ConsoleUtils.StartStopScenario("Scenario is done - payment is created");
        }

        private CreatePaymentHttpRequest CreateRecurringPayment(string mandateId) =>
            new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = mandateId,
                CurrencyCode = "EUR",
                Mandate = null
            };

        private static CreatePaymentHttpRequest CreatePaymentRequest() =>
            new CreatePaymentHttpRequest
            {
                Amount = 12,
                CurrencyCode = "EUR",
                Mandate = new CreateMandateHttpRequest
                {
                    ConnectorId = Globals.ConnectorId,
                    Type = "recurring",
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