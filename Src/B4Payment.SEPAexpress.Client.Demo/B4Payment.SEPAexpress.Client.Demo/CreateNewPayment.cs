using B4Payment.SEPAexpress.Client.Demo.Identity;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewPayment
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
                // create payment
                var createPaymentResponse = await CreatePaymentAsync();

                // display result
                DisplayResult(createPaymentResponse);
            }
            catch (ApiException apiex)
            {
                DisplayException(apiex);
            }
        }

        private async Task<CreatePaymentHttpResponse> CreatePaymentAsync()
        {
            var createPaymentRequest = CreatePaymentRequest();
            var client = new Client(Globals.BaseUrl, Globals.HttpClient);
            return await client.PaymentsPOSTAsync(createPaymentRequest);
        }

        private static CreatePaymentHttpRequest CreatePaymentRequest()
        {
            return new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = "3b8a541fffc0177e32a099d63227cb79",
                CurrencyCode = "EUR",
                Mandate = new CreateMandateHttpRequest
                {
                    BankAccountId = "xxxxxxxx",
                    BankAccount = new CreateBankAccountHttpRequest
                    {
                        CustomerId = "ddddddddd",
                        Customer = new CreateCustomerHttpRequest
                        {
                            MerchantId = "xxxxxx"
                        },
                        Iban = ""
                    },
                    CurrencyCode = "EUR",
                    Amount = 10002,
                }
            };
        }

        private void DisplayResult(CreatePaymentHttpResponse response)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(response);
            Console.WriteLine(json);
        }

        private void DisplayException(ApiException apiex)
        {
            Console.WriteLine(apiex.Message);
        }

    }
}