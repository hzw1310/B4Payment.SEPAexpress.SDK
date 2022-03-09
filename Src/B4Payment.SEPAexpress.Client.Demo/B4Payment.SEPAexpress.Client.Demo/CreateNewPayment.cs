using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateNewPayment
    {
        public async Task ExecuteAsync()
        {
            var baseUrl = "https://sepaexpress-prod-fx.azurewebsites.net";
            using var httpClient = new HttpClient();

            var createPaymentRequest = new CreatePaymentHttpRequest
            {
                Amount = 10002,
                MandateId = "3b8a541fffc0177e32a099d63227cb79",
                CurrencyCode = "EUR",
            };


            var client = new Client(baseUrl, httpClient);

            var createPaymentResponse = await client.PaymentsPOSTAsync(createPaymentRequest);


        }
    }
}
