using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AllPurposeCalculator.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetDescription(this Enum genericEnum)
        {
            Type genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if ((attributes != null && attributes.Count() > 0))
                {
                    return ((System.ComponentModel.DescriptionAttribute)attributes.ElementAt(0)).Description;
                }
            }
            return genericEnum.ToString();
        }

        public static string GetFormatedHeadline(this string headline)
        {
            return $"------------- {headline} -------------";
        }
    }

}
