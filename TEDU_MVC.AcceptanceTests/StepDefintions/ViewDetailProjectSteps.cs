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
    [Binding, Scope(Tag = "web")]
    public class ViewDetailProjectSteps
    {
        private readonly PropertyDriver _propertyDriver;

        public ViewDetailProjectSteps(PropertyDriver drivers)
        {
            _propertyDriver = drivers;
        }
        [Given(@"I am Home page")]
        public void GivenIAmHomePage()
        {
            
        }

        [When(@"I open the details of '(.*)'")]
        public void WhenIOpenTheDetailsOf(string p0)
        {
            _propertyDriver.OpenPropertyDetails(p0);
        }

        [Then(@"The details PropertyName should show")]
        public void ThenTheDetailsPropertyNameShouldShow(Table table)
        {
            _propertyDriver.ShowPropertyDetails(table);
        }

    }
}
