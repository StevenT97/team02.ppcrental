using System.Linq;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.UITests.Selenium;
using Models.FrameWork;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TEDU_MVC.UITests.Selenium.Support;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding]
    public class ViewListProjectSteps : SeleniumStepsBase
    {
        [Given(@"Toi dang o trang HomePage")]
        public void GivenToiDangOTrangHomePage()
        {
            Browser.NavigateTo("Home/Index");
        }

        [Given(@"Toi bam vao nutt Login")]
        public void GivenToiBamVaoNuttLogin()
        {
            Browser.ClickButton("btn_Login");
        }

        [When(@"Toi dang o trang Login")]
        public void WhenToiDangOTrangLogin()
        {
            Browser.NavigateTo("Admin/Login/Index");
        }

        [When(@"Toi dien username va password")]
        public void WhenToiDienUsernameVaPassword()
        {
            Browser.FieldText("UserName", "lythihuyenchau@gmail.com");

            Browser.FieldText("PassWord", "123456");
        }

        [When(@"Toi bam vao nut Login")]
        public void WhenToiBamVaoNutLogin()
        {
            Browser.ClickButton("btnLogin");
        }

        [When(@"Toi vao trang Home")]
        public void WhenToiVaoTrangHome()
        {
            Browser.NavigateTo("Home/Index");
        }

        [When(@"Toi bam nut Dashboard")]
        public void WhenToiBamNutDashboard()
        {
            Browser.ClickButton("btn_DashBoard");
        }

        [When(@"Toi vao trang cua Admin")]
        public void WhenToiVaoTrangCuaAdmin()
        {
            Browser.NavigateTo("Admin");
        }

        [When(@"Toi bam nut Sale")]
        public void WhenToiBamNutSale()
        {
            Browser.ClickButton("menu-sale");
        }

        [When(@"Toi bam nut List of Project")]
        public void WhenToiBamNutListOfProject()
        {
            Browser.ClickButton("list-sale-project");
        }

        [Then(@"Toi thay list project: '(.*)'")]
        public void ThenToiThayListProject(string p0)
        {

            Browser.NavigateTo("Admin/Property/Index");
            //Arrange
            var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//table/tbody/tr";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.FindElement(By.Id("IDPropertyName")).Text
                             select new PROPERTy { PropertyName = Name, };

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);
        }
    }
}
