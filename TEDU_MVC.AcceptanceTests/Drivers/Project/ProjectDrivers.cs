using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TEDU_MVC.Models;
using TEDU_MVC.Controllers;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.AcceptanceTests.Support;
using FluentAssertions;
using TEDU_MVC;
using Models.FrameWork;

namespace TEDU_MVC.AcceptanceTests.Drivers.Project
{
    class ProjectDrivers
    {
        private readonly CatalogContext _context;

        //public ProjectDriver(SearchResultState result)
        //{
        //    _result = result;
        //}

        public ProjectDrivers(CatalogContext context)
        {
            _context = context;
        }

        public CatalogContext Context => _context;

        public void InsertProjecttoDB(Table givenProjects)
        {
            using (var db = new DemoPPCRentalEntities())
            {
                foreach (var row in givenProjects.Rows)
                {
                    var property = new PROPERTy
                    {
                        PropertyName = row["PropertyName"],
                        Avatar = row["Avarta"],
                        Images = row["Images"],
                        Content = row["Content"],
                        PropertyType_ID = int.Parse(row["PropertyType"]),
                        Street_ID = int.Parse(row["Street"]),
                        Ward_ID = int.Parse(row["Ward"]),
                        District_ID = int.Parse(row["District"]),
                        //PropertyType_ID = db.PROPERTY_TYPE.FirstOrDefault(d => d.CodeType == row["PropertyType"]).ID,
                        //Street_ID = db.STREETs.FirstOrDefault(x => x.StreetName == row["Street"]).ID,
                        //Ward_ID = db.WARDs.FirstOrDefault(x => x.WardName == row["Ward"]).ID,
                        //District_ID = db.DISTRICTs.FirstOrDefault(x => x.DistrictName == row["District"]).ID,
                        Price = int.Parse(row["Price"]),
                        UnitPrice = row["UnitPrice"],
                        Area = row["Area"],
                        BedRoom = int.Parse(row["BedRoom"]),
                        BathRoom = int.Parse(row["BathRoom"]),
                        PackingPlace = int.Parse(row["PackingPlace"]),
                        UserID = int.Parse(row["UserID"]),
                        Created_at = Convert.ToDateTime(row["Create_at"]),
                        Create_post = Convert.ToDateTime(row["Create_post"]),
                        Status_ID = int.Parse(row["Status"]),
                        //Note = row["Note"],
                        Updated_at = Convert.ToDateTime(row["Update_at"]),
                        Sale_ID = int.Parse(row["Sale_ID"])
                    };

                    _context.ReferenceProjectlist.Add(
                        givenProjects.Header.Contains("Id") ? row["Id"] : property.PropertyName,
                        property);

                    db.PROPERTies.Add(property);
                }

                db.SaveChanges();
            }
        }

    }
}
