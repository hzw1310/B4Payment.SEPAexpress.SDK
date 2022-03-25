using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo
{
    /// <summary>
    /// Samples of getting various kind of data
    /// </summary>
    internal class SampleGetData : IScenario
    {
        public string StartTitle => "Start scenario - get data";

        public string StopTitle => "Scenario is done - get data";

        public async Task ExecuteAsync(SepaExpressClient sepaExpressClient)
        {
            // get bank accounts

            var bankAccounts = await sepaExpressClient.BankAccountsGETAsync(currencyCode: "EUR");
        }
    }
}
