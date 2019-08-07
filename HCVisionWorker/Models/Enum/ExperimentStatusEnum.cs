using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HCVisionWorker.Models.Enum
{
    public enum ExperimentStatusEnum
    {
        [Description("未开始")]
        NotStarted = 0,
        [Description("进行中")]
        Starting = 1,
        [Description("已结束")]
        Ended = -1,
    }
}
