using B4Payment.SEPAexpress.Client.Api;
using System.Threading.Tasks;

namespace B4Payment.SEPAexpress.Client.Demo.SampleBase
{
    internal interface IScenario
    {
        string StartTitle { get; }
        string StopTitle { get; }

        Task ExecuteAsync(SepaExpressClient sepaExpressClient);
    }
}
