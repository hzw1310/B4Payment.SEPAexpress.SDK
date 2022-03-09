using B4Payment.SEPAexpress.Client.Demo.Identity;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewPayment
    {
        public async Task ExecuteAsync()
        {
            var authenticationAction = new AuthenticationAction();
            var accessToken = await authenticationAction.GetAccessTokenAsync();

            Globals.HttpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var createPaymentResponse = await CreatePaymentAsync();

            // TODO: display result
            Console.WriteLine(createPaymentResponse.Payment.SoftDescriptor);
        }

        private async Task<CreatePaymentHttpResponse> CreatePaymentAsync()
        {
            var createPaymentRequest = new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = "3b8a541fffc0177e32a099d63227cb79",
                CurrencyCode = "EUR",
                Mandate = null // TODO: as about "required" on that
            };

            var client = new Client(Globals.BaseUrl, Globals.HttpClient);
            
            var createPaymentResponse = await client.PaymentsPOSTAsync(createPaymentRequest);

            return createPaymentResponse;
        }
    }
}