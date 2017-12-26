using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Drivers.PropertyDetails;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding, Scope(Tag = "automated")]
    class ViewListOFProject_1Steps
    {
        private readonly PropertyDriver _projectDriver;
        public ViewListOFProject_1Steps(PropertyDriver driver)
        {
            _projectDriver = driver;
        }

        [When(@"I input '(.*)' and '(.*)' into Login paged")]
        public void WhenIInputAndIntoLoginPaged(string p0, int p1, Table table)
        {
            _projectDriver.Navigate(table);
        }

        [Then(@"I should see my own projects")]
        public void ThenIShouldSeeMyOwnProjects(Table table)
        {
            _projectDriver.ShowList(table);
        }


    }
}
