using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCounter
{
    public static class FileParser
    {
        /// <summary>
        /// There are edge cases here which will mean "Harry's" or "it's" will not be handled correctly. 
        /// Some suitably complex regex required. Ran out of time.
        /// </summary>
        private static char[] punctuation = new char[]{' ','.',',',':',';','@','#','-','<','>','"','!','[',']','{','}','+','\'','\t','\n'};

        private static bool IsValidFilePath(string filePath)
        {
            if (File.Exists(filePath)) return true;
            return false;
        }

        /// <summary>
        /// Assuming case insensitivity. possible enhancement to make this a flag?
        /// Assuming numbers are valid words.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static SortedDictionary<string, int> CountWords(string filePath)
        {
            SortedDictionary<string, int> result = new SortedDictionary<string, int>(StringComparer.OrdinalIgnoreCase); 
            if (!IsValidFilePath(filePath)) throw new FileNotFoundException("The file at the specifcied path does not exist. Please check it is correct");

            using(var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    foreach(var word in line.Split(punctuation).Where(x => !string.IsNullOrWhiteSpace(x)))
                    {
                        if(result.ContainsKey(word))
                        { 
                            result[word]++;
                        } 
                        else
                        {
                            result.Add(word, 1);                        
                        }
                    }                    
                }
            }
                        
            return result;
        }

    }
}
