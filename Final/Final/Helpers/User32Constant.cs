
namespace SoftTest402.Team3
{
    class User32Constant
    {
        public enum GetWindowType : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }

        public enum WindowMessage : uint
        {
            WM_SETFOCUS = 0x0007,      // Set focus
            WM_SETTEXT = 0x000C,      // Set text to a textbox
            WM_GETTEXT = 0x000D,
            WM_GETTEXTLENGTH = 0x000E,
            WM_COMMAND = 0x0111          // Simulate clicking a menu item
        }

        public enum ButtonMessage : uint
        {
            BM_SETCHECK = 0x00F1,  // set radio or checkbox button state
            BST_UNCHECKED = 0x0000,
            BST_CHECKED = 0x0001,
            BM_CLICK = 0x00F5    // click button
        }
    }
}
