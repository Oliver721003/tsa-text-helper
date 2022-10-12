using System;
using System.Collections.Generic;
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
            var target = new TextParseService();
            var data = new TestData();
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("無動態資料", data, parameters);

            actual.Should().Be("無動態資料");
        }

        [Test]
        public void 當傳入內容為Now_應回傳當下日期()
        {
            var now = DateTime.Now;
            var datetimeManager = new FakeDateTimeManager(now);
            var target = new TextParseService(datetimeManager);

            var data = new TestData();
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("日期: #[Now]#", data, parameters);

            actual.Should().Be($"日期: {now.ToString()}");
        }

        [Test]
        public void 當傳入內容為Now_且格式為yyyMMdd_應回傳當下日期()
        {
            var now = DateTime.Now;
            var datetimeManager = new FakeDateTimeManager(now);
            var target = new TextParseService(datetimeManager);

            var data = new TestData();
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("日期: #[Now | date: yyyyMMdd ]#", data, parameters);

            actual.Should().Be($"日期: {now:yyyyMMdd}");
        }

        [Test]
        public void 當傳入內容有動態資料設定_應內容替代後回傳()
        {
            var target = new TextParseService();
            var data = new TestData { Id = "001", Name = "測試" };
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("動態資料: #[Id]# - #[Name]#", data, parameters);

            actual.Should().Be("動態資料: 001 - 測試");
        }

        [Test]
        public void 當傳入內容有參數資料設定_應內容替代後回傳()
        {
            var target = new TextParseService();
            var parameters = new Dictionary<string, string> { { "Id", "001" }, { "Name", "測試" } };

            var actual = target.Parse("動態資料: #[Id]# - #[Name]#", parameters);

            actual.Should().Be("動態資料: 001 - 測試");
        }

        [Test]
        public void 當傳入內容有下層動態資料_應內容替代後回傳()
        {
            var target = new TextParseService();
            var data = new TestData
            {
                Id = "001", Name = "測試",
                Detail = new TestDetail { Id = "001", Summary = "明細內容" }
            };
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("動態資料: [#[Id]#] #[Name]# - #[Detail.Summary]#", data, parameters);
            actual.Should().Be("動態資料: [001] 測試 - 明細內容");
        }

        [Test]
        public void 當傳入內容有金額格式_應內容替代後回傳()
        {
            var target = new TextParseService();

            var data = new TestData { Id = "001", Name = "測試", Price = 1000 };
            var parameters = new Dictionary<string, string>();

            var actual = target.Parse("動態資料: #[Id]# - #[Name]#, #[Price | currency]#", data, parameters);

            actual.Should().Be("動態資料: 001 - 測試, $1,000.00");
        }
    }
}