using B4Payment.SEPAexpress.Client.Api;
using B4Payment.SEPAexpress.Client.Demo.Utils;

namespace B4Payment.SEPAexpress.Client.Demo.SampleBase
{
    internal class SampleScenarioExecutor
    {
        private readonly IScenario _scenario;

        public SampleScenarioExecutor(IScenario scenario)
        {
            _scenario = scenario;
        }

        internal async Task ExecuteAsync()
        {
            ConsoleUtils.StartStopScenario(_scenario.StartTitle);

            var client = new SepaExpressClient(Globals.BaseUrl, Globals.HttpClient);

            client.PrepareRequestEvent += (object? sender, RequestEventArgs e) =>
                JsonClientUtil.PrepareRequest(e.Client, e.Request, e.Url);

            client.PrepareResponseEvent += (object? sender, ResponseEventArgs e) =>
                JsonClientUtil.ProcessResponse(e.Client, e.Response);

            try
            {
                await _scenario.ExecuteAsync(client);

                ConsoleUtils.StartStopScenario(_scenario.StopTitle);
            }
            catch (ApiException apix)
            {
                ConsoleUtils.DisplayException(apix);
            }
        }
    }
}
