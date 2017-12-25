using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.FrameWork;
using FluentAssertions;

namespace TEDU_MVC.AcceptanceTests.Common
{
    public class PropertyAssertions
    {
        public static void ListScreenShouldShowInOrder(IEnumerable<PROPERTy> shownBooks, IEnumerable<PROPERTy> expectedBooks)
        {
            shownBooks.ShouldAllBeEquivalentTo(expectedBooks, option => option.Excluding(o => o.ID).WithStrictOrdering());
        }
        // Đúng Giá trị Đúng Số lượng
        public static void FoundPropertysShouldMatchTitles(IEnumerable<PROPERTy> foundPropertys, IEnumerable<string> expectedTitles)
        {
           // foundPropertys.Select(b => b.PropertyName).Should().BeEquivalentTo(expectedTitles);
            foundPropertys.Select(b => b.PropertyName).Should().Equal(expectedTitles);
        }
        // Đúng Giá trị ( giá trị mong đợi chỉ cần tồn tại trong list show
        public static void FoundBooksShouldMatchTitlesInOrder(IEnumerable<PROPERTy> foundBooks, IEnumerable<string> expectedTitles)
        {
            foundBooks.Select(b => b.PropertyName).Should().Contain(expectedTitles);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTy> shownBooks, string expectedTitle)
        {
            shownBooks.Select(b => b.PropertyName).Should().Contain(expectedTitle);
        }

        public static void HomeScreenShouldShow(IEnumerable<PROPERTy> shownBooks, IEnumerable<string> expectedTitles)
        {
            shownBooks.Select(b => b.PropertyName).Should().Contain(expectedTitles);
        }

        public static void HomeScreenShouldShowInOrder(IEnumerable<PROPERTy> shownBooks, IEnumerable<string> expectedTitles)
        {
            shownBooks.Select(b => b.PropertyName).Should().Contain(expectedTitles);
        }
    }
}
