using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;
using B4Payment.SEPAexpress.Client.Demo.Utils;

ConsoleUtils.ShowTitle();

while (true)
{
    ConsoleUtils.ShowScenarios();
    var selectedScenario = ConsoleUtils.ReadScenarioFromUser();
    Console.WriteLine();

    /// <summary>
    /// authenticate user first
    /// </summary>
    var authenticationAction = new SampleUserAuthentication();
    await authenticationAction.GetAccessTokenAsync();

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

            /// <summary>
            /// create payment in steps in-line
            /// </summary>
            var sampleCreatePaymentInline = new SampleCreatePaymentInline();
            await sampleCreatePaymentInline.CreatePaymentInlineAsync();
            break;

        case 'X' or 'x':
            return;
    }
}