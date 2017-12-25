using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TEDU_MVC.Controllers;
using TEDU_MVC.Models;
using TEDU_MVC.AcceptanceTests.Support;
using TEDU_MVC.AcceptanceTests.Common;
using TechTalk.SpecFlow;
using Models.FrameWork;
using System.Web;
using System;

namespace TEDU_MVC.AcceptanceTests.Drivers.Search
{
    public class SearchDriver
    {
        private readonly SearchResultState _state;
     
        public SearchDriver(SearchResultState state)
        {
            _state = state;
        }

        /// <summary>
        /// Post property
        /// </summary>
        /// <param name="Property"></param>
        
        public void InsertBookToDB(Table Property)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in Property.Rows)
                {
                    var property = new PROPERTy
                    {
                        PropertyName = row["PropertyName"],
                        Content = row["Content"],
                        PropertyType_ID = int.Parse(row["PropertyType"]),
                        Price = int.Parse(row["Price"]),
                        District_ID = int.Parse(row["District"]),
                        UserID = int.Parse(row["UserID"]),
                        Status_ID = int.Parse(row["StatusID"])

                    };

                    //_context.ReferenceBooks.Add(
                    //        Property.Header.Contains("ID") ? row["ID"] : property.PropertyName,
                    //        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }
        public void ListProperty()
        {
            var controller = new HomeController();
            _state.ActionResult = controller.Index();
        }
        public void Search(string s1,string s2,string s3,string minP, string maxP)
        {
            var controller = new TEDU_MVC.Controllers.HomeController();
            int? district = null;
            int? type = null;   
            var db = new DemoPPCRentalEntities();
            try{
                district = db.DISTRICT_Table.ToList().FirstOrDefault(x => x.DistrictName == s2).ID;
            }catch(NullReferenceException){
                district = null;
            }
            try
            {
                type = db.PROPERTY_TYPE.ToList().FirstOrDefault(x => x.CodeType == s3).ID;
            }
            catch (NullReferenceException)
            {
                type = null;
            }
            _state.ActionResult = controller.Search(s1, district, type,minP,maxP);
        }

        public void ShowBooks(string expectedTitlesString)
        {
            //Arrange
            var expectedTitles = from t in expectedTitlesString.Split(',')
                                 select t.Trim().Trim('\'');

            //Action
            var ShownBooks = _state.ActionResult.Model<IEnumerable<PROPERTy>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownBooks, expectedTitles);
        }

        public void ShowBooks(Table expectedBooks)
        {
            //Arrange
            var expectedTitles = expectedBooks.Rows.Select(r => r["PropertyName"]);

            //Action
            var ShownBooks = _state.ActionResult.Model<IEnumerable<PROPERTy>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(ShownBooks, expectedTitles);
        }
    }
}
