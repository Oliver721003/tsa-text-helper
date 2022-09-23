using FluentAssertions;
using NUnit.Framework;
using TextHelper.Tests.Model;
using TextHelper.Text;

namespace TextHelper.Tests
{
    [TestFixture]
    public class TextParseTests
    {
        [Test]
        public void 當傳入內容沒有動態資料設定_應回傳原內容()
        {
            var data = new TestData();
            var actual = TextParseService.Parse("無動態資料", data);
            actual.Should().Be("無動態資料");
        }
    }
}