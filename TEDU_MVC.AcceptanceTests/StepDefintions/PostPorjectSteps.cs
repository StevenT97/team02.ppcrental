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
    class PostPorjectSteps : SeleniumStepsBase
    {

        [Given(@"Toi dang o home page")]
        public void GivenToiDangOHomePage()
        {
            Browser.NavigateTo("Home/Index");
            Thread.Sleep(1000);
        }

        [Given(@"toi bam nut login")]
        public void GivenToiBamNutLogin()
        {
            Browser.ClickButton("btn_Login");
            Thread.Sleep(1000);
        }

        [Given(@"toi dang o trang login")]
        public void GivenToiDangOTrangLogin()
        {
            Browser.NavigateTo("Admin/Login/Index");
            Thread.Sleep(1000);
        }

        [Given(@"toi dien username va password")]
        public void GivenToiDienUsernameVaPassword()
        {
            Browser.FieldText("UserName", "buibao1997@gmail.com");
            Thread.Sleep(1000);
            Browser.FieldText("PassWord", "123456");
            Thread.Sleep(1000);

        }
        [Given(@"toi bam nut dangnhap")]
        public void GivenToiBamNutDangnhap()
        {
            Browser.ClickButton("btnLogin");
        }

        [Given(@"toi bam nut dashboard")]
        public void GivenToiBamNutDashboard()
        {
            //Browser.NavigateTo("Home/Index");
            Thread.Sleep(1000);
            Browser.ClickButton("btn_DashBoard");
            //Thread.Sleep(1000);
        }

        [When(@"toi vao trang Admin")]
        public void WhenToiVaoTrangAdmin()
        {
            Browser.NavigateTo("Admin/Home/Index");


        }

        [When(@"toi bam nut Agency")]
        public void WhenToiBamNutAgency()
        {
            Browser.ClickButton("menu-agency");
        }

        [When(@"toi bam nut List of Agency")]
        public void WhenToiBamNutListOfAgency()
        {
            Browser.ClickButton("list-of-agency");
        }

        [When(@"toi vao trang View List of Agency Project")]
        public void WhenToiVaoTrangViewListOfAgencyProject()
        {
            Browser.NavigateTo("Admin/Login/ListAgency");
        }

        [When(@"toi bam vao nut Create")]
        public void WhenToiBamVaoNutCreate()
        {
            Browser.FindElement(By.Id("btn-create")).Click();
        }

        [When(@"toi nhap property name '(.*)','(.*)','(.*)'")]
        public void WhenToiNhapPropertyName(string p0, string p1, string p2)
        {

            Browser.FieldText("PropertyName", p0);
            Browser.FieldText("uploadFileDetails", p1);
            Browser.FieldText("uploadFileAvatar", p1);
            Browser.FieldText("uploadFileImage", p1);
            Thread.Sleep(5000);
        }

        [When(@"toi bam nut Create")]
        public void WhenToiBamNutCreate()
        {
            Browser.ClickButton("btn-create2");
        }


        [Then(@"toi dung o trang View List of Agency Project '(.*)'")]
        public void ThenToiDungOTrangViewListOfAgencyProject(string p0)
        {

            //Browser.NavigateTo("Admin/Login/ListAgency"); //Arrange
            var expectedTitles = p0.Split(',').Select(t => t.Trim().Trim('\''));
            //Action

            Browser.SwitchTo().DefaultContent();

            string descriptionTextXPath = "//table/tbody/tr";
            var foundBooks = from row in Browser.FindElements(By.XPath(descriptionTextXPath))
                             let Name = row.FindElement(By.Id("IDPropertyName")).Text
                            
                             //let NameImages = row.FindElement(By.TagName("img")).GetAttribute("src")
                             
                             select new PROPERTy { PropertyName = Name};

            //Assert
            PropertyAssertions.FoundPropertysShouldMatchTitles(foundBooks, expectedTitles);

        }
    }
}
