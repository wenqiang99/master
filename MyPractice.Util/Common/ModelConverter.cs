using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ABBMASWeld.Utility
{
    /// <summary>
    /// 常用工具——类型转换
    /// </summary>
    public static class ModelConverter
    {
        #region 对象转Json,Json再转回指定类型的对象
        /// <summary>
        /// 对象转Json,Json再转回指定类型的对象
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="sourceModel"></param>
        /// <returns></returns>
        public static TResult ConverterByJson<TSource, TResult>(TSource sourceModel)
            where TSource : new()
            where TResult : new()
        {
            string jsonStr = JsonConvert.Serialize(sourceModel);
            return JsonConvert.Deserialize<TResult>(jsonStr);
        }
        public static IEnumerable<TResult> ConverterByJson<TSource, TResult>(IEnumerable<TSource> sourceModels)
            where TSource : new()
            where TResult : new()
        {
            string jsonStr = JsonConvert.Serialize(sourceModels);
            return JsonConvert.Deserialize<IEnumerable<TResult>>(jsonStr);
        }
        #endregion

        /// <summary>
        /// String类型默认赋值空字串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        public static void StringSetDefaulValue<T>(T source)
             where T : class, new()
        {
            if (source == null) return;

            Type resType = typeof(T);
            PropertyInfo[] properties = resType.GetProperties(BindingFlags.SetProperty | BindingFlags.GetProperty |
                                BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo p in properties)
            {
                if (p.PropertyType != typeof(string))
                    continue;
                var value = p.GetValue(source, null);
                string strValue = ObjectConverter.Object2string(value, string.Empty);
                p.SetValue(source, strValue, null);
            }
        }

    }
}
