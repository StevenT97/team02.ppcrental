using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TEDU_MVC.AcceptanceTests.Drivers.Search;
using TEDU_MVC.AcceptanceTests.Drivers.PropertyDetails;
using System.Linq;

namespace TEDU_MVC.AcceptanceTests.StepDefintions
{
    [Binding]
    public class PropertySteps
    {
        private readonly PropertyDriver _propertyDriver;

        public PropertySteps(PropertyDriver drivers)
        {
            _propertyDriver = drivers;
        }
        [Given(@"the following property Agency")]
        public void GivenTheFollowingPropertyAgency(Table userTable)
        {
            _propertyDriver.InsertUserToDb(userTable);
        }

        [Given(@"the following property and list feature '(.*)'")]
        public void GivenTheFollowingPropertyAndListFeature(string p0, Table givenProject)
        {
            var listFeature = p0.Split(',').Select(t => t.Trim().Trim('\''));
            _propertyDriver.InsertPropertyToDB(givenProject, listFeature);
        }
    }
}
