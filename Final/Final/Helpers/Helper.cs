using System;
using System.Text;

namespace SoftTest402.Team3
{
    class Helper
    {
        /// <summary>
        /// Method to Click a sub-menu item
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the AUT main window</param>
        /// <param name="menuPosition">0-based ordinal value of the main menu item</param>
        /// <param name="subMenuItemPosition">0-based ordinal value of the sub-menu item</param>
        /// <returns>True if message sent; otherwise false</returns>
        public static bool ClickMenuItem(
            IntPtr hWndMainWindow, int menuPosition, int subMenuItemPosition)
        {
            // Get the handle to the main menu
            IntPtr hWndMain = NativeMethod.GetMenu(hWndMainWindow);
            // Get the handle to the sub menu
            IntPtr hWndSubMenu =
                NativeMethod.GetSubMenu(hWndMain, menuPosition);
            // Get the sub-menu item ID
            uint menuItemID =
                NativeMethod.GetMenuItemID(hWndSubMenu, subMenuItemPosition);
            // Call an aliased SendNotifyMessage
            return NativeMethod.ClickMenuItem(
                hWndMainWindow,
                (uint)User32Constant.WindowMessage.WM_COMMAND,
                menuItemID,
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




    }
}
