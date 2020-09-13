using PetReporting.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PetReporting.Provider
{
    public class ReportProvider
    {
        // NOTE: This method prints a pets reports in csv format.
        public void PrintReport(IEnumerable<Pet> pets, string filename)
        {
            File.WriteAllLines(filename, CreateCSVListOfPets(pets));
        }

        private IEnumerable<string> CreateCSVListOfPets(IEnumerable<Pet> pets)
        {
            List<string> entries = new List<string>
            {
                "Owners name,Date Joined Practice,Number Of Visits,Number of Lives"
            };

            entries.AddRange(pets.Select(pet => pet.ToCSV().ToString()));

            return entries;
        }
    }
}
