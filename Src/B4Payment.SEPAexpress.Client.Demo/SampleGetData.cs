using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

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
            ConsoleUtils.DisplayActionStart("Get customers list by criteria");
            // get customer list
            var customers = await sepaExpressClient.CustomersGETAsync(limit: 10);

            if (customers != null)
            {
                ConsoleUtils.DisplayActionStart("Get customer by id");
                var customerId = customers.Customers.First().Id;
                var customer = await sepaExpressClient.CustomersGET2Async(customerId);
            }

            ConsoleUtils.DisplayActionStart("Get bank account list by criteria");
            // get bank accounts
            var bankAccounts = await sepaExpressClient.BankAccountsGETAsync(
                currencyCode: "EUR", 
                limit: 5);

            if (bankAccounts != null)
            {
                ConsoleUtils.DisplayActionStart("Get bank account by id");
                // get bank account by Id
                var bankAccountId = bankAccounts.BankAccounts.First().Id;
                var bankAccount = await sepaExpressClient.BankAccountsGET2Async(
                    id: bankAccountId,
                    includeCustomer: true,
                    includeMerchant: false,
                    cancellationToken: CancellationToken.None);
                    
            }
        }
    }
}
