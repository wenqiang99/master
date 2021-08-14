using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Base.View
{
    /// <summary>
    /// 视图返回值
    /// </summary>
    public interface IViewResult
    {
        /// <summary>
        /// 指示是否成功
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        string Message { get; set; }
    }

    /// <summary>
    /// 视图返回值的泛型接口
    /// </summary>
    /// <typeparam name="T">返回值类型</typeparam>
    public interface IViewResult<T> : IViewResult
    {
        /// <summary>
        /// 返回值数据
        /// </summary>
        T Result { get; set; }
    }
}
