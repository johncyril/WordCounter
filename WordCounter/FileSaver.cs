using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WordCounter
{
    public static class FileSaver
    {
        /// <summary>
        /// saving results in lower case as spec is clear about being able to compare results from different runs. 
        /// We are assumuing case insensitivity in our word count.
        /// Results also should be sorted by key. This is why we have a sorted dictionary.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="results"></param>
        public static void SaveResults(string fileName, SortedDictionary<string,int> results)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach(var word in results.Keys)
                {
                    writer.WriteLine(string.Format("{0}:{1}", word.ToLower(), results[word]));
                }
            }
        }
    }
}
