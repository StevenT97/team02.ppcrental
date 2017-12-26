using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding,Scope(Tag = "automated")]
  public  class LoginSteps
    {
        private IWebDriver driver = new FirefoxDriver();
        [Given(@"Toi dang o home page")]
        public void GivenToiDangOHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost:2489/Home/Index");
            Thread.Sleep(5);
        }

        [When(@"toi bam nut login")]
        public void WhenToiBamNutLogin()
        {
            driver.FindElement(By.Id("btn_Login")).Click();
            Thread.Sleep(5);
        }

        [Then(@"toi dang o trang login")]
        public void ThenToiDangOTrangLogin()
        {
            driver.Navigate().GoToUrl("http://localhost:2489/Admin/Login/Index");
            Thread.Sleep(5);
        }

        [When(@"toi dien mat khau va password")]
        public void WhenToiDienMatKhauVaPassword()
        {
            driver.FindElement(By.Id("UserName")).SendKeys("buibao1997@gmail.com");
            Thread.Sleep(5);
            driver.FindElement(By.Id("PassWord")).SendKeys("123456");
            Thread.Sleep(5);
        }

        [Then(@"toi bam nut login")]
        public void ThenToiBamNutLogin()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(5);
        }

        [When(@"toi bam nut dashboard")]
        public void WhenToiBamNutDashboard()
        {
            driver.FindElement(By.Id("btn_DashBoard")).Click();
            Thread.Sleep(5);
        }

        [Then(@"toi vao trang admin")]
        public void ThenToiVaoTrangAdmin()
        {
            driver.Navigate().GoToUrl("http://localhost:2489/Admin");
            
            ScenarioContext.Current.Pending();
        }

    }
}
