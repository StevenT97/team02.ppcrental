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
        public void InsertPropertyToDB(Table Property, IEnumerable<string> feature)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in Property.Rows)
                {
                    var property = new PROPERTy
                    {
                        PropertyName = row["PropertyName"],
                        Content = row["Content"],
                        PropertyType_ID = db.PROPERTY_TYPE.ToList().FirstOrDefault(x=>x.CodeType ==row["PropertyType"]).ID,
                        Price = int.Parse(row["Price"]),
                        District_ID = db.DISTRICT_Table.ToList().FirstOrDefault(x=>x.DistrictName == row["District"]).ID,
                        Ward_ID = db.WARDs.ToList().FirstOrDefault(x=>x.WardName == row["Ward_ID"]).ID,
                        Street_ID = db.STREETs.ToList().FirstOrDefault(x => x.StreetName == row["Street_ID"]).ID,
                        UserID = db.USERs.ToList().FirstOrDefault(x=>x.Email == row["UserID"]).ID,
                        Status_ID = db.PROJECT_STATUS.ToList().FirstOrDefault(x=>x.Status_Name == row["StatusID"]).ID,
                       

                };
                    //PROPERTY_FEATURE pf = new PROPERTY_FEATURE();
                    //foreach (string x in property.listfeature)
                    //{
                    //    pf.Property_ID = (int)id;
                    //    pf.Feature_ID = int.Parse(x);
                    //    db.PROPERTY_FEATURE.Add(pf);
                    //    db.SaveChanges();
                    //}
                    _context.ReferenceBooks.Add(
                            Property.Header.Contains("ID") ? row["ID"] : property.PropertyName,
                            property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }
      
        public void ShowPropertyDetails(Table showPropertykDetails)
        {
            //Arrange
            var expectedBookDetails = showPropertykDetails.Rows.Single();

            //Act
            var actualBookDetails = _result.Model<PROPERTy>();

            //Assert
            actualBookDetails.Should().Match<PROPERTy>(
                b => b.PropertyName == expectedBookDetails["PropertyName"]
                && b.PropertyName == expectedBookDetails["Content"]
                && b.Price == decimal.Parse(expectedBookDetails["Price"]));
        }

        public void OpenPropertyDetails(string bookId)
        {
            var book = _context.ReferenceBooks.GetById(bookId);
            using (var controller = new HomeController())
            {
                _result = controller.Details(book.ID);
            }
        }
    }
}
