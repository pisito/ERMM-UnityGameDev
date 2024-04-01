using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ERMM.GenericData.Utility
{
    public static class StaticExtensions
    {

        #region enum extensions
        // Extension for enum with the atribute DisplayText to be printed as string
        public static string ToDescription(this Enum en)
        {

            Type type = en.GetType();

            MemberInfo[] memInfo = type.GetMember(en.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {

                object[] attrs = memInfo[0].GetCustomAttributes(
                                              typeof(DisplayText),

                                              false);

                if (attrs != null && attrs.Length > 0)

                    return ((DisplayText)attrs[0]).Text;

            }

            return en.ToString();

        }
        #endregion

        #region string extension
        // This is the extension method.
        // The first parameter takes the "this" modifier
        // and specifies the type for which the method is defined.
        public static string Bold(this string str) => "<b>" + str + "</b>";
        public static string Color(this string str, string clr) => string.Format("<color={0}>{1}</color>", clr, str);
        public static string Italic(this string str) => "<i>" + str + "</i>";
        public static string Size(this string str, int size) => string.Format("<size={0}>{1}</size>", size, str);
        #endregion
    }
}
    
