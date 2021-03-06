﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.EnumCommon
{
    public class Helper
    {
        public static string GetEnumDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            string description = value.ToString();
            System.Reflection.FieldInfo fieldinfo = value.GetType().GetField(description);
            EnumDescriptionAttribute[] attributes = (EnumDescriptionAttribute[])fieldinfo.GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <summary>
        /// 遍历Enum
        /// </summary>
        /// <param name="enumType">typeof(enum)</param>
        /// <returns>字典集</returns>
        public static Dictionary<int, string> ErgodicEnum(Type enumType)
        {
            Dictionary<int, string> enumDict = new Dictionary<int, string>();
            foreach (var item in Enum.GetValues(enumType))
            {
                var enumItem = item as Enum;
                if (enumItem == null)
                {
                    continue;
                }
                enumDict[(int)item] = GetEnumDescription(enumItem);
            }
            return enumDict;
        }

        //public static int IntToEnum()
        //{

        //}
    }

    public sealed class EnumDescriptionAttribute : Attribute
    {
        public string Description { get; set; }

        public EnumDescriptionAttribute(string description)
                : base()
        {
            this.Description = description;
        }
    }
}
