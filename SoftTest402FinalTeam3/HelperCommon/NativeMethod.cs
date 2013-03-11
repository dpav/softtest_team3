using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SoftTest402.TeamTiga.FinalProject.HelperCommon
{
    class NativeMethod
    {
        /// <summary>
        /// Gets the handle to the top most main (parent) window in the z-order
        /// </summary>
        /// <returns>
        /// The return value is a handle to the foreground window.
        /// </returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        /// <summary>
        /// Sets focus to a main (parent) window and brings it to the top of 
        /// the z-order
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the window that should be
        /// activated and brought to the foreground.</param>
        /// <returns>If the window was brought to the foreground, the return
        /// value is nonzero. If the window was not brought to the foreground,
        /// the return value is zero.</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr SetForegroundWindow
            (IntPtr hWndMainWindow);

        /// <summary>
        /// Retrieves a handle to a window that has the specified relationship
        /// (Z-Order or owner) to the specified window
        /// </summary>
        /// <param name="hWndMainWindow">Handle to a window</param>
        /// <param name="windowType">the relationship between the specified
        /// window and the window whose handle is to be retrieved</param>
        /// <returns>If the function succeeds, the return value is a window
        /// handle. If no window exists with the specified relationship to the
        /// specified window, the return value is NULL</returns>
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindow
            (IntPtr hWndMainWindow, uint windowType);

        // Gets the handle to a control on a dialog
        /// <summary>
        /// retrieves a handle to a control in the specified dialog box
        /// </summary>
        /// <param name="hWndDialog">Handle to the dialog box that contains the
        /// control</param>
        /// <param name="controlID">Specifies the identifier of the control to
        /// be retrieved</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetDlgItem
            (IntPtr hWndDialog, int controlID);

        /// <summary>
        /// Sends the specified message to a window and does not return until
        /// the window procedure has processed the message
        /// </summary>
        /// <param name="hWnd">Handle to the window whose window procedure will
        /// receive the message</param>
        /// <param name="windowMessage">Specifies the message to be sent</param>
        /// <param name="wParam">Specifies additional message-specific 
        /// information</param>
        /// <param name="lParam">Specifies additional message-specific 
        /// information</param>
        /// <returns>Windows Vista and later. When a message is blocked by UIPI
        /// the last error, retrieved with GetLastError, is set to 5 (access
        /// denied).</returns>
        /// 
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage
            (IntPtr hWnd, uint windowMessage, IntPtr wParam, IntPtr lParam);


        // For getting text from textbox
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage
            (IntPtr hWnd, uint windowMessage, IntPtr wParam, [Out] StringBuilder lparam);


        /// <summary>
        /// Aliased overload of SendMessage to set text to a textbox control.
        /// </summary>
        /// <param name="hWndTextbox">Handle to the textbox</param>
        /// <param name="windowMessage">Use Constant.WM_SETTEXT for the
        /// windowMessage</param>
        /// <param name="wParam">Set to IntPtr.Zero</param>
        /// <param name="text">Type string variable</param>
        /// <returns>Windows Vista and later. When a message is blocked by UIPI
        /// the last error, retrieved with GetLastError, is set to 5 (access
        /// denied).</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SetTextToTextbox
            (IntPtr hWndTextbox, uint windowMessage, IntPtr wParam, string text);

        /// <summary>
        /// Aliased overload of SendMessage to set text to a textbox control.
        /// </summary>
        /// <param name="hWndTextbox">Use Constant.WM_SETTEXT for the 
        /// windowMessage</param>
        /// <param name="windowMessage">Use Constant.WM_SETTEXT for the 
        /// windowMessage</param>
        /// <param name="wParam">Set to IntPtr.Zero</param>
        /// <param name="text">StringBuilder object</param>
        /// <returns>Windows Vista and later. When a message is blocked by UIPI
        /// the last error, retrieved with GetLastError, is set to 5 (access
        /// denied).</returns>
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SetTextToTextBox
            (IntPtr hWndTextbox, uint windowMessage, IntPtr wParam, StringBuilder text);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr GetTextFromTextBox
            (IntPtr hWndTextbox, uint windowMessage, IntPtr wParam, IntPtr Buffer);

        /// <summary>
        /// sends the specified message to a window and returns immediately; it
        /// does not wait for the window procedure to finish processing the
        /// message
        /// </summary>
        /// <param name="hWnd">Handle to the window whose window procedure will
        /// receive the message</param>
        /// <param name="msg">Specifies the message to be sent</param>
        /// <param name="wParam">Specifies additional message-specific 
        /// information.</param>
        /// <param name="lParam">Specifies additional message-specific 
        /// information.</param>
        /// <returns></returns>
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SendNotifyMessage
            (IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Aliased overload of SendNotifyMessage for setting a checkbox state.
        /// </summary>
        /// <param name="hWndControl">Handle to the checkbox or radio button
        /// control</param>
        /// <param name="buttonMessage">Use Constant.BM_SETCHECK as the 
        /// buttonMessage</param>
        /// <param name="checkStateMessage">Use Constant.BST_CHECKED or 
        /// Constant.BST_UNCHECK as the checkStateMessage</param>
        /// <param name="lParam">IntPtr.Zero</param>
        /// <returns>If the function succeeds, the return value is nonzero.If
        /// the function fails, the return value is zero. To get extended error
        /// information, call GetLastError.</returns>
        [DllImport("user32.dll", EntryPoint = "SendNotifyMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetCheckBoxState
            (IntPtr hWndControl, uint buttonMessage, uint checkStateMessage, IntPtr lParam);

        /// <summary>
        /// Aliased overload of SendNotifyMessage for clicking a button control.
        /// </summary>
        /// <param name="hWndControl">Handle to the button control</param>
        /// <param name="buttonMessage">Use Constant.BM_CLICK as the 
        /// buttonMessage</param>
        /// <param name="wParam">IntPtr.Zero</param>
        /// <param name="lParam">IntPtr.Zero</param>
        /// <returns>If the function succeeds, the return value is nonzero.If
        /// the function fails, the return value is zero. To get extended error
        /// information, call GetLastError.</returns>
        [DllImport("user32.dll", EntryPoint = "SendNotifyMessage", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ClickButton
            (IntPtr hWndButton, uint buttonMessage, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Aliased overload of SendNotifyMessage for clicking a menu item.
        /// </summary>
        /// <param name="hWndControl">Handle to the menu</param>
        /// <param name="buttonMessage">Use Constant.WM_COMMAND as the 
        /// menuMessage</param>
        /// <param name="wParam">uint type returned from GetMenuItemID</param>
        /// <param name="lParam">IntPtr.Zero</param>
        /// <returns>If the function succeeds, the return value is nonzero.If 
        /// the function fails, the return value is zero. To get extended error
        /// information, call GetLastError.</returns>
        [DllImport("user32.dll", EntryPoint = "SendNotifyMessage", SetLastError = true)]
        public static extern bool ClickMenuItem
            (IntPtr hWndSubMenu, uint menuMessage, uint menuItemID, IntPtr lParam);

        /// <summary>
        /// retrieves a handle to the menu assigned to the specified window
        /// </summary>
        /// <param name="hWndMainWindow">Handle to the window whose menu handle
        /// is to be retrieved</param>
        /// <returns>handle to the menu. If the specified window has no menu,
        /// the return value is NULL. If the window is a child window, the 
        /// return value is undefined</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWndMainWindow);

        /// <summary>
        /// retrieves a handle to the drop-down menu or submenu activated by 
        /// the specified menu item
        /// </summary>
        /// <param name="hWndMenu">Handle to the menu</param>
        /// <param name="menuPosition">Specifies the zero-based relative 
        /// position in the specified menu of an item that activates a 
        /// drop-down menu or submenu</param>
        /// <returns>If the function succeeds, the return value is a handle to
        /// the drop-down menu or submenu activated by the menu item. If the
        /// menu item does not activate a drop-down menu or submenu, the return
        /// value is NULL</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr GetSubMenu
            (IntPtr hWndMenu, int menuPosition);

        /// <summary>
        /// retrieves the menu item identifier of a menu item located at the
        /// specified position in a menu
        /// </summary>
        /// <param name="hWndSubMenu">Handle to the menu that contains the item
        /// whose identifier is to be retrieved</param>
        /// <param name="menuItemPosition">Specifies the zero-based relative 
        /// position of the menu item whose identifier is to be retrieved</param>
        /// <returns>The return value is the identifier of the specified menu 
        /// item. If the menu item identifier is NULL or if the specified item 
        /// opens a submenu, the return value is -1.</returns>
        [DllImport("user32.dll")]
        public static extern uint GetMenuItemID
            (IntPtr hWndSubMenu, int menuItemPosition);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);


        public struct RECT
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll", SetLastError = false)]
        public static extern IntPtr GetDesktopWindow();
    }
}
