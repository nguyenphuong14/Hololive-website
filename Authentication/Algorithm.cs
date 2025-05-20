using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Authentication
{
    public class Algorithm
    {
        /// <summary>
        /// 暗号化
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916"));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// 復号化
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <returns></returns>
        public static string Decrypt(string toDecrypt)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916"));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// SpecialCharチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasSpecialChar(string input)
        {
            ///special characters
            Regex special = new Regex("[^A-Za-z0-9 ]");
            Match match = special.Match(input);
            if (match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Numberチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasNumber(string input)
        {
            ///number 0-9
            Regex number = new Regex("[0-9]");
            Match match = number.Match(input);
            if (match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// LowerCaseCharチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasLowerCaseChar(string input)
        {
            ///letters form a-z (lowercase)
            Regex lowercase = new Regex("[a-z]");
            Match match = lowercase.Match(input);
            if (match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// UpperCaseCharチェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool HasUpperCaseChar(string input)
        {
            ///letters form a-z (Uppercase)
            Regex uppercase = new Regex("[A-Z]");
            Match match = uppercase.Match(input);
            if (match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool HasAdvancedPass(string input)
        {
            ///number 0-9
            Regex number = new Regex("[0-9]");
            ///letters form a-z (lowercase)
            Regex lowercase = new Regex("[a-z]");
            ///letters form a-z (Uppercase)
            Regex uppercase = new Regex("[A-Z]");
            ///special characters
            Regex special = new Regex("[^A-Za-z0-9 ]");

            Match match = special.Match(input);
            if (match.Success)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public static List<string> StringToList(string input)
        {
            List<string> result;
            result = input.Split(',').ToList();
            return result;
        }
        public static string[] StringToArray(string input)
        {
            string[] result;
            result = input.Split(',');
            return result;
        }
        public static string ListToString(List<string> input)
        {
            string result;
            result = string.Join(",", input.ToArray());
            return result;
        }
        public static string DaytoString(string input)
        {   
            string result;
            string[] split1; 
            string[] split2;
            split1 = input.Split(' ');
            split2 = split1[0].Split('/');
            result= split2[1]+"月"+ split2[2]+"日";
            if (Convert.ToInt64(split2[0].ToString()) > 2000)
            {
                result = split2[0] + "年" + split2[1] + "月" + split2[2] + "日";
            }
            return result;
        }
        public static DateTime StringtoDate(string input)
        {
            string result = "0001/"+ input;
           
            return Convert.ToDateTime(result);
        }
        public static string Showunit(string input)
        {
            string result;
            result = input.Replace("stgen", "期生");
            return result;
        }
        public static string BirthdaytoString(string input)
        {
            string[] split = input.Split('/') ;
            return split[1]+"/"+ split[2];
        }

        public static string DatetimeToString(string input)
        {
            string[] split = input.Split(' '); 
            return split[0];
        }
        public static string StringToDatetime(string input)
        {
            string[] split_year = new string[2] ;
            string[] split_monthday = new string[2];
            int j = 0;
            for (int i = 0; i < input.Length; i += 4)
            {
                int length = Math.Min(4, input.Length - i);
                split_year[j]=input.Substring(i, length);
                j++;
            }
            j = 0;
            for (int i = 0; i < split_year[1].Length; i += 2)
            {
                int length = Math.Min(2, split_year[1].Length - i);
                split_monthday[j] = split_year[1].Substring(i, length);
                j++;
            }

            return split_year[0] + "/" + split_monthday[0] + "/" + split_monthday[1];
        }

    }
}
