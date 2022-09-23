using System;
using System.Globalization;
using FluentAssertions;
using NUnit.Framework;
using TextHelper.Tests.Fake;
using TextHelper.Tests.Model;

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

        [Test]
        public void 當傳入內容有動態資料設定_應內容替代後回傳()
        {
            var data = new TestData { Id = "001", Name = "測試" };
            var service = new TextParseService();

            var actual = service.Parse("動態資料: #[Id]# - #[Name]#", data);

            actual.Should().Be("動態資料: 001 - 測試");
        }

        [Test]
        public void 當傳入內容有下層動態資料_應內容替代後回傳()
        {
            var data = new TestData
            {
                Id = "001", Name = "測試",
                Detail = new TestDetail { Id = "001", Summary = "明細內容" }
            };
            var service = new TextParseService();
            var actual = service.Parse("動態資料: [#[Id]#] #[Name]# - #[Detail.Summary]#", data);
            actual.Should().Be("動態資料: [001] 測試 - 明細內容");
        }
    }
}