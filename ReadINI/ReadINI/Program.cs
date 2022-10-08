using System;
using System.Collections.Generic;

namespace ReadINI
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "Mention path here";
            List<string> sectionNameList = ReadINI.SectionNames(filePath);
             foreach (var section in sectionNameList)
            {
                if (section != "")
                {
                    Console.WriteLine("\nSection Name : {0}\n", section);
                    List<string> keyList = ReadINI.GetKeyList(filePath, section);
                    List<string>  keys= ReadINI.GetKey(keyList,"Type");
                    foreach (var key in keys)
                    {
                        string value = ReadINI.GetValue(section, key, filePath);
                        Console.WriteLine("{0} = {1}", key, value);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
