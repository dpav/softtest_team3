namespace SoftTest402.TeamTiga.FinalProject.HelperTED
{
    class TedNPadConstant
    {
        /// <summary>
        ///  String related Constants
        /// </summary>
        public const char minAsciiCharacter = '\u0020';
        public const char maxAsciiCharacter = '\u007E';
        public const int minStringLength = 1;
        public const int maxStringLength = 20;
        public const char maxUnicodeCharacter = '\uFFFE';

        /// <summary>
        ///  String related Constants
        /// </summary>       
        public int TedEditWindow = 0x3FC;
        public const int WAIT_FOR_INPUT_IDLE = 1000;
        public const int THREAD_SLEEP = 1000;
        public const int WAIT_FOR_EXIT = 1000;
        public const int WAIT_TIME = 500;

        /// <summary>
        ///  The ID of the Main Menu items
        /// </summary>
        public enum MainMenu : int
        {
            File = 0,
            Edit = 1,
            Search = 2,
            Tools = 3,
            Facourites = 4,
            Clips = 5,
            Options = 6,
            Help = 7
        }

        /// <summary>
        ///  The ID of the File Menu items
        /// </summary>
        public enum FileMenu : int
        {
            newFile = 0,
            open = 1,
            revert = 2,
            reOpen = 3,
            import = 4,
            include = 5,
            save = 7,
            saveAs = 8,
            export = 9,
            exclude = 10,
            encoding = 12,
            newLines = 13,
            properties = 14,
            pageSetUp = 16,
            print = 17,
            recentFiles = 19,
            hideToTray = 21,
            newWindow = 22,
            saveNExit = 24,
            exit = 25
        }

        /// <summary>
        ///  The ID of the Edit Menu items
        /// </summary>

        public enum EditSubMenu : int
        {
            Undo = 0,
            Redo = 1,
            Cut = 3,
            Copy = 4,
            Paste = 5,
            Swap = 6,
            Insert = 8,
            GoTo = 10,
            SelectWord = 11,
            SelectLine = 12,
            SelectParagraph = 13,
            SelectAll = 14,
            DeleteLine = 16,
            SmartReturn = 22
        }


        public enum EditInsertMenu : int
        {
            TimeDate = 6,
            Date = 10
        }

        /// <summary>
        ///  The ID of the Options Menu items
        /// </summary>
        public enum OptionsMenu : int
        {
            StatusBar = 0,
            LineNumbers = 2,
            VisibleNewline = 3,
            LineLength = 4,
            ZoomIn = 6,
            ZoomReset = 7,
            ZoomOut = 8,
            WordWrap = 10,
            WrapMargin = 11,
            FullScreen = 13,
            StayonTop = 14,
            SecondFont = 16,
            Settings = 18

        }
    }
}