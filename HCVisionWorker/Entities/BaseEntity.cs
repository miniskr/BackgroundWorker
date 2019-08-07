using System;
using System.Collections.Generic;
using System.Text;

namespace HCVisionWorker.Entities
{
    public class BaseEntity
    {
        /// <summary>
        /// Guid
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? UpdateAt { get; set; }
        /// <summary>
        /// 修改用户
        /// </summary>
        public string UpdateUserId { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// 有效标记
        /// 0:失效；1:生效
        /// </summary>
        public int? EnableMark { get; set; } = 1;
    }
}
