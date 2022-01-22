using Abp.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace MyPractice.Utility
{
    public class ObjectConverter
    {
        #region 数据处理
        public static float Object2float(object obj)
        {
            if (obj == null) return 0;
            float result;
            if (float.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }
        public static decimal Object2decimal(object obj)
        {
            if (obj == null) return 0;
            decimal result;
            if (decimal.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }
        public static int Bool2int(bool b1)
        {
            return b1 ? 1 : 0;
        }
        public static string Bool2String(bool? input)
        {
            if (input == null || !input.Value) return "否";
            else return "是";
        }
        //public static bool String2Bool(object objValue)
        //{
        //    string value = objValue == null ? "" : objValue.ToString();
        //    try
        //    {
        //        return bool.Parse(value);
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public static bool Object2bool(object obj)
        {
            if (obj == null) return false;
            try
            {
                bool bRtn = Convert.ToBoolean(obj);
                return bRtn;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 安全将对象转成字符串。null或错误值被当成0。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Object2int(object obj)
        {
            if (obj == null)
                return 0;
            int result;
            if (int.TryParse(obj.ToString(), out result))
                return result;
            else
                return 0;
        }
        /// <summary>
        /// 安全将对象转成字符串。null或错误值被当成-1。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int Object2int2(object obj)
        {
            if (obj == null)
                return -1;
            int result;
            if (int.TryParse(obj.ToString(), out result))
                return result;
            else
                return -1;
        }
        public static double Object2Double(object objValue)
        {
            double ret = 0;
            try
            {
                ret = double.Parse(objValue.ToString());
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 安全将对象转成字符串。null被当成空字符串。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Object2string(object obj)
        {
            string ret = "";
            try
            {
                if (obj != null && obj != DBNull.Value)
                { ret = obj.ToString().Trim(); }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 安全将对象转成指定的字符串。 
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defaultString">指定的字符串</param>
        /// <returns></returns>
        public static string Object2string(object obj, string defaultString)
        {
            string ret = defaultString;
            try
            {
                if (obj != null && obj != DBNull.Value)
                { ret = obj.ToString().Trim(); }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 安全将对象转成指定的字符串
        /// </summary>
        /// <param name="obj">要转换的对象</param> 
        /// <param name="defaultString">指定的字符串</param>
        /// <param name="removeString">要排除的字符串</param>
        /// <returns></returns>
        public static string Object2string(object obj, string defaultString, string removeString)
        {
            string ret = defaultString;
            try
            {
                if (obj != null && obj != DBNull.Value && obj.ToString().Trim() != removeString)
                { ret = obj.ToString().Trim(); }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 类型转换,专门处理可空的值类型转换
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="convertsionType">要转换的类型</param>
        /// <returns></returns>
        public static object ChangeType(object value, Type convertsionType)
        {
            return ChangeType(value, convertsionType, null);
        }
        /// <summary>
        /// 类型转换,专门处理可空的值类型转换
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="convertsionType">要转换的类型</param>
        /// <returns></returns>
        public static object ChangeType(object value, Type convertsionType, string key)
        {
            try
            {
                //判断convertsionType类型是否为泛型，因为nullable是泛型类,
                if (convertsionType.IsGenericType &&
                    //判断convertsionType是否为nullable泛型类
                    convertsionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    if (value == null || value.ToString().Length == 0)
                    {
                        return null;
                    }

                    //如果convertsionType为nullable类，声明一个NullableConverter类，该类提供从Nullable类到基础基元类型的转换
                    NullableConverter nullableConverter = new NullableConverter(convertsionType);
                    //将convertsionType转换为nullable对的基础基元类型
                    convertsionType = nullableConverter.UnderlyingType;
                }
                return Convert.ChangeType(value, convertsionType);
            }
            catch
            {
                return convertsionType.IsValueType ? Activator.CreateInstance(convertsionType) : null;
            }
        }
        public static bool isNumeric(String message, out double result)
        {
            Regex rex = new Regex(@"^[-]?\d+[.]?\d*$");
            result = -1;
            if (rex.IsMatch(message))
            {
                return double.TryParse(message, out result);
            }
            else
                return false;
        }
        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="source"></param>
        /// <param name="precision"></param>
        /// <returns></returns>
        public static decimal Rounding(decimal source, int precision = 0)
        {
            string format = "0";
            if (precision > 0)
            {
                format += ".";
                for (int i = 0; i < precision; i++)
                {
                    format += "0";
                }
            }
            return decimal.Parse(source.ToString(format));
        }
        /// <summary>
        /// 获取Guid
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
        /// <summary>
        /// 是否为整数
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(string value)
        {
            if (value.IsNullOrWhiteSpace())
                return true;
            Regex r = new Regex(@"^[0-9]+$");
            bool isInt = r.IsMatch(value);
            return isInt;
        }
        #endregion

        #region 时间格式处理

        /// <summary>
        /// 安全将对象转成日期。null被当成最小日期。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime Object2DateTimeByFormat(string dateString, string format = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(format))
                    format = "yyyyMMddHHmmss";
                if (string.IsNullOrWhiteSpace(dateString))
                    return default(DateTime);
                DateTime dt = DateTime.ParseExact(dateString, format, CultureInfo.CurrentCulture);
                return dt;
            }
            catch
            {
            }
            return default(DateTime);
        }
        /// <summary>
        /// 安全将对象转成日期。null被当成最小日期。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static DateTime Object2DateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return default(DateTime);
            DateTime result;
            if (DateTime.TryParse(obj.ToString(), out result))
                return result;
            else
                return default(DateTime);
        }
        /// <summary>
        /// 判断是否为日期格式
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDateTime(object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return false;
            DateTime result;
            return DateTime.TryParse(obj.ToString(), out result);
        }
        /// <summary>
        /// 日期格式化, yyyy-MM-dd
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string Date2String(object objValue)
        {
            string formate = "yyyy-MM-dd";
            string ret = "";
            try
            {
                if (objValue != null)
                {
                    DateTime dt = DateTime.Parse(objValue.ToString());
                    if (dt != DateTime.MinValue && dt != DateTime.Parse("1900-01-01"))
                    { ret = dt.ToString(formate); }
                }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 日期格式化, HH:mm
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string Time2String(object objValue)
        {
            string formate = "HH:mm";
            string ret = "";
            try
            {
                if (objValue != null)
                {
                    DateTime dt = DateTime.Parse(objValue.ToString());
                    if (dt != DateTime.MinValue && dt != DateTime.Parse("1900-01-01"))
                    { ret = dt.ToString(formate); }
                }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 日期格式化, yyyy-MM-dd HH:mm
        /// </summary>
        /// <param name="objValue"></param>
        /// <returns></returns>
        public static string DateTime2String(object objValue, string formate = "")
        {
            if (string.IsNullOrWhiteSpace(formate)) formate = "yyyy-MM-dd HH:mm";
            string ret = "";
            try
            {
                if (objValue != null)
                {
                    DateTime dt = DateTime.Parse(objValue.ToString());
                    if (dt != DateTime.MinValue && dt != DateTime.Parse("1900-01-01"))
                    { ret = dt.ToString(formate); }
                }
            }
            catch
            {
            }
            return ret;
        }
        /// <summary>
        /// 获取2个时间点的时长
        /// </summary>
        /// <param name="beginTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static decimal GetSpanHour(DateTime? beginTime, DateTime? endTime)
        {
            if (beginTime == null || endTime == null)
                return 0;

            TimeSpan ts1 = new TimeSpan(endTime.Value.Ticks);
            TimeSpan ts2 = new TimeSpan(beginTime.Value.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            decimal totalHours = (decimal)ts.TotalHours;
            decimal res = ObjectConverter.Rounding(totalHours, 2);
            return res;
        }
        #endregion

        #region 数据校验
        public static bool IsGuidEmpty(Guid? input)
        {
            if (input == null || input == Guid.Empty)
                return true;
            return false;
        }
        #endregion

        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <param name="beg"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public static int GetRedom(int beg, int end)
        {
            Random rd = new Random();
            return rd.Next(beg, end);
        }

        public static string GetCashCode(int cash)
        {
            string title = null;
            if (cash == 1)
                title = "CX";
            else
                title = "CM";
            string no = title + DateTime.Now.ToString("yyMMddHHmmss") + ObjectConverter.GetRedom(10, 99);
            return no;
        }
        public static string GetDocumentCode()
        {
            string no = "DM" + DateTime.Now.ToString("yyMMddHHmmss") + ObjectConverter.GetRedom(10, 99);
            return no;
        }
        private static JObject TransJObject(JObject obj)
        {
            JObject obj2 = new JObject();
            foreach (var x in obj.Properties())
            {
                var name2 = x.Name.Substring(0, 1).ToUpper() + x.Name.Substring(1);
                obj2[name2] = obj[x.Name];
            }
            return obj2;
        }
    }

}
