using System;
using System.Diagnostics;
using SoftTest402.TeamTiga.FinalProject.HelperCommon;

namespace SoftTest402.TeamTiga.FinalProject.TestCase
{
    internal class TestCaseDave
    {
        /// <summary>
        /// TODO
        /// </summary>
        public static bool TestCase1()
        {
            // TODO : lots of logic

            // Local Process object to carry through the test
            bool result = false;

            Harness.Logger.LogComment("Opening Process");

            try
            {
                // start up the process
                Process np = null;
                np = Harness.CreateProcess();

                try
                {
                    Harness.Logger.LogComment("I'm logging things in my test");

                    // TODO : test logic
                    //result = Oracle_Dave.Oracle();              
                    //Harness.Logger.LogResult();
                }
                catch (Exception ex)
                {
                    Harness.Logger.LogComment(System.String.Format("Error : {0}", ex));
                }
                finally
                {
                    // close the process, even if there's an exception
                    Harness.TerminateProcess(np);
                }
            }
            catch (Exception ex)
            {
                Harness.Logger.LogComment(System.String.Format("Error starting process : {0}", ex));
            }

            // return what our oracle says. Boolean pass/fail.
            return result;
        }

        public static bool TestCase2()
        {
            return false;
        }
    }
}
