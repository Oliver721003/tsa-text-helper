using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using TextHelper.Tests.Fake;
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
            var service = new TextParseService();

            var actual = service.Parse("無動態資料", data);

            actual.Should().Be("無動態資料");
        }

        [Test]
        public void 當傳入內容為Now_應回傳當下日期()
        {
            var data = new TestData();
            var now = DateTime.Now;
            var datetimeManager = new FakeDateTimeManager(now);
            var service = new TextParseService(datetimeManager);

            var actual = service.Parse("日期: #[Now]#", data);

            actual.Should().Be($"日期: {now.ToString(CultureInfo.InvariantCulture)}");
        }
    }
}