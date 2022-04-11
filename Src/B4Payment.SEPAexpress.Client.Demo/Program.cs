using B4Payment.SEPAexpress.Client.Demo;
using B4Payment.SEPAexpress.Client.Demo.Identity;
using B4Payment.SEPAexpress.Client.Demo.SampleBase;
using B4Payment.SEPAexpress.Client.Demo.Utils;

ConsoleUtils.ShowTitle();

while (true)
{
    ConsoleUtils.ShowScenarios();
    var selectedScenario = ConsoleUtils.ReadCharFromUser();
    Console.WriteLine();

    if (selectedScenario == 'X' || selectedScenario == 'x')
    {
        return;
    }

    /// <summary>
    /// authenticate user first
    /// </summary>
    var authenticationAction = new SampleUserAuthentication();
    await authenticationAction.GetAccessTokenAsync();

    var scenario = SamplesFactory.CreateSample(selectedScenario);
    if (scenario != null)
    {
        var executor = new SampleScenarioExecutor(scenario);
        await executor.ExecuteAsync();
    }
}
