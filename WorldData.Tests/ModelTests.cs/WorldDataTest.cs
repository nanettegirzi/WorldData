using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using WorldData.Models;

namespace WorldData.Tests
{

    [TestClass]
    public class WorldDataTests : IDisposable
    {
        public void Dispose()
        {
            Country.DeleteAll();
        }
        public WorldDataTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
        }

        [TestMethod]
        public void GetAllCountry_DatabaseEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = Country.GetAllCountries().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetAllCity_DatabaseEmptyAtFirst_0()
        {
            //Arrange, Act
            int result = City.GetAllCities().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_CountryList()
        {
            //Arrange
            Country testCountry = new Country("Aruba", 45, "North America");

            //Act
            int result = Country.GetAllCountries().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Save_SavesToDatabase_CityList()
        {
            //Arrange
            City testCity = new City("Seattle", 45);

            //Act
            int result = City.GetAllCities().Count;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Country()
        {
            // Arrange, Act
            Country firstCountry = new Country("United States", 300, "North America");
            Country secondCountry = new Country("United States", 300, "North America");

            // Assert
            Assert.AreEqual(firstCountry, secondCountry);
        }

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_City()
        {
            // Arrange, Act
            City firstCity = new City("San Diego", 300);
            City secondCity = new City("San Diego", 300);

            // Assert
            Assert.AreEqual(firstCity, secondCity);
        }

        [TestMethod]
        public void Save_SavesCountriesToDatabase_CountryList()
        {
            //Arrange
            Country testCountry = new Country("United States", 300, "North America");

            //Act
            testCountry.Save();
            List<Country> result = Country.GetAllCountries();
            List<Country> testList = new List<Country>{testCountry};

            //Assert
            CollectionAssert.AreEqual(testList, result);
        }

        // [TestMethod]
        // public void Save_SavesCitiesToDatabase_CityList()
        // {
        //     //Arrange
        //     City testCity = new City("San Diego", 300);
        //
        //     //Act
        //     testCity.Save();
        //     List<City> result = City.GetAllCities();
        //     List<City> testList = new List<City>{testCity};
        //
        //     //Assert
        //     CollectionAssert.AreEqual(testList, result);
        // }
    }
}
