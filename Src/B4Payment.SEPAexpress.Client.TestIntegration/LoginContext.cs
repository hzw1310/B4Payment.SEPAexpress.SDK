using B4Payment.SEPAexpress.Client.Demo.Identity;

namespace B4Payment.SEPAexpress.Client.TestIntegration
{
    public class LoginContext
    {
        public LoginContext()
        {
            var authenticationAction = new SampleUserAuthentication();
            authenticationAction.GetAccessTokenAsync().GetAwaiter().GetResult();
        }
    }
}
