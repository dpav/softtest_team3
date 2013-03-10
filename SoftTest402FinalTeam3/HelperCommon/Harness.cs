using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SoftTest402.TestAutomationFramework;

namespace SoftTest402.TeamTiga.FinalProject
{
    public static class Harness
    {
        private static bool _Initiaized = false;

        public static TestAutomationFramework.Logger Logger { get; private set; }

        public static string ProgramPath { get; private set; }
        public static string TestName { get; private set; }

        public static void Initialize(string ExePath, string LogName)
        {
            ProgramPath = ExePath;
            _Initiaized = true;
            Logger = new TestAutomationFramework.Logger(LogName);
        }

        /// <summary>
        /// Method that executes a test case.
        /// </summary>
        /// <param name="TestName">String, friendly name of the test that will appear in the log</param>
        /// <param name="RunTestMethod">The fully qualified name of the test methof to run.
        /// Do not append ().</param>
        /// <returns>No return value.</returns>
        public static void RunTest(string TestName, Func<bool> RunTestMethod)
        {
            bool TestPassResult = false;
            if (!_Initiaized)
            {
                // We should throw an exception.  Or we can just return...
                throw new Exception("Not Initialized.  Call Initialize() first)");
                //return 
            }
            try
            {
                Logger.LogTestStart(TestName);
                TestPassResult = RunTestMethod();
                Logger.LogTestComplete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running test : {0}", ex.Message);
            }
        }

        public static Process CreateProcess()
        {
            Process process = null;

            if (!_Initiaized)
            {
                // We should throw an exception.  Or we can just return...
                throw new Exception("Not Initialized.  Call Initialize() first)");
                //return 
            }
            try
            {
                process = new Process();
                process.StartInfo.FileName = ProgramPath;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running test : {0}", ex.Message);
            }
            return process;

        }

        public static void TerminateProcess(Process process)
        {
            if (!_Initiaized)
            {
                // We should throw an exception.  Or we can just return...
                throw new Exception("Not Initialized.  Call Initialize() first)");
                //return 
            }
            try
            {
                process.CloseMainWindow();
                process.WaitForExit(TedNPadConstant.WAIT_FOR_EXIT);
                if (!process.HasExited)
                {
                    process.Kill();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error running test : {0}", ex.Message);
            }
        }
    }
}
