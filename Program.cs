using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{

    #region Used For Program 1
    public class A
    {
        public B b { get; set; }
    }
    public class B
    {
        public string c { get; set; }
        public string a { get; set; }
    } 
    #endregion
    public class Program
    {
        #region Program : 1 .Program with a.b.c=c.b.a as Valid Expression
        //NO input from User
        // No Print Statement Used
        public string UseADotBDotCEqualsCDotBDotA()
        {
            A a = new A()
            {
                b = new B()
                {
                    a = "Value1",
                    c = "Value2"
                }
            };
            A c = new A()
            {
                b = new B()
                {
                    a = "ReplacedValue",
                    c = "replacedvalue2"
                }
            };
            a.b.c = c.b.a;
            return a.b.c;

        }
        #endregion

        #region Program : 2. Scan a givem folder and prints the count of files grouped by created month

        #region 2.1 Exmaple output
        // Please Enter Path of a Folder : c://program/Assignment
        // Number of files created in January : 12
        //Number of files created in Feb:1
        //Number of files created in March : 3  and so on ......... 
        #endregion
        #region 2.2 Implementation

        public void ShowCountOfFilesCreatedPerMonth(DirectoryInfo directory)
        {

            var files = new List<string>();
            var fileslist = directory.GetFiles().Select(n => n.CreationTime.ToString("MMMM")).GroupBy(i => i).Select(i => new { Month = i.Key, Count = i.Count() }).ToList();
            foreach (var month in fileslist)
                Console.WriteLine("Number of files created in {0} : {1} ", month.Month, month.Count);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Path of a Folder");
            var pathDirectory = @"" + Console.ReadLine();
            DirectoryInfo directory = new DirectoryInfo(pathDirectory);
            if (!directory.Exists)
                throw new InvalidOperationException("Directory does not exist : " + pathDirectory);

            Program p = new Program();
            //Not considering the year .
            p.ShowCountOfFilesCreatedPerMonth(directory);
            // Console.Read();
            //Console.WriteLine("Don't consider this line :"+ p.UseADotBDotCEqualsCDotBDotA());
        }
        #endregion 
        #endregion
    }
}
