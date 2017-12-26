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
    public class PostProjectSteps
    {
        private readonly PropertyDriverT _projectDriver;
        public PostProjectSteps(PropertyDriverT driver)
        {
            _projectDriver = driver;
        }
        [When(@"I login")]
        public void WhenILogin(Table table)
        {
            _projectDriver.Navigate(table);
        }


        [When(@"I entered the following information")]
        public void WhenIEnteredTheFollowingInformation(Table table)
        {

            _projectDriver.InsertProjecttoDB(table);
        }

        [Then(@"The list of properties shoul have my new property")]
        public void ThenTheListOfPropertiesShoulHaveMyNewProperty(Table table)
        {
            _projectDriver.ShowList(table);
        }

    }
}
