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
    internal class TestCaseEdit
    {
        /// <summary>
        /// This is to test insert Date of Edit feature is correct
        /// </summary>
        public static void TestCase1(string tedpath)
        {

            Process np = new Process();
            np.StartInfo.FileName = tedpath;
            np.Start();

            System.Threading.Thread.Sleep(1000);
            IntPtr tedNPadWindowHandle = NativeMethod.GetForegroundWindow();

            string expectedDate = DateTime.Today.ToString("M/d/yyyy");
            TedNPadHelper.ClickInsertDateSubMenuItem(tedNPadWindowHandle);

            string tedNPadDate = Helper.GetTextFromEditWindow(tedNPadWindowHandle);

            Console.WriteLine(
                tedNPadDate != expectedDate
                    ? "Test Failed expected date is {0}, but TedNPad date is {1}"
                    : "Test Passed expected date is {0}, but TedNPad date is {1}", expectedDate, tedNPadDate);

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

        public static void TestCase2(string tedpath)
        {
            Process np = new Process();
            np.StartInfo.FileName = tedpath;
            np.Start();

            System.Threading.Thread.Sleep(1000);
            IntPtr tedNPadWindowHandle = NativeMethod.GetForegroundWindow();


            TedNPadHelper.ClickEditSelectAllMenuItem(tedNPadWindowHandle);
            TedNPadHelper.ClickEditCopyMenuItem(tedNPadWindowHandle);
            TedNPadHelper.ClickEditPasteMenuItem(tedNPadWindowHandle);
            TedNPadHelper.ClickSmartReturnMenuItem(tedNPadWindowHandle);
            TedNPadHelper.ClickEditPasteMenuItem(tedNPadWindowHandle);
        }
    }
}
