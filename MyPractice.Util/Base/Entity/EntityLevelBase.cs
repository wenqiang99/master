using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Base.Entity
{
    /// <summary>
    /// 带有层级信息的数据模型基类
    /// </summary>
    public class EntityLevelBase : EntityBase
    {
        /// <summary>
        /// 节点的层级
        /// </summary>
        public int Level { get; set; } = 1;

        /// <summary>
        /// 父节点的Id
        /// </summary>
        public Guid ParentId { get; set; } = Guid.Empty;
    }
}
