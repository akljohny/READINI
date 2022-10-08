using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Collections.Generic;

namespace ReadINI
{
    class ReadINI
    {
        public const int SECTION_SIZE = 32767;
        public const int KEY_SIZE = 2048;
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32")]
        static extern uint GetPrivateProfileSectionNames(IntPtr SectionReturnBuffer, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileSection(string section, byte[] KeyReturnBuffer, int size, string filePath);
        
        public static List<string> SectionNames(string path)
        {
            IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)SECTION_SIZE);
            uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, SECTION_SIZE, path);
            if (bytesReturned == 0)
                return null;
            string sectionNamesLocal = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
            string[] tmp = sectionNamesLocal.Split('\0');
            List<string> result = new List<string>();
            foreach (string entry in tmp)
            {
                result.Add(entry);
            }
            Marshal.FreeCoTaskMem(pReturnedString);
            return result;
        }

         public static List<string> GetKeyList(string filePath, string section)
        {
            byte[] buffer = new byte[KEY_SIZE];
            GetPrivateProfileSection(section, buffer, KEY_SIZE, filePath);
            String[] keysTemp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
            List<string> keylist = new List<string>();
            foreach (String entry in keysTemp)
            {
                if (entry.Length > 0)
                {
                    if (entry.Contains("="))
                    {
                        keylist.Add(entry.Substring(0, entry.IndexOf("=")));
                    }
                }
            }
            return keylist;
        }
        public static List<string> GetKey(List<string> keyList,string keyref)
        {
            List<string> keys= new List<string>();
            foreach (var key in keyList)
            {
                
                    keys.Add(key);
                
            }
                return keys;
        }
         public static string GetValue(string section, string key, string path)
        {
            String valueTemp ;
            GetPrivateProfileString(section, key, "", valueTemp, VALUE_SIZE, path);
            return valueTemp.ToString();
        }
    }
}
