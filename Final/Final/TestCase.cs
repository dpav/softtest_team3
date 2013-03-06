using System;
using System.Diagnostics;
using System.IO;
using SoftTest402.TestAutomationFramework;

namespace SoftTest402.Team3
{
    class TestCase
    {
        public static void TestCase1()
        {
            TestDataReader dataReader = new TestDataReader();

            // Setup
            // Get a random file name and change the extension to txt and set the path to the desktop
            // make sure no previous versions of test file exist, then create the file with write privleges
            string testPbkFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Path.ChangeExtension(Path.GetRandomFileName(), "pbk"));
            
            if (File.Exists(testPbkFile))
            {
                File.Delete(testPbkFile);
            }

            FileStream fs = new FileStream(testPbkFile,
                FileMode.Create,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);

            Process np = new Process();
            np.StartInfo.FileName = "phonebk.exe";
            np.Start();

            System.Threading.Thread.Sleep(1000);

            IntPtr phonebookWindowHandle = NativeMethod.GetForegroundWindow();

            Helper.ClickMenuItem(phonebookWindowHandle,
                (int)PhonebookConstant.MainMenu.File,
                (int)PhonebookConstant.FileSubmenu.Open);

            System.Threading.Thread.Sleep(500);

            Helper.OpenFileFromCommonDialog(testPbkFile);

            System.Threading.Thread.Sleep(500);

            string[] testData = dataReader.CommaDelimitedTestDataReader("testdata.txt");

            int[] phoneControlIDs = new int[7] { 
                (int)PhonebookConstant.PhoneControlID.lastName,
                (int)PhonebookConstant.PhoneControlID.firstName,
                (int)PhonebookConstant.PhoneControlID.homePhone,
                (int)PhonebookConstant.PhoneControlID.workPhone,
                (int)PhonebookConstant.PhoneControlID.mobilePhone,
                (int)PhonebookConstant.PhoneControlID.email,
                (int)PhonebookConstant.PhoneControlID.homeAddress };


            foreach (string data in testData)
            {
                string[] dataElement = dataReader.CommaDelimitedTestDataParser(data);
                for (int i = 0; i < dataElement.Length; i++)
                {
                    Helper.SetTextboxText(
                       NativeMethod.GetDlgItem(phonebookWindowHandle, (int)phoneControlIDs[i]),
                       dataElement[i]);                    
                }
                PhoneHelper.ClickNextRecordMenuItem(phonebookWindowHandle);
            }

            // Close PB

            // Launch new instance of PB

            // Open pbk


        }
    }
}
