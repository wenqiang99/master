using MyPractice.Util.Base.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Common.DropDown
{
    /// <summary>
    /// 下拉菜单
    /// </summary>
    public class DropDownMenu : EntityBase
    {
        /// <summary>
        /// 中文名称
        /// </summary>
        public string ChineseName { get; set; } = "";

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; set; } = "";

        /// <summary>
        /// 节点的层级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 选项描述
        /// </summary>

        public string ItemDesciption { get; set; } = "";
    }
}
