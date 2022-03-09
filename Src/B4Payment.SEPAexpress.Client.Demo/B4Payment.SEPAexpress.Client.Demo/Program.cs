using B4Payment.SEPAexpress.Client.Demo;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var createNewPayment = new CreateNewPayment();
await createNewPayment.ExecuteAsync();
