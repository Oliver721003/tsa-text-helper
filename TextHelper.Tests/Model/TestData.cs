using System.Collections.Generic;

namespace TextHelper.Tests.Model
{
    public class TestData
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public TestDetail Detail { get; set; }

        public List<TestDetail> Details { get; set; }
    }
}