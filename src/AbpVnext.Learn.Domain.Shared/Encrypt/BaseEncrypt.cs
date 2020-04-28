using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;


namespace AbpVnext.Learn.Encrypt
{
    public class BaseEncrypt
    {
        //Md5加密
        public static string MD5Encrypt(string text)
        {
            StringBuilder sBuilder = new StringBuilder();

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("X2"));
                }
            }
            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        //Sha1加密解密
        public static string Sha1Encrypt(string text)
        {
            StringBuilder sBuilder = new StringBuilder();

            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                byte[] data = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
            }
            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
