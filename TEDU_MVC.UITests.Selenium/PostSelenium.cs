using Models.FrameWork;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.UITests.Selenium.Support;

namespace TEDU_MVC.UITests.Selenium
{
    [Binding, Scope(Tag ="web")]
  public  class PostSelenium : SeleniumStepsBase
    {
        [When(@"I login '(.*)','(.*)'")]
        public void WhenILogin(string p0, int p1)
        {
          

        Browser.NavigateTo("Home/Index");
            Browser.ClickButton("btn_Login");
            Browser.FieldText("UserName", p0);
            Browser.FieldText("PassWord", p1.ToString());
            Browser.ClickButton("btnLogin");
            Browser.ClickButton("btn_DashBoard");
            Browser.NavigateTo("Admin/Home/Index");
            Browser.ClickButton("menu-agency");
            Browser.ClickButton("list-of-agency");
            Browser.NavigateTo("Admin/Login/ListAgency");
            Browser.FindElement(By.Id("btn-create")).Click();
          

        }


        [When(@"I entered the following information")]
        public void WhenIEnteredTheFollowingInformation(Table table)
        {
         
                using (var db = new DemoPPCRentalEntities())
                {
                    foreach (var row in table.Rows)
                    {
                        var property = new PROPERTy
                        {
                            PropertyName = row["PropertyName"],
                            Avatar = row["Avarta"],
                            Images = row["Images"],
                            Content = row["Content"],
                            PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
                            Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                            Ward_ID = db.WARDs.ToList().FirstOrDefault(x => x.WardName == row["Ward"]).ID,
                            District_ID = db.DISTRICT_Table.ToList().FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                            Price = int.Parse(row["Price"]),
                            UnitPrice = row["UnitPrice"],
                            Area = row["Area"],
                            BedRoom = int.Parse(row["BedRoom"]),
                            BathRoom = int.Parse(row["BathRoom"]),
                            PackingPlace = int.Parse(row["PackingPlace"]),
                            UserID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["UserID"]).ID,
                            Created_at = Convert.ToDateTime(row["Create_at"]),
                            Create_post = Convert.ToDateTime(row["Create_post"]),
                            Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x => x.Status_Name == row["Status"]).ID,
                            Note = row["Note"],
                            Updated_at = Convert.ToDateTime(row["Update_at"]),
                            Sale_ID = db.USERs.ToList().FirstOrDefault(x => x.FullName == row["Sale_ID"]).ID,
                        };

                       

                        db.PROPERTies.Add(property);
                    }

                    db.SaveChanges();
                }

            Browser.NavigateTo("Admin/Login/ListAgency");
        }

        [Then(@"The list of properties shoul have my new property")]
        public void ThenTheListOfPropertiesShoulHaveMyNewProperty(Table table)
        {
            //Arrange
            var expectedTitles = table.Rows.Select(r => r["PropertyName"]);

            //Action
            var foundBooks = from row in Browser.FindElements(By.XPath("//table/tbody/tr"))
                             let Name = row.FindElement(By.Id("IDPropertyName")).Text

                             select new PROPERTy { PropertyName = Name };

            //Assert
            PropertyAssertions.HomeScreenShouldShow(foundBooks, expectedTitles);
        }
    }
}
