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
			await GetCustomerData(sepaExpressClient);
			await GetConnectorData(sepaExpressClient);
			await GetBankAccountData(sepaExpressClient);
			await GetHostedPageData(sepaExpressClient);
		}

		private static async Task GetHostedPageData(SepaExpressClient sepaExpressClient)
		{
			ConsoleUtils.DisplayActionStart("Get hosted pages list by criteria");
			// get hosted pages
			var hostedPages = await sepaExpressClient.HostedPagesGETAsync(
					createdUntil: DateTime.UtcNow,
					limit: 5);

			if (hostedPages != null)
			{
				ConsoleUtils.DisplayActionStart("Get hosted page by id");
				// get hosted page by Id
				var hostedPageId = hostedPages.HostedPages.First().Id;
				var hostedPage = await sepaExpressClient.HostedPagesGET2Async(
						id: hostedPageId,
						includeCustomer: true,
						includeMerchant: false,
						cancellationToken: CancellationToken.None);
			}
		}

		private static async Task GetBankAccountData(SepaExpressClient sepaExpressClient)
		{
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

		private static async Task GetConnectorData(SepaExpressClient sepaExpressClient)
		{
			ConsoleUtils.DisplayActionStart("Get connector list by criteria");
			// get connectors
			var connectors = await sepaExpressClient.Connectors2Async();

			if (connectors != null)
			{
				ConsoleUtils.DisplayActionStart("Get connector by id");
				// get connector by Id
				var connectorId = connectors.Connectors.First().Id;
				var connector = await sepaExpressClient.ConnectorsAsync(
						id: connectorId,
						includeMerchant: false,
						cancellationToken: CancellationToken.None);
			}
		}

		private static async Task GetCustomerData(SepaExpressClient sepaExpressClient)
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
		}
	}
}
