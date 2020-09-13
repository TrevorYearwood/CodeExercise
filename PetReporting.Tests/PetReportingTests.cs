using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetReporting.Entities;
using PetReporting.Provider;

namespace PetReporting.Tests
{
    [TestClass]
    public class PetReportingTests
    {
        [TestMethod]
        public void ShouldReturnAllRowsOfAllPetsAndHeaderForPetReport()
        {
            List<Pet> pets = GetPetsData();
            new ReportProvider().PrintReport(pets, "PetsReport.csv");

            var result = File.ReadAllLines("PetsReport.csv");

            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void ShouldReturnCorrectHeaderForPetReport()
        {
            List<Pet> pets = GetPetsData();
            new ReportProvider().PrintReport(pets, "PetsReport.csv");

            var result = File.ReadAllLines("PetsReport.csv");

            Assert.AreEqual("Owners name,Date Joined Practice,Number Of Visits,Number of Lives", result[0]);
        }

        [TestMethod]
        public void ShouldReturnCorrectDataForEachPetInPetReport()
        {
            List<Pet> pets = GetPetsData();
            new ReportProvider().PrintReport(pets, "PetsReport.csv");

            List<string> expectedResult = new List<string>
            {
                "Jim Rogers," + DateTime.Now.ToString("d") + ",5",
                "Tony Smith,13/07/1985,10",
                "Steve Roberts,06/05/2002,20,9"
            };

            var result = File.ReadAllLines("PetsReport.csv");

            for (int i = 0; i < result.Length - 1; i++)
            {
                Assert.AreEqual(expectedResult[i], result[i+1]);
            }
        }

        private static List<Pet> GetPetsData()
        {
            return new List<Pet>()
            {
                new Dog() { Firstname = "Jim", Lastname = "Rogers", numberofVisits = 5, joinedPractice = DateTime.Now},
                new Dog() { Firstname = "Tony", Lastname = "Smith", numberofVisits = 10, joinedPractice = new DateTime(1985, 7, 13)},
                new Cat() { Firstname = "Steve", Lastname = "Roberts", numberofVisits = 20, joinedPractice = new DateTime(2002, 5, 6), numberOfLives = 9 }
            };
        }
    }
}
