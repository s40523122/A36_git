﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace RosSharp_HMI.Services
{
    public class INiReader
    {
        // 寫入 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        /// <summary>
        /// 將資料寫入 INI 檔案
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <param name="value">資料參數之值</param>
        /// <returns>(bool) 是否寫入</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static bool WriteINIFile(string path, string section, string key, string value)
        {
            try
            {
                // 寫入INI檔案
                WritePrivateProfileString(section, key, value, path);
                return true;
            }
            catch
            {
                return false;
            }

        }

        // 讀取 INI 檔案的方法
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string section, string key, string defaultValue, StringBuilder returnBuffer, int size, string filePath);

        /// <summary>
        /// 讀取 INI 檔案內資料之值
        /// </summary>
        /// <param name="path">INI 檔案地址</param>
        /// <param name="section">資料所在之節</param>
        /// <param name="key">資料參數名稱</param>
        /// <returns>(string) 讀取之資料內容</returns>
        /// <remarks>
        /// 若欲使用工作位置資料夾路徑，可使用下列程式碼
        /// <code>
        /// string DataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config/temp.ini");
        /// </code>
        /// </remarks>
        public static string ReadINIFile(string path, string section, string key)
        {
            const int bufferSize = 255; // 緩衝區大小
            StringBuilder buffer = new StringBuilder(bufferSize);

            GetPrivateProfileString(section, key, "", buffer, bufferSize, path);

            return buffer.ToString();
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);
        /// <summary>
        /// 將Section內所有資料組成 [[Key, Value]] 列表
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public static List<List<string>> GetAllList(string iniFile, string section)
        {

            byte[] buffer = new byte[2048];

            GetPrivateProfileSection(section, buffer, 2048, iniFile);
            String[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');

            //List<string> result = new List<string>();
            List<List<string>> resultList = new List<List<string>>();

            if (tmp[0] != "")
            {
                resultList = tmp
                .Select(item => item.Split('=').ToList())
                .ToList();
            }


            //string jsonString = JsonConvert.SerializeObject(resultList, Formatting.Indented);

            //foreach (String entry in tmp)
            //{
            //    result.Add(entry.Substring(0, entry.IndexOf("=")));
            //}

            return resultList;
        }
    }
}
