using System.Collections.Generic;
using TEDU_MVC.Models;
using FluentAssertions;
using Models.FrameWork;

namespace TEDU_MVC.AcceptanceTests.Support
{
    public class ReferenceBookList : Dictionary<string, PROPERTy>
    {
        public PROPERTy GetById(string bookId)
        {
            return this[bookId.Trim()].Should().NotBeNull()
                                      .And.Subject.Should().BeOfType<PROPERTy>().Which;
        }
    }
}
