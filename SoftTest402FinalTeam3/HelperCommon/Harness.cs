using System;
using System.Diagnostics;
using SoftTest402.TeamTiga.FinalProject.HelperTED;

namespace SoftTest402.TeamTiga.FinalProject.HelperCommon
{
    public static class Harness
    {
        private static bool _initiaized = false;

        public static TestAutomationFramework.Logger Logger { get; private set; }

        public static string ProgramPath { get; private set; }
        public static string TestName { get; private set; }

        public static void Initialize(string exePath, string logName)
        {
            ProgramPath = exePath;
            _initiaized = true;
            Logger = new TestAutomationFramework.Logger(logName);
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
            if (!_initiaized)
            {
                // We should throw an exception.  Or we can just return...
                throw new Exception("Not Initialized.  Call Initialize() first)");
                //return 
            }
            try
            {
                Logger.LogTestStart(TestName);
                TestPassResult = RunTestMethod();
                Logger.LogResult(TestPassResult, true);
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

            if (!_initiaized)
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
            if (!_initiaized)
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
