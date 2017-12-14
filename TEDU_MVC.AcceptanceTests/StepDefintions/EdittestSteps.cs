using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Linq;
using TEDU_MVC.AcceptanceTests.Common;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Threading;
using TEDU_MVC.UITests.Selenium.Support;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding]
    public class EdittestSteps : SeleniumStepsBase
    {
        [Given(@"I stay homepage")]
        public void GivenIStayHomepage()
        {
            Browser.NavigateTo("http://localhost:2489/Home/Index");
        }
        
        [Given(@"I want login")]
        public void GivenIWantLogin()
        {
            Browser.ClickButton("btn_Login");
        }
        
        [Given(@"I stay login page")]
        public void GivenIStayLoginPage()
        {
            Browser.NavigateTo("Admin/Login/Index");
        }
        
        [Given(@"i write username And Password")]
        public void GivenIWriteUsernameAndPassword()
        {
            Browser.FieldText("UserName", "lythihuyenchau@gmail.com");

            Browser.FieldText("PassWord", "123456");
        }
        
        [Given(@"i click login button")]
        public void GivenIClickLoginButton()
        {
            Browser.ClickButton("btnLogin");
        }
        
        [When(@"I stay home page")]
        public void WhenIStayHomePage()
        {
            Browser.NavigateTo("Home/Index");
        }
        
        [When(@"I click dashboard")]
        public void WhenIClickDashboard()
        {
            Browser.ClickButton("btn_DashBoard");
        }
        
        [When(@"I STAY adminpage")]
        public void WhenISTAYAdminpage()
        {
            Browser.NavigateTo("Admin/Home/Index");
        }
        
        [When(@"I Click agency Project")]
        public void WhenIClickAgencyProject()
        {
            Browser.FindElement(By.Id("menu-sale")).Click();
            Browser.FindElement(By.Id("list-sale-project")).Click();
        }
        
        [When(@"I See List Project")]
        public void WhenISeeListProject()
        {
            Browser.NavigateTo("Admin/Property/Index");
        }
        
        [When(@"I click edit  a project")]
        public void WhenIClickEditAProject()
        {
            Browser.FindElement(By.Id("btn-Edit")).Click();
        }
        
        [When(@"I stay Edit PAge")]
        public void WhenIStayEditPAge()
        {
            Browser.NavigateTo("Admin/Property/Edit/12");
        }
        
        [When(@"I Editing Project")]
        public void WhenIEditingProject()
        {
            Browser.SetTextBoxValue("PropertyName", "");
            Browser.FieldText("PropertyName", "lythihuyenchau");

            //Browser.FieldText("Propertytype_ID", "123456");
            //
            //Browser.FindElement(By.Id("btn-browser")).Click();
            Browser.FindElement(By.Id("btn-imageup")).SendKeys(@"C:\Users\Son\Desktop\10.jpg");
            //Browser.FindElement(By.Id("btn-avatar")).SendKeys(@"C:\Users\Son\Desktop\10.jpg");
            //Browser.FindElement(By.Id("btn-image")).SendKeys(@"C:\Users\Son\Desktop\10.jpg");

            //
            Browser.FindElement(By.Id("PropertyType_ID")).Click();
            Browser.FindElement(By.Id("PropertyType_ID")).SendKeys("House");
            //content
            Browser.SetTextBoxValue("Content", "");
            Browser.FieldText("Content", "lythihuyenchau");
            //
            Browser.FindElement(By.Id("Street_ID")).Click();
            //Thread.Sleep(10000);
            Browser.FindElement(By.Id("Street_ID")).SendKeys("A6");

            //
            Browser.FindElement(By.Id("District_ID")).Click();
            Browser.FindElement(By.Id("District_ID")).SendKeys("Chương Mỹ");
            //

            //
            Browser.SetTextBoxValue("Price", "");
            Browser.FieldText("Price", "100000");
            //
            Browser.SetTextBoxValue("Area", "");
            Browser.FieldText("Area", "100m2");
            //
            Browser.SetTextBoxValue("BedRoom", "");
            Browser.FieldText("BedRoom", "5");
            ////
            Browser.SetTextBoxValue("BathRoom", "");
            Browser.FieldText("BathRoom", "5");
            ////
            Browser.SetTextBoxValue("PackingPlace", "");
            Browser.FieldText("PackingPlace", "0");
            //
            Browser.FindElement(By.Id("UserID")).Click();
            Browser.FindElement(By.Id("UserID")).SendKeys("Ly Chau");
            //
            Browser.FindElement(By.Id("Status_ID")).Click();
            Browser.FindElement(By.Id("Status_ID")).SendKeys("Hết hạn");
        }
        
        [When(@"I Click Save")]
        public void WhenIClickSave()
        {
            Browser.FindElement(By.Id("btn-save")).Click();
        }
        
        [Then(@"I stay List Project Page")]
        public void ThenIStayListProjectPage()
        {
            Browser.NavigateTo("Admin/Property");
        }
    }
}
