using System.Collections.Generic;
using TEDU_MVC.Models;
using FluentAssertions;
using Models.FrameWork;

namespace TEDU_MVC.AcceptanceTests.Support
{
    public class ReferenceProject : Dictionary<string,PROPERTy >
    {
        public PROPERTy GetById(string ProjectId)
        {
            return this[ProjectId.Trim()].Should().NotBeNull()
                                        .And.Subject.Should().BeOfType<PROPERTy>().Which;
        }
    }
}
