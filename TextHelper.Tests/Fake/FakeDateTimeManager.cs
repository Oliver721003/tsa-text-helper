using System;
using TextHelper.Interface;

namespace TextHelper.Tests.Fake
{
    public class FakeDateTimeManager : IDateTimeManager
    {
        public FakeDateTimeManager(DateTime now)
        {
            Now = now;
        }

        public DateTime Now { get; }

        public DateTime Today => Now;
    }
}