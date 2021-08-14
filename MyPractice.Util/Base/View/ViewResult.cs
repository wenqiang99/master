using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.Util.Base.View
{
    /// <summary>
    /// 给前端的DTO Warper
    /// </summary>
    public class ViewResult : IViewResult<string>
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? "操作成功！" : "操作失败";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public ViewResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        /// <summary>
        /// 指示是否成功
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// 空字符
        /// </summary>
        public string Result { get; set; } = "";
    }

    /// <summary>
    /// 给前端的DTO Warper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ViewResult<T> : IViewResult<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public ViewResult()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="result"></param>
        public ViewResult(bool success, T result)
        {
            Success = success;
            Message = success ? "操作成功！" : "操作失败";
            Result = result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        /// <param name="result"></param>
        public ViewResult(bool success, string message, T result)
        {
            Success = success;
            Message = message;
            Result = result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        public ViewResult(bool success)
        {
            Success = success;
            Message = success ? "操作成功！" : "操作失败";
            Result = default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public ViewResult(bool success, string message)
        {
            Success = success;
            Message = message;
            Result = default;
        }

        /// <summary>
        /// 指示是否成功
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// 结果
        /// </summary>
        public T Result { get; set; }
    }
}
