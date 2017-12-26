using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using TechTalk.SpecFlow;

namespace TEDU_MVC.AcceptanceTests.Support
{
    [Binding]
    public class HttpContextStub
    {
        private static StubSession SessionStub;

        [BeforeScenario]
        public void CleanReferenceBooks()
        {
            SessionStub = null;
        }

        public static HttpContextBase Get()
        {
            var httpContextStub = new Mock<HttpContextBase>();
            if (SessionStub == null)
            {
                SessionStub = new StubSession();
            }

            httpContextStub.SetupGet(m => m.Session).Returns(SessionStub);
            return httpContextStub.Object;
        }

        public static void SetupController(Controller controller, RouteData routeData)
        {
            controller.ControllerContext = new ControllerContext { HttpContext = Get(), RouteData = routeData };
        }
        private class StubSession : HttpSessionStateBase
        {
            private readonly Dictionary<string, object> _state = new Dictionary<string, object>();

            public override object this[string name]
            {
                get { return !_state.ContainsKey(name) ? null : _state[name]; }
                set { _state[name] = value; }
            }
        }
    }
}
