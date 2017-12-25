using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using TEDU_MVC.AcceptanceTests.Support;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.Controllers;
using TEDU_MVC.Models;
using Models.FrameWork;
using TechTalk.SpecFlow;

namespace TEDU_MVC.AcceptanceTests.Drivers.Home
{
    public class HomeDriver
    {
        private ActionResult _result;

        public void Navigate()
        {
            using (var controller = new HomeController())
            {
                _result = controller.Index();
            }
        }

        public void ShowBooks(Table expectedBooks)
        => ShowBooks(expectedBooks.Rows.Select(r => r["Title"]));

        public void ShowBooks(IEnumerable<string> expectedTitles)
        {
            //Act
            var shownBooks = _result.Model<IEnumerable<PROPERTy>>();

            //Assert
            PropertyAssertions.HomeScreenShouldShow(shownBooks, expectedTitles);
        }
    }
}
