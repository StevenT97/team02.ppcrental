using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Threading;
using TEDU_MVC.Models;
using TEDU_MVC.AcceptanceTests.Common;
using TEDU_MVC.AcceptanceTests.Drivers.Project;
using TEDU_MVC.UITests.Selenium;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding, Scope(Tag = "automated")]
     class EditTest2Steps
    {
        private readonly ProjectDrivers _projectDriver;
        public EditTest2Steps(ProjectDrivers driver) { _projectDriver = driver; }
        [Given(@"I want Edit follow this Catalog")]
        public void GivenIWantEditFollowThisCatalog(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I editting  follow this data")]
        public void WhenIEdittingFollowThisData(Table table)
        {
            _projectDriver.InsertProjecttoDB(table);
        }
        
        [Then(@"After Edit I want see the data same this follow")]
        public void ThenAfterEditIWantSeeTheDataSameThisFollow(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
