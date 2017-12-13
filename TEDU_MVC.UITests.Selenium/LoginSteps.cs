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
    public class LoginSteps : SeleniumStepsBase
    {
        [Given(@"Toi dang o home page")]
        public void GivenToiDangOHomePage()
        {
            Browser.NavigateTo("Home/Index");
           
        }

        [When(@"toi bam nut login")]
        public void WhenToiBamNutLogin()
        {
            Browser.ClickButton("btn_Login");
            
        }

        [Then(@"toi dang o trang login")]
        public void ThenToiDangOTrangLogin()
        {
            Browser.NavigateTo("Admin/Login/Index");
           
        }

        [When(@"toi dien mat khau va password")]
        public void WhenToiDienMatKhauVaPassword()
        {
            Browser.FieldText("UserName","buibao1997@gmail.com");
           
            Browser.FieldText("PassWord","123456");
           
        }

        [Then(@"toi bam nut login")]
        public void ThenToiBamNutLogin()
        {
            Browser.ClickButton("btnLogin");
           
        }

        [When(@"toi bam nut dashboard")]
        public void WhenToiBamNutDashboard()
        {
            Browser.ClickButton("btn_DashBoard");
          
        }

        [When(@"toi vao trang admin")]
        public void WhenToiVaoTrangAdmin()
        {
            Browser.NavigateTo("Admin");

        }

       
    }
}
