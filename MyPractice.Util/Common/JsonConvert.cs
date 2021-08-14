using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABBMASWeld.Utility
{
    public class JsonConvert
    {
        /// <summary>
        /// JSON序列化对象
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns>json字符串</returns>
        public static string Serialize(object value)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(value);
        }
        /// <summary>
        /// JSON反序列化字段
        /// </summary>
        /// <param name="jsonText">json字符串</param>
        /// <param name="valueType">对象类型</param>
        /// <returns></returns>
        public static T Deserialize<T>(string jsonText)
        {
            if (string.IsNullOrEmpty(jsonText)) return default(T);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonText);
        }
    }
}
