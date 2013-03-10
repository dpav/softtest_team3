using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftTest402.TeamTiga.FinalProject
{
    class Helper
    {/// <summary>
        /// Method to Click a sub-menu item
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the AUT main window</param>
        /// <param name="menuPosition">0-based ordinal value of the main menu item</param>
        /// <param name="subMenuItemPosition">0-based ordinal value of the sub-menu item</param>
        /// <returns>True if message sent; otherwise false</returns>
        public static bool ClickMenuItem(IntPtr hWndMainWindow, int menuPosition, int subMenuItemPosition)
        {
            // Get the handle to the main menu
            IntPtr hWndMain = NativeMethod.GetMenu(hWndMainWindow);
            // Get the handle to the sub menu
            IntPtr hWndSubMenu =
                NativeMethod.GetSubMenu(hWndMain, menuPosition);
            //System.Threading.Thread.Sleep(1000);
            // Get the sub-menu item ID
            uint menuItemId =
                NativeMethod.GetMenuItemID(hWndSubMenu, subMenuItemPosition);
            // Call an aliased SendNotifyMessage
            return NativeMethod.ClickMenuItem(
                hWndMainWindow,
                (uint)User32Constant.WindowMessage.WM_COMMAND,
                menuItemId,
                IntPtr.Zero);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hWndMainWindow"></param>
        /// <param name="menuPosition"></param>
        /// <param name="subMenuPosition"></param>
        /// <param name="subMenuItemPosition"></param>
        /// <returns></returns>
        public static bool ClickSubMenuItem(
            IntPtr hWndMainWindow, int menuPosition, int subMenuPosition, int subMenuItemPosition)
        {
            // Get the handle to the main menu
            IntPtr hWndMain = NativeMethod.GetMenu(hWndMainWindow);
            // Get the handle to the sub menu
            IntPtr hWndSubMenu =
                NativeMethod.GetSubMenu(hWndMain, menuPosition);
            // Get the handle to a menu of a sub menu
            IntPtr hWndMenuOfSubMenu =
                NativeMethod.GetSubMenu(hWndSubMenu, subMenuPosition);
            uint popupSubMenuItemId =
               NativeMethod.GetMenuItemID(hWndMenuOfSubMenu, subMenuItemPosition);
            // Call an aliased SendNotifyMessage
            return NativeMethod.ClickMenuItem(
                hWndMainWindow,
                (uint)User32Constant.WindowMessage.WM_COMMAND,
                popupSubMenuItemId,
                IntPtr.Zero);
        }
        public static void ClickButton(IntPtr buttonHandle)
        {
            NativeMethod.ClickButton(
                buttonHandle,
                (uint)User32Constant.ButtonMessage.BM_CLICK,
                IntPtr.Zero,
                IntPtr.Zero);
        }

        public static void SetTextboxText(IntPtr textboxHandle, string text)
        {
            NativeMethod.SetTextToTextbox(
                textboxHandle,
                (int)User32Constant.WindowMessage.WM_SETTEXT,
                IntPtr.Zero,
                text);
        }

        public static string GetTextboxText(IntPtr textboxHandle)
        {
            int length = (int)NativeMethod.SendMessage(
                textboxHandle,
                (uint)User32Constant.WindowMessage.WM_GETTEXTLENGTH,
                IntPtr.Zero,
                IntPtr.Zero);
            StringBuilder textboxText = new StringBuilder(length + 1);
            NativeMethod.SendMessage(
                textboxHandle,
                (uint)User32Constant.WindowMessage.WM_GETTEXT,
                (IntPtr)textboxText.Capacity,
                textboxText);
            return textboxText.ToString();
        }

        public static void OpenFileFromCommonDialog(string filename)
        {
            IntPtr saveDialogHandle = NativeMethod.FindWindow("#32770", "Open");
            IntPtr myHandle = saveDialogHandle;
            string[] classNameGroup = new string[] { "ComboBoxEx32", "ComboBox", "Edit" };
            foreach (string className in classNameGroup)
            {
                myHandle = NativeMethod.FindWindowEx(myHandle, IntPtr.Zero, className, String.Empty);
                if (myHandle == IntPtr.Zero)
                {
                    throw new ArgumentNullException();
                }
            }
            NativeMethod.SetTextToTextbox(myHandle, (uint)User32Constant.WindowMessage.WM_SETTEXT, IntPtr.Zero, filename);
            IntPtr openButton = NativeMethod.GetDlgItem(saveDialogHandle, (int)0x1);
            ClickButton(openButton);
        }

        public static string GetTextFromEditWindow(IntPtr mainWindow)
        {
            IntPtr editWindow =
            NativeMethod.FindWindowEx(
                mainWindow,
                IntPtr.Zero,
                "TedEditW",
                null);
            int length = (int)NativeMethod.SendMessage(
                editWindow,
                (uint)User32Constant.WindowMessage.WM_GETTEXTLENGTH,
                IntPtr.Zero,
                IntPtr.Zero);
            StringBuilder textboxText = new StringBuilder(length + 1);
            NativeMethod.SendMessage(
                editWindow,
                (uint)User32Constant.WindowMessage.WM_GETTEXT,
                (IntPtr)textboxText.Capacity,
                textboxText);
            return textboxText.ToString();
        }
    }
}
