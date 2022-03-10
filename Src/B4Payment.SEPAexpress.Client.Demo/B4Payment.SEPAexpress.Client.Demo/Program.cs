using B4Payment.SEPAexpress.Client.Demo;

ConsoleUtils.ShowTitle();
ConsoleUtils.ReadAuthenticationData();

var createNewPayment = new CreateNewPayment();
await createNewPayment.ExecuteAsync();


