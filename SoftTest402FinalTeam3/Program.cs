using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTest402.TeamTiga.FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Should load probably externalize environment specific information like this:
            string TED_Path = @"C:\UW\TedNPad\TedNPad.exe";
            TestCaseEdit.TestCase1(TED_Path);
            TestCaseEdit.TestCase2(TED_Path);
        }
    }
}
