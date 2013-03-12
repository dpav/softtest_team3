using System;
using System.Diagnostics;
using SoftTest402.TeamTiga.FinalProject.HelperCommon;
using SoftTest402.TeamTiga.FinalProject.HelperTED;

namespace SoftTest402.TeamTiga.FinalProject.TestCase
{
    internal class TestCaseEdit
    {
        /// <summary>
        /// This is to test insert Date of Edit feature is correct
        /// </summary>
        public static bool TestCase1(string tedNPath)
        {
            Console.WriteLine("Test 1");
            bool result = false;
            Process np = new Process();
            np.StartInfo.FileName = tedNPath;
            np.Start();

            System.Threading.Thread.Sleep(1000);
            IntPtr tedNPadWindowHandle = NativeMethod.GetForegroundWindow();

            string expectedDate = DateTime.Today.ToString("M/d/yyyy");
            TedNPadHelper.ClickInsertDateSubMenuItem(tedNPadWindowHandle);

            string tedNPadDate = Helper.GetTextFromEditWindow(tedNPadWindowHandle);

            Harness.Logger.LogResult(tedNPadDate, expectedDate);
            Console.WriteLine("Test Passed expected date is {0}, but TedNPad date is {1}", expectedDate, tedNPadDate);

            if (tedNPadDate == expectedDate)
            {
                result = true;
            }

            if (!np.HasExited)
            {
                np.CloseMainWindow();
                np.WaitForExit(TedNPadConstant.WAIT_FOR_EXIT);
                if (!np.HasExited)
                {
                    np.Kill();
                }
            }
            return result;
        }
        /// <summary>
        /// This is to test the Insert Date submenu from Insert Edit Menu
        /// </summary>
        /// <returns>returns true is test passed</returns>
        public static bool TestCase2()
        {

            // Local Process object to carry through the test
            bool result = false;

            Harness.Logger.LogComment("Opening Process");

            try
            {
                // start up the process
                //Process np = null;
                //np = Harness.CreateProcess();
                Process np = new Process();
                np.StartInfo.FileName = @"C:\Program Files (x86)\TED Notepad\TedNPad.exe";
                np.Start();

                System.Threading.Thread.Sleep(1000);

                try
                {
                    Harness.Logger.LogComment("I'm logging things in my test");

                    IntPtr tedNPadWindowHandle = NativeMethod.GetForegroundWindow();

                    string expectedDate = DateTime.Today.ToString("M/d/yyyy");
                    TedNPadHelper.ClickInsertDateSubMenuItem(tedNPadWindowHandle);

                    string tedNPadDate = Helper.GetTextFromEditWindow(tedNPadWindowHandle);

                    Harness.Logger.LogResult(tedNPadDate, expectedDate);
                    Console.WriteLine("Test Passed expected date is {0}, TedNPad date is {1}", expectedDate, tedNPadDate);

                    if (tedNPadDate == expectedDate)
                    {
                        result = true;
                    }
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

        /// <summary>
        /// This is to test the SelectAll, Cut, Paste and SmartReturn Edit menu items
        /// </summary>
        /// <returns>true if the test passes</returns>
        public static bool TestCase3()
        {
            // Local Process object to carry through the test
            bool result = false;

            Harness.Logger.LogComment("Opening Process");

            try
            {
                // start up the process
                //Process np = null;
                //np = Harness.CreateProcess();
                Process np = new Process();
                np.StartInfo.FileName = @"C:\Program Files (x86)\TED Notepad\TedNPad.exe";
                np.Start();

                System.Threading.Thread.Sleep(1000);

                try
                {
                    Harness.Logger.LogComment("I'm logging things in my test");

                    IntPtr tedNPadWindowHandle = NativeMethod.GetForegroundWindow();


                    string expectedDate = null;
                    for (int i = 0; i < 2; i++)
                    {
                        expectedDate = expectedDate+ DateTime.Today.ToString("M/d/yyyy")+"\r\n";
                        TedNPadHelper.ClickInsertDateSubMenuItem(tedNPadWindowHandle);
                        TedNPadHelper.ClickSmartReturnMenuItem(tedNPadWindowHandle);
                    }

                    TedNPadHelper.ClickEditSelectAllMenuItem(tedNPadWindowHandle);
                    TedNPadHelper.ClickEditCutMenuItem(tedNPadWindowHandle);
                    TedNPadHelper.ClickEditPasteMenuItem(tedNPadWindowHandle);
                    //TedNPadHelper.ClickSmartReturnMenuItem(tedNPadWindowHandle);
                    //TedNPadHelper.ClickEditPasteMenuItem(tedNPadWindowHandle);

                    string tedNPadDate = Helper.GetTextFromEditWindow(tedNPadWindowHandle);

                    Harness.Logger.LogResult(tedNPadDate, expectedDate);
                    Console.WriteLine("Test Passed expected date is {0}, TedNPad date is {1}", expectedDate,
                                             tedNPadDate);
                        
                    if (tedNPadDate == expectedDate)
                    {
                        result = true;
                    }
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
    }
}
