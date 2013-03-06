
namespace SoftTest402.Team3
{
    class PhonebookConstant
    {
        public enum PhoneControlID: int
        {
            firstName = 0x0007,
            lastName = 0x0008,
            homePhone = 0x0006,
            workPhone = 0x0005,
            mobilePhone = 0x0004,
            email = 0x0003,
            homeAddress = 0x0002,
        }

        public enum MainMenu: int
        {
            File = 0,
            Edit = 1,
            Record = 2,
            Help = 3
        }
        /// <summary>
        /// The index of the file submenu labels
        /// </summary>
        public enum FileSubmenu: int
        {
            New = 0,
            Open = 1,
            SaveAs = 3,
            Print = 4,
            Exit = 6
        }
        /// <summary>
        /// The index of the edit submenu labels
        /// </summary>
        public enum EditSubmenu: int
        {
            Clear = 0,
            Delete = 1,
            Find = 2
        }
        /// <summary>
        /// The index of the record submenu labels
        /// </summary>
        public enum RecordSubmenu: int
        {
            Next = 0,
            Previous = 1
        }
        /// <summary>
        /// The index of the help submenu labels
        /// </summary>
        public enum HelpSubmenu: int
        {
            Help = 0
        }
    }
}
