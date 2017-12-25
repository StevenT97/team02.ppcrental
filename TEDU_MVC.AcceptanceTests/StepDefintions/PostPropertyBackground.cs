using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Drivers.Search;
using TEDU_MVC.AcceptanceTests.Drivers.PropertyDetails;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding, Scope(Tag = "automated")]
    public class PostPropertyBackground
    {
        private readonly SearchDriver _searchDriver;

        public PostPropertyBackground(SearchDriver drivers)
        {
            _searchDriver = drivers;
        }

        [When(@"I input the following information")]
        public void WhenIInputTheFollowingInformation(Table table)
        {
            _searchDriver.InsertBookToDB(table);
            _searchDriver.ListProperty();
        }

        [Then(@"the list of books should update")]
        public void ThenTheListOfBooksShouldUpdate(Table table)
        {
            _searchDriver.ShowBooks(table);
        }

    }
}
