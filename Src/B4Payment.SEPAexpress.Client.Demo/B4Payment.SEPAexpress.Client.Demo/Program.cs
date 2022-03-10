using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.AddPaymentInSteps;
using B4Payment.SEPAexpress.Client.Demo.Identity;

ConsoleUtils.ShowTitle();

/// <summary>
/// authenticate user first
/// </summary>
var authenticationAction = new AuthenticationAction();
await authenticationAction.GetAccessTokenAsync();

while (true)
{
    ConsoleUtils.ShowScenarios();
    var selectedScenario = ConsoleUtils.ReadScenarioFromUser();

    switch (selectedScenario)
    {
        case '1':

            /// <summary>
            /// create payment in steps one-by-one
            /// </summary>
            var sampleCreatePaymentInSteps = new SampleCreatePaymentInSteps();
            await sampleCreatePaymentInSteps.CreatePaymentInStepsAsync();
            break;

        case '2':

            break;

        case 'X' or 'x':
            return;
    }
}