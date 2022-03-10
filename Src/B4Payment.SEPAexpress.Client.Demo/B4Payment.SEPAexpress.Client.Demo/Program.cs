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


/// 1.3 create a new bank account for this customer

/// 1.4 create a new mandate for this bank account

/// 1.5 create a new payment referencing on this mandate
var createNewPayment = new CreateNewPayment();
await createNewPayment.ExecuteAsync();




