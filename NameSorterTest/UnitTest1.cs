using NameSorter.Utility;
using NameSorter.Controller;
using NUnit.Framework.Constraints;
using NameSorter.BL;

namespace NameSorterTest
{
    public class Tests
    {
        private IFileOperations _fileOperations;
        private string _incorrectFilePath="fake.txt";
        private string _invalidExtentionFile="fake.docx";
        private string _unsortedFilePath = @"names.txt";
        private string _sortedFilePath = @"SortedList.txt";
        private string _outputFileName = "sorted-names-list.txt";
       
        [SetUp]
        public void Setup()
        {
            _fileOperations = new TextFileOperations();
         
        }

        [Test]
        public void CheckFileNotFound()
        {
            Assert.Throws<FileNotFoundException>(() => _fileOperations.LoadFile(_incorrectFilePath));
        }

        [Test]
        public void CheckFileExtension()
        {
            Assert.Throws<FileNotFoundException>(() => _fileOperations.LoadFile(_invalidExtentionFile));
        }

        [Test]
        public void CheckFileContents()
        {
            
            IEnumerable<string> namesList = _fileOperations.LoadFile(_unsortedFilePath);
            Assert.That(namesList.Count(), Is.EqualTo(11));
        }

        [Test]
        public void CheckNameSorterFunctionality()
        { 
        NameSorterController nameSorterController = new NameSorterController();
            nameSorterController.NameSorter(_unsortedFilePath, _outputFileName);

            bool areEqual=File.ReadAllLines(_outputFileName).SequenceEqual(File.ReadAllLines(_sortedFilePath));
            Assert.IsTrue(areEqual);
        }

        
    }
}