using System;

namespace TextHelper.Interface
{
    /// <summary>
    /// 系統日期管理器介面
    /// </summary>
    internal interface IDateTimeManager
    {
        /// <summary>
        /// 當下日期時間
        /// </summary>
        DateTime Now { get; }

        /// <summary>
        /// 當下日期
        /// </summary>
        DateTime Today { get; }
    }
}