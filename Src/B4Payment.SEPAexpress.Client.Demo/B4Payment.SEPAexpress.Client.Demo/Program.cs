using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;

ConsoleUtils.ShowTitle();

/// <summary>
/// Scenarios:
/// 1. Create a payment. <see href="https://sepaexpress-prod-fx.azurewebsites.net/redoc#tag/Quick-Start"/>
/// </summary>

/// 1.1 authenticate user
var authenticationAction = new AuthenticationAction();
await authenticationAction.GetAccessTokenAsync();

/// 1.2 create a new customer
var createNewCustomerAction = new CreateNewCustomerAction();
var customerId = await createNewCustomerAction.ExecuteAsync();

/// 1.3 create a new bank account for this customer
var createNewBankAccount = new CreateNewBankAccountAction();
var bankAccountId = await createNewBankAccount.ExecuteAsync(customerId);

/// 1.4 create a new mandate for this bank account
var createMandate = new CreateNewManadateAction();
await createMandate.ExecuteAsync(bankAccountId);

/// 1.5 create a new payment referencing on this mandate
var createNewPayment = new CreateNewPaymentAction();
await createNewPayment.ExecuteAsync();




