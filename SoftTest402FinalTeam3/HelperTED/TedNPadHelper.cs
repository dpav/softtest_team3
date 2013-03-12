using System;
using SoftTest402.TeamTiga.FinalProject.HelperCommon;

namespace SoftTest402.TeamTiga.FinalProject.HelperTED
{
    class TedNPadHelper
    {
        public static void ClickEditSelectAllMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)TedNPadConstant.MainMenu.Edit,
                (int)TedNPadConstant.EditSubMenu.SelectAll);
        }

        public static void ClickEditCopyMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)TedNPadConstant.MainMenu.Edit,
                (int)TedNPadConstant.EditSubMenu.Copy);
        }

        public static void ClickEditPasteMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)TedNPadConstant.MainMenu.Edit,
                (int)TedNPadConstant.EditSubMenu.Paste);
        }
        public static void ClickEditCutMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)TedNPadConstant.MainMenu.Edit,
                (int)TedNPadConstant.EditSubMenu.Cut);
        }

        public static void ClickSmartReturnMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickMenuItem(
                mainWindowHandle,
                (int)TedNPadConstant.MainMenu.Edit,
                (int)TedNPadConstant.EditSubMenu.SmartReturn);
        }

        public static void ClickInsertTimeDateSubMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickSubMenuItem(mainWindowHandle,
                                 (int)TedNPadConstant.MainMenu.Edit,
                                 (int)TedNPadConstant.EditSubMenu.Insert,
                                 (int)TedNPadConstant.EditInsertMenu.TimeDate);
        }

        public static void ClickInsertDateSubMenuItem(IntPtr mainWindowHandle)
        {
            Helper.ClickSubMenuItem(mainWindowHandle,
                                 (int)TedNPadConstant.MainMenu.Edit,
                                 (int)TedNPadConstant.EditSubMenu.Insert,
                                 (int)TedNPadConstant.EditInsertMenu.Date);
        }
    }
}
