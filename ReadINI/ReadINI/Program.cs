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
        }
    }
}
