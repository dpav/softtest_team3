using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SoftTest402.TestAutomationFramework;

namespace SoftTest402.TeamTiga.FinalProject
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
            Process np = null;
            bool result = false;

            Harness.Logger.LogComment("Opening Process");

            try
            {
                // start up the process
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
