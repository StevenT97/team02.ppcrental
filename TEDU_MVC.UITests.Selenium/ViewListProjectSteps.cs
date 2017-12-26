using System.Linq;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.UITests.Selenium;
using TEDU_MVC.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TEDU_MVC.UITests.Selenium.Support;

namespace TEDU_MVC.UITests.Selenium
{
    [Binding, Scope(Tag = "web")]
    public class ViewListProjectSteps : SeleniumStepsBase
    {
        [When(@"I input '(.*)' and '(.*)' into Login paged")]
        public void WhenIInputAndIntoLoginPaged(string p0, int p1, Table table)
        {
            Browser.NavigateTo("Home/Index");
            Browser.ClickButton("btn_Login");
            Browser.NavigateTo("Admin/Login/Index");
            Browser.FieldText("UserName", p0);

            Browser.FieldText("PassWord",p1.ToString());
            Browser.ClickButton("btnLogin");
            Browser.ClickButton("btn_DashBoard");
        }

        [Then(@"I should see my own projects")]
        public void ThenIShouldSeeMyOwnProjects(Table table)
        {
            
        }
    }
}
