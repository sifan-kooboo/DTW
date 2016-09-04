using System;
using System.Collections.Generic;
using System.Text;

namespace Maticsoft.Common
{
    public class Common
    {
        #region 截取字符串
        /// 按照字符串的实际长度截取指定长度的字符串（英文字母为标准）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="Length">指定长度</param>
        /// <returns></returns>
        public static string CutStrLen(string str, int Length)
        {
            if (String.IsNullOrEmpty(str))
            {
                return str;
            }

            int i = 0, j = 0;

            foreach (char Char in str)
            {
                if ((int)Char > 127)
                    i += 2;
                else
                    i++;

                if (i > Length)
                {
                    str = str.Substring(0, j - 2) + "...";
                    break;
                }
                j++;
            }
            return str;
        }
        #endregion



    }
}
