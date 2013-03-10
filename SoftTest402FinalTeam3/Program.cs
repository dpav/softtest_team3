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
            string Log_File = "TeamTigaLog.txt";

            //Initialize the common harness
            Harness.Initialize(TED_Path, Log_File);

            // Use it to execute each individual test
            Harness.RunTest("Edit Test1 ", TestCaseDave.TestCase1);
            Harness.RunTest("Edit Test 2", TestCaseDave.TestCase2);          
        
            // TODO : extract the process.start, and just expose a Harness.Process object.
            // Leaving this open to discussion.
        }
    }
}
