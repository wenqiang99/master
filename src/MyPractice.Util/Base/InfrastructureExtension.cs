using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using MyPractice.Util.Base.Entity;
using MyPractice.Util.Base.PagingQuery;
using MyPractice.Util.Base.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyPractice.Util.Base
{
    /// <summary>
    /// 通用拓展方法
    /// </summary>
    public static class InfrastructureExtension
    {
        #region pageQuery

        /// <summary>
        /// 分页查询拓展方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Tk"></typeparam>
        /// <param name="query"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static PagedViewResult<T, Tk> PagedView<T, Tk>(this IQueryable<T> query, Tk input)
            where Tk : PagedInputDto
            => new PagedViewResult<T, Tk>(query, input);

        #endregion

        #region EntityBase

        /// <summary>
        /// 设置所属层级, 当父节点不存在时, 标识当前层级为第一层级; 否则当前层级为父节点层级加1
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <typeparam name="TPrimaryKey"></typeparam>
        /// <param name="e"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public static int SetLevel<TEntity, TPrimaryKey>(this IRepository<TEntity, TPrimaryKey> e, TPrimaryKey parentId)
            where TEntity : EntityLevelBase, IEntity<TPrimaryKey>
            => e.FirstOrDefault(_ => _.Id.Equals(parentId))?.Level + 1 ?? 1;


        /// <summary>
        /// 设置版本号自增
        /// </summary>
        /// <typeparam name="T"><c>BoBase</c>类型</typeparam>
        /// <param name="e">对象</param>
        /// <returns>对象</returns>
        public static T SetVersion<T>(this T e) where T : EntityBase
        {
            ++e.Version;
            return e;
        }

        /// <summary>
        /// 设置修改人
        /// </summary>
        /// <typeparam name="T"><c>BoBase</c>类型</typeparam>
        /// <param name="e">对象</param>
        /// <param name="name">修改人名称</param>
        /// <returns>对象</returns>
        public static T SetModifiedUser<T>(this T e, string name) where T : EntityBase
        {
            e.ModifiedUser = name;
            return e;
        }

        /// <summary>
        /// 设置修改时间为当前时间
        /// </summary>
        /// <typeparam name="T"><c>BoBase</c>类型</typeparam>
        /// <param name="e">参数</param>
        /// <returns>结果</returns>
        public static T SetModifiedTime<T>(this T e) where T : EntityBase
        {
            e.ModifiedTime = DateTime.Now;
            return e;
        }

        /// <summary>
        /// 更新时间、版本号和当前修改人三个信息
        /// </summary>
        /// <typeparam name="T"><c>BoBase</c>类型</typeparam>
        /// <param name="e">参数</param>
        /// <param name="name">修改人名称</param>
        /// <returns>结果</returns>
        public static T SetUpdate<T>(this T e, string name) where T : EntityBase =>
            e.SetModifiedUser(name).SetModifiedTime().SetVersion();

        #endregion

        #region ViewResult

        /// <summary>
        /// 给前端的DTO成功的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        public static ViewResult<T> Success<T>(this T e) => new ViewResult<T>(true, e.DeciamlTrim());

        /// <summary>
        /// 给前端的DTO成功的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ViewResult<T> Success<T>(this T e, string message) =>
            new ViewResult<T>(true, message, e.DeciamlTrim());

        /// <summary>
        /// 给前端的DTO成功的
        /// </summary>
        /// <returns></returns>
        public static ViewResult Success() => new ViewResult(true);

        /// <summary>
        /// 给前端的DTO 成功的
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ViewResult Success(string message) => new ViewResult(true, message);


        /// <summary>
        /// 给前端的DTO失败的
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static ViewResult Failed(string error) => new ViewResult(false, error);

        /// <summary>
        /// 给前端的DTO 失败的
        /// </summary>
        /// <returns></returns>
        public static ViewResult Failed() => new ViewResult(false);

        /// <summary>
        /// 给前端的DTO失败的
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static ViewResult Failed(Exception ex)
        {
            // todo 投入正式使用时，请将错误提示修改成 友好的错误提示， 并将错误信息记录
            return new ViewResult(false, ex.Message);
        }

        #endregion

        #region SafeTrim

        /// <summary>
        /// 带空值检验的去空格处理
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SafeTrim(this string str) => string.IsNullOrWhiteSpace(str) ? "" : str.Trim();

        /// <summary>
        /// 对class内的字符串属性进行去空格处理
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TObject SafeTrim<TObject>(this TObject obj) where TObject : class
        {
            foreach (var val in obj.GetType().GetProperties().Where(_ => _.PropertyType == typeof(string)))
                val.SetValue(obj, (val.GetValue(obj) as string).SafeTrim());

            return obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static TObject DeciamlTrim<TObject>(this TObject obj)
        {
            foreach (var val in obj.GetType().GetProperties().Where(_ => _.PropertyType == typeof(decimal)))
                val.SetValue(obj, Convert.ToDecimal(val.GetValue(obj)).Normalize());

            return obj;
        }


        // https://stackoverflow.com/questions/4298719/parse-decimal-and-filter-extra-0-on-the-right
        /// <summary>
        /// decimal 去除多余的0
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal Normalize(this decimal value) => value / 1.0000_0000_0000_0000_0000_0000_0000m;

        #endregion
    }
}
