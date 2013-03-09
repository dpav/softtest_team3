using System;
using System.Text;
using System.IO;
using TestingMentor.TestTool.Babel;

namespace SoftTest402.TeamTiga.FinalProject
{
    class DataReader
    {
        public string[] GetCommaDelimitedTestData(string dataFile)
        {
            return File.ReadAllLines(dataFile);
        }

        private static string GetRandomASCIISequenceFromBabel(int seedValue)
        {
            StringGenerator sg = new StringGenerator();
            sg.Info.Seed = seedValue;
            sg.Info.IsSendKeysSafe = true;
            sg.Info.MaximumCharacterCount = 50;
            sg.Info.RandomizeCharacterCount = false;
            sg.Info.InjectSpecialCharacter = (int)StringGenerator.SpecialCharacter.SurrogatePairCharacter;
            sg.Info.SpecialCharacterPosition = (int)StringGenerator.CharacterPosition.Random;

            string testData = sg.Polyglot();

            return testData;
        }

        private static string GetRandomASCIISequence()
        {
            Random rand = new Random();
            int length = rand.Next(TedNPadConstant.minStringLength, TedNPadConstant.maxStringLength + 1);
            StringBuilder sb = new StringBuilder();
            
            while (sb.Length < length)
            {
                sb.Append(Convert.ToChar(rand.Next(
                    Convert.ToInt32(TedNPadConstant.minAsciiCharacter),
                    Convert.ToInt32(TedNPadConstant.maxUnicodeCharacter) + 1)));
            }

            return sb.ToString();
        }
    }
}
