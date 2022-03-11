namespace B4Payment.SEPAexpress.Client.Demo.AddPaymentInSteps
{
    internal class CreateNewPaymentAction
    {
        /// <summary>
        /// Scenario: 
        ///     - create payment
        ///     - display result of the operation
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteAsync(string mandateId)
        {
            try
            {
                ConsoleUtils.DisplayActionStart("Creating payment");

                // create payment
                var createPaymentRequest = CreatePaymentRequest(mandateId);
                var client = new Client(Globals.BaseUrl, Globals.HttpClient);
                var createPaymentResponse = await client.PaymentsPOSTAsync(createPaymentRequest);
            }
            catch (ApiException apiex)
            {
                ConsoleUtils.DisplayException(apiex);
            }
        }

        private static CreatePaymentHttpRequest CreatePaymentRequest(string mandateId)
        {
            return new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = mandateId,
                CurrencyCode = "EUR",
                Mandate = null
            };
        }
    }
}