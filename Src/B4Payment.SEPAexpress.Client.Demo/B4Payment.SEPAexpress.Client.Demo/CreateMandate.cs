using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo
{
    internal class CreateMandate
    {
        public async Task ExecuteAsync()
        {
            var client = new Client(Globals.BaseUrl, Globals.HttpClient);

            var createMandateHttpRequest = new CreateMandateHttpRequest
            {
                
            };

            var response = await client.MandatesPOSTAsync(createMandateHttpRequest);
        }
    }
}
