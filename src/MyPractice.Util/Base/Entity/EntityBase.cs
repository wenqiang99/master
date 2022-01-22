using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace MyPractice.Util.Base.Entity
{
    public class EntityBase : Entity<Guid>
    {
        /// <summary>
        ///     内部名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        ///     是否启用，是否有效
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     最后修改时间
        /// </summary>
        public DateTime ModifiedTime { get; set; } = DateTime.Now;

        /// <summary>
        ///     最后一个修改用户
        /// </summary>
        public string ModifiedUser { get; set; } = "";

        /// <summary>
        ///     版本（自增，维护用）
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        ///     排序
        /// </summary>
        public int Order { get; set; } = 1;
    }
}
