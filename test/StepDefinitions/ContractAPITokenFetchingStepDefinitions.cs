using System.Net;
using IntroToBDD.Helpers;

namespace IntroToBDD.Test.StepDefinitions
{
    [Binding]
    public class ContractAPITokenFetchingStepDefinitions
    {
        private TokenFeatureHelper tokenHelper = new TokenFeatureHelper();
        const string URL = "http://cmicts10.internal.stage.aws.dotw.com/api/verticalbooking/v1/authorize.json";
        private readonly ScenarioContext context;

        public ContractAPITokenFetchingStepDefinitions(ScenarioContext context)
        {
            this.context = context;
        }

        [Given(@"invalid crentials")]
        public void GivenInvalidCrentials()
        {
            var credentials = new Credentials { User = "userTest", Password = "invalidPassword" };
            context.Add("credentials", credentials);
        }

        [When(@"new token requested")]
        public void WhenNewTokenRequested()
        {
            var credentials = context.Get<Credentials>("credentials"); 
            var response = tokenHelper.Login(URL,credentials.User,credentials.Password);
            context.Add("response",response);
        }

        [Then(@"the result is unauthorized")]
        public void ThenTheResultIsUnauthorized()
        {
            var response = context.Get<HttpResponseMessage>("response");
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);//401
        }
    }
}
