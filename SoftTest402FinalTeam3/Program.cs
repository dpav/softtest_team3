using System;
using SoftTest402.TeamTiga.FinalProject.HelperCommon;
using SoftTest402.TeamTiga.FinalProject.TestCase;

namespace SoftTest402.TeamTiga.FinalProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Should load probably externalize environment specific information like this:
            string TED_Path = @"C:\Program Files (x86)\TED Notepad\TedNPad.exe";
            string Log_File = "TeamTigaLog.txt";

            //Initialize the common harness
            Harness.Initialize(TED_Path, Log_File);

            // Use it to execute each individual test
            Harness.RunTest("Edit Test 1", TestCaseDave.TestCase1);
            Harness.RunTest("Edit Test 2", TestCaseDave.TestCase2);          
        
            // TODO : extract the process.start, and just expose a Harness.Process object.
            // Leaving this open to discussion.
        }
    }
}
