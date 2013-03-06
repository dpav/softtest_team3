using System;

namespace SoftTest402.Team3
{
    class PhoneHelper
    {
        public static void ClickNextRecordMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)PhonebookConstant.MainMenu.Record,
                (int)PhonebookConstant.RecordSubmenu.Next);
        }

        public static void ClickPreviousRecordMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)PhonebookConstant.MainMenu.Record,
                (int)PhonebookConstant.RecordSubmenu.Previous);
        }
    }
}
