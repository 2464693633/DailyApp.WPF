using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DailyApp.WPF.HttpClients
{
  
    public class MD5Helper
    {
        /// <summary>
        /// MD5加密 UTF8编码 32位
        /// </summary>
        /// <param name="content">明文</param>
        /// <returns>MD5加密后的32位字符串</returns>
        public static string GetMD5(string content)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(content)).Select(b => b.ToString("X2")));
        }
    }
}
