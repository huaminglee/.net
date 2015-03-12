using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace PDTECH.OA.COM_SMS
{
    public class S_APP
    {
        public static string MD5HASH(string p_string, Encoding encode)
        {

            return MD5HASH(encode.GetBytes(p_string));
        }

        public static string MD5HASH(byte[] p_bytes)
        {
            byte[] s = (new MD5CryptoServiceProvider()).ComputeHash(p_bytes);
            StringBuilder sb = new StringBuilder();
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                sb.AppendFormat("{0:x2}", s[i]);
            }
            return sb.ToString().ToUpper();
        }
    }
}
