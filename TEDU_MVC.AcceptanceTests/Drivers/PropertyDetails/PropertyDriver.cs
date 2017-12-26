using System;
using System.Linq;
using System.Web.Mvc;
using Models.FrameWork;
using TEDU_MVC.AcceptanceTests.Support;
using TEDU_MVC.Controllers;
using FluentAssertions;
using TechTalk.SpecFlow;
using System.Text;
using TEDU_MVC.Code;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using TEDU_MVC.Areas.Admin.Controllers;
using TEDU_MVC.AcceptanceTests.Common;

namespace TEDU_MVC.AcceptanceTests.Drivers.PropertyDetails
{
    public class PropertyDriver
    {
        private const decimal BookDefaultPrice = 10;
        private ActionResult _result;
        private readonly CatalogContext _context;
       

        public PropertyDriver(CatalogContext context)
        {
            _context = context;
        }
       
       

        public static string MAHOA(string code)
        {

            var encryptedMd5Pas = MaHoa.MD5Hash(code);
            return encryptedMd5Pas;
        }
        public void InsertUserToDb(Table User)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in User.Rows)
                {
                    var user = new USER
                    {
                        Email = row["Email"],
                        Password = MAHOA(row["Password"]),
                        FullName = row["FullName"],
                        Phone = row["Phone"],
                        Address = row["Address"],
                        Role = row["Role"],
                        Status = bool.Parse(row["Status"]),
                        GroupID = row["GroupID"]

                    };
                    db.USERs.Add(user);
                }
                db.SaveChanges();
            }
        }

        public void InsertFeaturetoBD(Table givenFeature)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in givenFeature.Rows)
                {
                    var property = new PROPERTY_FEATURE
                    {

                        Property_ID = db.PROPERTies.ToList().FirstOrDefault(x => x.PropertyName == row["Property"]).ID,
                        Feature_ID = db.FEATUREs.ToList().FirstOrDefault(x => x.FeatureName == row["Feature"]).ID
                    };

                    db.PROPERTY_FEATURE.Add(property);
                }

                db.SaveChanges();
            }
        }

        public void InsertProjecttoDB(Table givenProject)
        {

            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in givenProject.Rows)
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

                    _context.ReferenceBooks.Add(
                        givenProject.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }
        public void Navigate(Table table)
        {
            //var controller = new AgencyController();
            //_result = controller.Login(mail, pass);

            var routeData = new RouteData();
            routeData.Values.Add("action", "ListAgency");
            routeData.Values.Add("controller", "Login");

            var agencyController = GetAgencyController(routeData);
            foreach (var row in table.Rows)
            {
                var model = new LoginModels {
                   UserName = row["Email"],
                   PassWord = row["Pass"]
                };
                _result = agencyController.Login(model);
            }
          
            if (((RedirectToRouteResult)_result).RouteValues["action"].Equals("ListAgency"))
            {
                _result = agencyController.ListAgency();

                var shownProperties = _result.Model<IEnumerable<PROPERTy>>();
                ScenarioContext.Current.Add("agencyProperty", shownProperties);
            }
        }
        private static LoginController GetAgencyController(RouteData routedata)
        {
            var controller = new LoginController();
            HttpContextStub.SetupController(controller, routedata);
            return controller;
        }

        public void ShowBookDetails(Table shownBookDetails)
        {
            //Arrange
            var expectedBookDetails = shownBookDetails.Rows.Single();

            //Act
            var actualBookDetails = _result.Model<PROPERTy>();

            //Assert
            actualBookDetails.Should().Match<PROPERTy>(
                b => b.PropertyName == expectedBookDetails["PropertyName"]
                && b.PropertyName == expectedBookDetails["Content"]
                && b.Price == decimal.Parse(expectedBookDetails["Price"]));
        }

        public void ShowList(Table expectednameList)
        {
           
            //Arrange
            var expectedProjects = expectednameList.Rows.Select(r => r["PropertyName"]);

            //Actual
            var result = ScenarioContext.Current.Get<IEnumerable<PROPERTy>>("agencyProperty");
            //var actualProjects = result.Model<IEnumerable<PROPERTY>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(result, expectedProjects);
        }
    }
}
