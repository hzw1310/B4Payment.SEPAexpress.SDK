using B4Payment.SEPAexpress.Client.Demo;

ConsoleUtils.ShowTitle();
ConsoleUtils.ReadAuthenticationData();

// scenarios

// 1. create payment
var createNewPayment = new CreateNewPayment();
await createNewPayment.ExecuteAsync();

// 2. create mandate


