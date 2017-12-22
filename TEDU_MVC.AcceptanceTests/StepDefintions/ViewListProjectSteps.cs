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
using Models.FrameWork;

namespace TEDU_MVC.UITests.Selenium
{
    [Binding]

    public class ViewListProjectSteps : SeleniumStepsBase
    {
        public object AssertionCommand { get; private set; }

        [Given(@"Toi dang o Home Page")]
        public void GivenToiDangOHomePage()
        {
            Browser.NavigateTo("Home/Index");
            Thread.Sleep(1000);

        }

        [Given(@"Toi bam nut Login")]
        public void GivenToiBamNutLogin()
        {
            Browser.ClickButton("btn_Login");
            Thread.Sleep(1000);
        }

        [When(@"Toi dang o trang Login")]
        public void WhenToiDangOTrangLogin()
        {
            Browser.NavigateTo("Admin/Login/Index");
            Thread.Sleep(1000);
        }

        [When(@"Toi dien username va password")]
        public void WhenToiDienUsernameVaPassword()
        {
            Browser.FieldText("UserName", "buibao1997@gmail.com");
            Thread.Sleep(1000);
            Browser.FieldText("PassWord", "123456");
            Thread.Sleep(1000);
        }

        [When(@"Toi bam nut Login")]
        public void WhenToiBamNutLogin()
        {
            Browser.ClickButton("btnLogin");
            Thread.Sleep(1000);
        }

        [When(@"Toi bam nut Dashboard")]
        public void WhenToiBamNutDashboard()
        {
            Browser.ClickButton("btn_DashBoard");
            Thread.Sleep(1000);
        }

        [When(@"Toi vao trang Admin")]
        public void WhenToiVaoTrangAdmin()
        {
            Browser.NavigateTo("Admin");
            Thread.Sleep(1000);
        }

        [When(@"Toi bam nut Agency")]
        public void WhenToiBamNutAgency()
        {
            Browser.ClickButton("menu-agency");
            Thread.Sleep(1000);
        }

        [When(@"Toi bam nut List of Agency")]
        public void WhenToiBamNutListOfAgency()
        {
            Browser.ClickButton("list-agency");
            Thread.Sleep(1000);
        }

        [Then(@"Toi vao trang View List of Project")]
        public void ThenToiVaoTrangViewListOfProject()
        {
            Browser.NavigateTo("Admin/Login/ListAgency");
            Thread.Sleep(1000);
        }
        //[Then(@"Toi vao trang View List of Project '(.*)'")]
        //public void ThenToiVaoTrangViewListOfProject(string expectedText)
        //{
        //    var expectedResult = expectedText.Split(',').Select(x => x.Trim('\''));
        //    Browser.SwitchTo().DefaultContent();

        //    string descriptor = "//table/tbody/tr";
        //    var agencyproject = from row in Browser.FindElements(By.XPath(descriptor))
        //                        let Name = row.FindElement(By.ClassName("sorting_1")).Text
        //                        select new PROPERTy { PropertyName = Name };
        //    AssertionCommand.(agencyproject,expectedResult);
    //}

    }

}
