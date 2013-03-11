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

            Harness.RunTest("Option Test 3", TestCaseDave.TestCase1);
            //Harness.RunTest("Option Test 3", TestCaseDave.TestCase3);
            //Harness.RunTest("Option Test 2", TestCaseDave.TestCase2);          
        
            // TODO : extract the process.start, and just expose a Harness.Process object.
            // Leaving this open to discussion.
        }
    }
}
