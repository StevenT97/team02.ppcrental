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
        private readonly PropertyDriverT _propertyDriver;

        public PropertySteps(PropertyDriverT drivers)
        {
            _propertyDriver = drivers;
        }
        [Given(@"the following property Agency")]
        public void GivenTheFollowingPropertyAgency(Table table)
        {

            _propertyDriver.InsertUserToDb(table);
        }

        [Given(@"the following project")]
        public void GivenTheFollowingProject(Table table)
        {
            _propertyDriver.InsertProjecttoDB(table);
        }

        [Given(@"the following property_feature")]
        public void GivenTheFollowingProperty_Feature(Table table)
        {
            _propertyDriver.InsertFeaturetoBD(table);
        }
    }
}
