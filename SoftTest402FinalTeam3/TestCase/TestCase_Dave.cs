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
            bool result = false;
            Harness.Logger.LogComment("Opening Process");
         
            Process np = new Process();

            try
            {
                // start up the process
                np.StartInfo.FileName = Harness.ProgramPath;
                np.Start();

                Harness.Logger.LogComment("I'm logging things in my test");


                // TODO :logic
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
                if (!np.HasExited)
                {
                    np.CloseMainWindow();
                    np.WaitForExit(TedNPadConstant.WAIT_FOR_EXIT);
                    if (!np.HasExited)
                    {
                        np.Kill();
                    }
                }            
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
