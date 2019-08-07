using HCVisionWorker.Models.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HCVisionWorker.Entities
{
    public class ExperimentTaskEntity : BaseEntity
    {
        /// <summary>
        /// 实验任务名称
        /// </summary>
        public string TaskName { get; set; }
        /// <summary>
        /// 实验任务描述
        /// </summary>
        public string TaskContent { get; set; }
        /// <summary>
        /// 实验课程id
        /// </summary>
        public string CourseId { get; set; }
        /// <summary>
        /// 班级id
        /// </summary>
        public string ClassId { get; set; }
        /// <summary>
        /// 是否全班上课
        /// </summary>
        public bool IsAllClass { get; set; }
        /// <summary>
        /// 任务开始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 任务结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 提交人数
        /// </summary>
        public int CompletedCount { get; set; }
        /// <summary>
        /// 任务状态
        /// </summary>
        public ExperimentStatusEnum Status { get; set; }
        /// <summary>
        /// 是否包含附件
        /// </summary>
        public bool IsHaveFile { get; set; }
    }
}
