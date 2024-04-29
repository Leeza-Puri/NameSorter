using NameSorter.Model;
using System.Text;

namespace NameSorter.Utility
{
    public interface  IFileOperations
    {
        IEnumerable<string> LoadFile(string fileName);
        void SaveFile(string fileText,string fileName);
    }
    /// <summary>
    /// Manage file operations (open/read/save)
    /// </summary>
    public class TextFileOperations:IFileOperations
    {
        /// <summary>
        /// Load the file
        /// </summary>
        /// <param name="fileName">the path to the file</param>
        /// <returns>IEnumerable of all the names (per line)</returns>
        /// <exception cref="FileNotFoundException">Throw exception if file does not exist or file extenstion is not txt.</exception>
        public IEnumerable<string> LoadFile(string fileName)
        {
            if (!CheckFileType(fileName))
            {
                throw new FileNotFoundException("Invalid File Extension!");
            }
            if (File.Exists(fileName))
            {
                return File.ReadLines(fileName);
            }

            throw new FileNotFoundException("File Not Found!");
        }

        /// <summary>
        /// Save the output file
        /// </summary>
        /// <param name="fileText">file contents</param>
        /// <param name="fileName">output file name</param>
        public void SaveFile(string fileText, string fileName)
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.Write(fileText);
            }
        }


        public bool CheckFileType(string fileName)
        {
            string ext = Path.GetExtension(fileName);
            switch (ext.ToLower())
            {
                case ".txt":
                    return true;
                default:
                    return false;
            }
        }
    }

   
}
