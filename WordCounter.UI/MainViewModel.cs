using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordCounter;

namespace WordCounter.UI
{
    class MainViewModel : INotifyPropertyChanged
    {
        private SortedDictionary<string, int> results = new SortedDictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        private string _fileToLoad;
        private string _resultSummary;

        public string FileToLoad
        {
            get{return _fileToLoad;}           
            set { _fileToLoad = value; RaisePropertyChanged("FileToLoad"); }
        }
                
        public string ResultSummary
        {
            get { return _resultSummary; }
            set { _resultSummary = value; RaisePropertyChanged("ResultSummary"); }
        }

        /// <summary>
        /// simnple code more or less lifted from msdn.
        /// </summary>
        internal void LoadFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
            {
                DefaultExt = ".txt",
                Filter = "Text files (*.txt) | *.txt"
            };

            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                FileToLoad = dlg.FileName;                
            }            
        }
               
        internal void CountWordsInFile()
        {
            results = FileParser.CountWords(FileToLoad);
            ResultSummary = string.Format("There were a total of {0} unique words found!", results.Keys.Count);
        }

        internal void SaveResult()
        {
            if (results.Keys.Count == 0) throw new Exception("No file has been Calculated. Please load and calculate a file in order to save results.");

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".text"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                FileSaver.SaveResults(filename, results);
            }                        
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
