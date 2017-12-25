using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TEDU_MVC.UITests.Selenium.Step_Definitions
{
    [Binding]
    class PostProjectSteps
    {
        [Given(@"I am at Home page")]
        public void GivenIAmAtHomePage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click Login button")]
        public void GivenIClickLoginButton()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am at Login page")]
        public void GivenIAmAtLoginPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I entered email and password are '(.*)','(.*)' and click login")]
        public void GivenIEnteredEmailAndPasswordAreAndClickLogin(string p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I click Dashboard")]
        public void GivenIClickDashboard()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am at Admin Page")]
        public void WhenIAmAtAdminPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click Agency button")]
        public void WhenIClickAgencyButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click List Of Agency")]
        public void WhenIClickListOfAgency()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am at View List Project page")]
        public void WhenIAmAtViewListProjectPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click Create button")]
        public void WhenIClickCreateButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I input new property with these info '(.*)','(.*)'")]
        public void WhenIInputNewPropertyWithTheseInfo(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I am at View List Project have new property")]
        public void ThenIAmAtViewListProjectHaveNewProperty()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
