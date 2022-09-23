using System;
using TsaBackEndInfrastructure.Utils;

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