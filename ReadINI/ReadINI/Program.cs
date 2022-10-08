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
                    Console.WriteLine("\nSection Name : {0}\n", section);
                    List<string> keyList = ReadINI.GetKeyList(filePath, section);
                    List<string>  keys= ReadINI.GetKey(keyList,"Type");
            }
        }
    }
}
