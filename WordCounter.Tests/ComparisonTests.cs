using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Security.Cryptography;

namespace WordCounter.Tests
{
    [TestClass]
    public class ComparisonTests
    {

        /// <summary>
        /// This doesn't work. Ran out of time to figure out exactly why.. 
        /// </summary>
        [TestMethod]
        public void TestFileOutPutIsAsExpected()
        {
            var dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            var filepath = string.Format("{0}\\Result{1}.txt", Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, dateTime);
            var result = FileParser.CountWords("harry potter page one.txt");
            FileSaver.SaveResults(filepath, result);

            Assert.AreEqual(GetHash(filepath),GetHash("HarryPotterResultToCompare.txt"));
        }
        
        /// <summary>
        /// https://stackoverflow.com/questions/10520048/calculate-md5-checksum-for-a-file/10520086#10520086
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private static byte[] GetHash(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }
    }

    
}
