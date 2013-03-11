using System;
using System.Diagnostics;
using System.Collections;
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
            bool SB_VisibleStart;
            bool SB_Visible;
            long style = 0;
            ArrayList Errorlist = new ArrayList();

            Harness.Logger.LogComment("Opening Process");
            try
            {
                // start up the process
                Process np = null;
                np = Harness.CreateProcess();

                try
                {
                    System.Threading.Thread.Sleep(1000);
                    //Get the main window handle.
                    IntPtr TEDHandle = NativeMethod.GetForegroundWindow();
                    System.Threading.Thread.Sleep(500);
                    
                    //Get the Status Bar Handle window.
                    IntPtr hControl = NativeMethod.FindWindowEx(TEDHandle, IntPtr.Zero, "msctls_statusbar32", null);
                    
                    //Get the window style.
                    style = NativeMethod.GetWindowLong(hControl, HelperCommon.User32Constant.GWL_STYLE);
                    
                    //Record the starting state of the status bar
                    SB_VisibleStart = ((style & (long)HelperCommon.User32Constant.Style.WS_VISIBLE)
                        == (long)HelperCommon.User32Constant.Style.WS_VISIBLE);

                    //Toggle the visibility
                    Helper.ClickMenuItem(TEDHandle, (int)HelperTED.TedNPadConstant.MainMenu.Options,
                        (int)HelperTED.TedNPadConstant.OptionsMenu.StatusBar);

                    System.Threading.Thread.Sleep(500);

                    //Get the window style.
                    style = NativeMethod.GetWindowLong(hControl, HelperCommon.User32Constant.GWL_STYLE);
                    
                    //Check if the window is visible.
                    SB_Visible = ((style & (long)HelperCommon.User32Constant.Style.WS_VISIBLE)
                        == (long)HelperCommon.User32Constant.Style.WS_VISIBLE);

                    //Verify the visibility changed
                    if (SB_Visible == SB_VisibleStart)
                    {
                        Errorlist.Add("Visibility change 1 not processed.");
                    }

                    System.Threading.Thread.Sleep(500);

                    //Toggle the visibility
                    Helper.ClickMenuItem(TEDHandle, (int)HelperTED.TedNPadConstant.MainMenu.Options,
                        (int)HelperTED.TedNPadConstant.OptionsMenu.StatusBar);

                    System.Threading.Thread.Sleep(500);

                    //Get the window style.
                    style = NativeMethod.GetWindowLong(hControl, HelperCommon.User32Constant.GWL_STYLE);

                    //Check if the window is visible.
                    SB_Visible = ((style & (long)HelperCommon.User32Constant.Style.WS_VISIBLE)
                        == (long)HelperCommon.User32Constant.Style.WS_VISIBLE);

                    //Verify the visibility changed
                    if (SB_Visible != SB_VisibleStart)
                    {
                        Errorlist.Add("Visibility change 2 not processed.");
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

            return (Errorlist.Count == 0);
        }

        public static bool TestCase3()
        {
            bool StyleNoBorder;
            bool StyleIsMaximized;
            long style = 0;

            ArrayList Errorlist = new ArrayList();

            Harness.Logger.LogComment("Opening Process");
            try
            {
                // start up the process
                Process np = null;
                np = Harness.CreateProcess();

                try
                {
                    NativeMethod.RECT TED_Rect;
                    NativeMethod.RECT Desktop_Rect;

                    System.Threading.Thread.Sleep(1000);
                    IntPtr TEDHandle = NativeMethod.GetForegroundWindow();
                    System.Threading.Thread.Sleep(500);

                    //Harness.Logger.LogComment("I'm logging things in my test");

                    Helper.ClickMenuItem(TEDHandle, (int)HelperTED.TedNPadConstant.MainMenu.Options,
                        (int)HelperTED.TedNPadConstant.OptionsMenu.FullScreen);

                    System.Threading.Thread.Sleep(1000);

                    style = NativeMethod.GetWindowLong(TEDHandle, HelperCommon.User32Constant.GWL_STYLE);
                    //Check if the window is visible.

                    StyleIsMaximized = ((style & (long)HelperCommon.User32Constant.Style.WS_MAXIMIZE)
                        == (long)HelperCommon.User32Constant.Style.WS_MAXIMIZE);
                    StyleNoBorder = ((style & (long)HelperCommon.User32Constant.Style.WS_BORDER)
                        != (long)HelperCommon.User32Constant.Style.WS_BORDER);

                    if (StyleIsMaximized & StyleNoBorder)
                    {
                        //Style settings are correct.  Check screen Resolution
                        if (!NativeMethod.GetWindowRect(TEDHandle, out TED_Rect))
                        {
                            Errorlist.Add("Unable to get window dimension.");
                        }
                        if (!NativeMethod.GetWindowRect(NativeMethod.GetDesktopWindow(), out Desktop_Rect))
                        {
                            Errorlist.Add("Unable to get desktop dimension.");
                        }

                        if (Desktop_Rect.Top != TED_Rect.Top ||
                            Desktop_Rect.Left != TED_Rect.Left ||
                            Desktop_Rect.Right != TED_Rect.Right ||
                            Desktop_Rect.Bottom != TED_Rect.Bottom)
                        {
                            Errorlist.Add("Window dimensions do not match.");
                        }
                    }
                    else
                    {
                        Errorlist.Add("Window does not have Maximized flag set.");
                    }

                    System.Threading.Thread.Sleep(500);

                    Helper.ClickMenuItem(TEDHandle, (int)HelperTED.TedNPadConstant.MainMenu.Options,
                        (int)HelperTED.TedNPadConstant.OptionsMenu.FullScreen);

                    System.Threading.Thread.Sleep(1000);

                    //refresh the style

                    style = NativeMethod.GetWindowLong(TEDHandle, HelperCommon.User32Constant.GWL_STYLE);
                    StyleIsMaximized = ((style & (long)HelperCommon.User32Constant.Style.WS_MAXIMIZE)
                        == (long)HelperCommon.User32Constant.Style.WS_MAXIMIZE);
                    StyleNoBorder = ((style & (long)HelperCommon.User32Constant.Style.WS_BORDER)
                        != (long)HelperCommon.User32Constant.Style.WS_BORDER);

                    if (StyleIsMaximized || StyleNoBorder)
                    {
                        Errorlist.Add("Window still has full-screen related flags set.");
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

            return (Errorlist.Count == 0);
        }
    }
}
