using NameSorter.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.BL
{
    public interface IOperations {
        public List<Person> StringToPersonList(IEnumerable<string> names);

        public string PersonToStringList(List<Person> names);

        public List<Person> Sorter(List<Person> namesList);
    }
    public class Operations : IOperations {
        /// <summary>
        /// Converts string list to person list
        /// </summary>
        /// <param name="names">String names list</param>
        /// <returns></returns>
        public List<Person> StringToPersonList(IEnumerable<string> names)
        {
            //+1 for last name
            var unsortedList = names.Select(line => line.Split(' '))
                        .Where(l => l.Length >=2)
                     .Select(l => new Person
                     {
                         LastName = l.ElementAtOrDefault(l.Length - 1) ?? string.Empty,
                         GivenName3 = l.ElementAtOrDefault(l.Length - 2) ?? string.Empty,
                         GivenName2 = l.ElementAtOrDefault(l.Length - 3) ?? string.Empty,
                         GivenName1 = l.ElementAtOrDefault(l.Length - 4) ?? string.Empty,
                     }).ToList<Person>();


            return unsortedList;
        }

        /// <summary>
        /// Converts person list to string text.
        /// </summary>
        /// <param name="names">Persons list</param>
        /// <returns></returns>
        public string PersonToStringList(List<Person> names)
        {
            StringBuilder stringList = new StringBuilder();
            names.ForEach(person =>
            {
                stringList.AppendLine(($"{person.GivenName1} {person.GivenName2} {person.GivenName3} {person.LastName}").Trim());
            });
            return stringList.ToString();
        }

        /// <summary>
        /// Sorts list of person set first by last name then given names
        /// </summary>
        /// <param name="namesList">Persons names list</param>
        /// <returns></returns>
        public List<Person> Sorter(List<Person> namesList)
        {
            var FullNameSorted = (from s in namesList
                                  orderby s.LastName ascending, s.GivenName1, s.GivenName2, s.GivenName3
                              select s).ToList();
            return FullNameSorted;

        }
    }
}
