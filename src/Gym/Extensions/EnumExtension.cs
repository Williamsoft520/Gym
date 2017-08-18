using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace System
{
    /// <summary>
    /// 表示对 <see cref="Enum"/> 实例的扩展。
    /// </summary>
    public static class EnumExtension
    {
        #region GetEnumDescription
        /// <summary>
        /// 获取当前枚举对象的 <see cref="DescriptionAttribute"/> 特性的 Description 字段。
        /// </summary>
        /// <param name="enumeration">被扩展的Enum对象</param>
        /// <returns>若未定义 <see cref="DescriptionAttribute"/> 特性，则返回枚举字段的默认值。否则，返回 <see cref="DescriptionAttribute"/> 的 Description 字段的值。</returns>
        public static string GetDescription(this Enum enumeration)
        {
            var enumType = enumeration.GetType();
            string enumName = enumeration.ToString();
            FieldInfo fieldInfo = enumType.GetTypeInfo().GetDeclaredField(enumeration.ToString());

            var description = enumName;
            if (fieldInfo == null)
            {
                return description;
            }
            if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null)
            {
                description = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
            }
            return description;
        }
        #endregion

        #region GetEnumItems

        /// <summary>
        /// 获取指定枚举的所有项并由指定值类型的 <see cref="IDictionary{TKey, TValue}" /> 实例存储；同时要求枚举项的值的数据类型是符合 <see cref="Int32" /> 的格式。
        /// </summary>
        /// <param name="enumType">需要操作的枚举类型。</param>
        /// <returns>
        /// 若在枚举项定义了 <see cref="DescriptionAttribute" /> 特性，将已该特性的 Description 属性作为 <see cref="Dictionary{TKey, TValue}" /> 的 Key 值，否则使用枚举项作为 Key 值；
        /// <see cref="Dictionary{TKey, TValue}" /> 的 Value 值将使用枚举项本身的值。
        /// </returns>
        /// <exception cref="System.NotSupportedException">当前类型不是一个枚举类型。</exception>
        public static IDictionary<string, int> GetEnumItems(this Type enumType)
        {
            return enumType.GetEnumItems<int>();
        }

        /// <summary>
        /// 获取指定枚举的所有项并由指定值类型的 <see cref="IDictionary{TKey, TValue}"/> 实例存储。
        /// </summary>
        /// <typeparam name="TValue">符合枚举类型的值的类型。</typeparam>
        /// <param name="enumType">需要操作的枚举类型。</param>
        /// <returns>
        /// 若在枚举项定义了 <see cref="DescriptionAttribute"/> 特性，将已该特性的 Description 属性作为 <see cref="Dictionary{TKey, TValue}"/> 的 Key 值，否则使用枚举项作为 Key 值；
        /// <see cref="Dictionary{TKey, TValue}"/> 的 Value 值将使用枚举项本身的值。
        /// </returns>
        /// <exception cref="System.NotSupportedException">当前类型不是一个枚举类型。</exception>
        public static IDictionary<string, TValue> GetEnumItems<TValue>(this Type enumType)
        {
            if (!enumType.GetTypeInfo().IsEnum)
            {
                throw new NotSupportedException("当前类型不是一个枚举类型。");
            }

            var enumNames = Enum.GetNames(enumType);
            var values = Enum.GetValues(enumType);

            var dicList = new Dictionary<string, TValue>(values.Length);

            for (var i = 0; i < values.Length; i++)
            {
                var value = values.GetValue(i).To<TValue>();
                var item = enumNames[i];

                FieldInfo fieldInfo = enumType.GetTypeInfo().GetDeclaredField(item);
                if (fieldInfo == null)
                {
                    continue;
                }

                if (fieldInfo.GetCustomAttribute<DescriptionAttribute>() != null)
                {
                    item = fieldInfo.GetCustomAttribute<DescriptionAttribute>().Description;
                }

                dicList.Add(item, value);
            }
            return dicList;
        }
        #endregion
    }
}
