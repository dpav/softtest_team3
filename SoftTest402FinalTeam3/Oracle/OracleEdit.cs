using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftTest402.TeamTiga.FinalProject.HelperCommon;

namespace SoftTest402.TeamTiga.FinalProject.Oracle
{
    public class OracleEdit
    {
        public static bool EditTc2(string tedNPadDate, string expectedDate)
        {
            bool result = false;
            Harness.Logger.LogResult(tedNPadDate, expectedDate);
            Console.WriteLine("Test Passed expected date is {0}, TedNPad date is {1}", expectedDate, tedNPadDate);
            if (tedNPadDate == expectedDate)
            {
                result = true;
            }
            return result;
        }

    }
}
