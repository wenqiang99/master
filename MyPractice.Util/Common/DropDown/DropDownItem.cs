using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Common.DropDown
{
    /// <summary>
    /// 通用下拉列表
    /// </summary>
    public class DropDownItem : Entity<Guid>
    {
        /// <summary>
        /// 选项描述
        /// </summary>

        public string ItemDesciption { get; set; } = "";

        /// <summary>
        /// 是否自读
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; } = "";

        /// <summary>
        /// 实际传值
        /// </summary>
        public string Pid { get; set; }

        /// <summary>
        ///     内部名称
        /// </summary>
        public string ItemName { get; set; } = "";

        /// <summary>
        ///     是否启用，是否有效
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// 最后修改时间
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
        public int Order { get; set; }

        /// <summary>
        /// 节点的层级
        /// </summary>
        public int Level { get; set; } = 1;

        /// <summary>
        /// 父节点的Id
        /// </summary>
        public Guid ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// 子项
        /// </summary>
        public List<DropDownItem> ChildItem { get; set; }
    }
}
