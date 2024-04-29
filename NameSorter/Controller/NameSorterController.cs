using NameSorter.BL;
using NameSorter.Model;
using NameSorter.Utility;
using System.Text;

namespace NameSorter.Controller
{
    /// <summary>
    /// Class to sort the names 
    /// </summary>
    public class NameSorterController
    {
        IFileOperations _fileOperations;
        IOperations _operations;

        public NameSorterController()
        {
            _fileOperations = new TextFileOperations();
            _operations = new Operations();
        }

        /// <summary>
        /// Sort names
        /// </summary>
        /// <param name="inputFilePath">File containing all the names</param>
        /// <param name="outputFilePath">path of output file for sorteed list</param>
        public void NameSorter(string inputFilePath, string outputFilePath)
        {
            try
            {
                List<Person> FullNameSorted = new List<Person>();

                //load the input file
                var namesList = _fileOperations.LoadFile(inputFilePath);

                //list of valid names with atleast 1 given name
                var unsortedValidNamesList = _operations.StringToPersonList(namesList);

                

                //sort valid names
                var sortedList=_operations.Sorter(unsortedValidNamesList); 
                
                //valid names text
                var sortedStringList=_operations.PersonToStringList(sortedList);

               

                Console.Write("\nSorted Names List:\n");
                Console.Write("\n**************************************************************\n");

                Console.Write(sortedStringList.ToString());
                Console.Write("\n**************************************************************\n");

               
                //save the output file
                _fileOperations.SaveFile(sortedStringList, outputFilePath);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}