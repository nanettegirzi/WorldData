using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace WorldData.Models
{

    public class City
    {
        private string _cityName;
        private int _cityPopulation;


        public City(string cityName, int cityPopulation)
        {
            _cityName = cityName;
            _cityPopulation = cityPopulation;
            //_cityId = cityId;
        }

        public override bool Equals(System.Object otherCity)
        {
            if (!(otherCity is City))
            {
                return false;
            }
            else
            {
                City newCity = (City) otherCity;
                bool nameEquality = (this.GetCityName() == newCity.GetCityName());
                return (nameEquality);
            }
        }

        public string GetCityName()
        {
            return _cityName;
        }

        public void SetCityName(string cityName)
        {
            _cityName = cityName;
        }

        public int GetCityPopulation()
        {
            return _cityPopulation;
        }

        public void SetCityPopulation(int cityPopulation)
        {
            _cityPopulation = cityPopulation;
        }

        // public void Save()
        // {
        //     MySqlConnection conn = DB.Connection();
        //    conn.Open();
        //
        //    var cmd = conn.CreateCommand() as MySqlCommand;
        //    cmd.CommandText = @"INSERT INTO `city` (`name`) VALUES (@cityName);";
        //
        //
        //    MySqlParameter name = new MySqlParameter();
        //    name.ParameterName = "@cityName";
        //    name.Value = this._cityName;
        //    cmd.Parameters.Add(name);
        //
        //    cmd.ExecuteNonQuery();
        //
        //    // more logic will go here in a moment
        //
        //
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }


        public static List<City> GetAllCities()
        {
            List<City> allCities = new List<City>(){};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM city;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {

                string cityName = rdr.GetString(1);
                int cityPopulation = rdr.GetInt32(4);
                City newCity = new City(cityName, cityPopulation);
                allCities.Add(newCity);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCities;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM city;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }

    public class Country
    {
        private string _countryName;
        private int _countryPopulation;
        private string _countryContinent;



        public Country(string countryName, int countryPopulation, string countryContinent)
        {
            _countryName = countryName;
            _countryPopulation = countryPopulation;
            _countryContinent = countryContinent;
        }


        public override bool Equals(System.Object otherCountry)
        {
            if (!(otherCountry is Country))
            {
                return false;
            }
            else
            {
                Country newCountry = (Country) otherCountry;
                bool nameEquality = (this.GetCountryName() == newCountry.GetCountryName());
                return (nameEquality);
            }
        }


        public string GetCountryName()
        {
            return _countryName;
        }

        public void SetCountryName(string countryName)
        {
            _countryName = countryName;
        }

        public int GetCountryPopulation()
        {
            return _countryPopulation;
        }

        public void SetCountryPopulation(int countryPopulation)
        {
            _countryPopulation = countryPopulation;
        }

        public string GetCountryContinent()
        {
            return _countryContinent;
        }

        public void SetCountryContinent(string countryContinent)
        {
            _countryContinent = countryContinent;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
           conn.Open();

           var cmd = conn.CreateCommand() as MySqlCommand;
           cmd.CommandText = @"INSERT INTO `countries` (`name`) VALUES (@countryName);";


           MySqlParameter name = new MySqlParameter();
           name.ParameterName = "@countryName";
           name.Value = this._countryName;
           cmd.Parameters.Add(name);

           cmd.ExecuteNonQuery();

           // more logic will go here in a moment


            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        public static List<Country> GetAllCountries()
        {
            List<Country> allCountries = new List<Country>(){};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM countries;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {

                string countryName = rdr.GetString(1);
                int countryPopulation = rdr.GetInt32(6);
                string countryContinent = rdr.GetString(2);
                Country newCountry = new Country(countryName, countryPopulation, countryContinent);
                allCountries.Add(newCountry);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static List<Country> Filter(string continent)
        {

            List<Country> allCountries = new List<Country>(){};
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM countries WHERE continent = '"  + continent + "';";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {

                string countryName = rdr.GetString(1);
                int countryPopulation = rdr.GetInt32(6);
                string countryContinent = rdr.GetString(2);
                allCountries.Add(new Country(countryName, countryPopulation, countryContinent));
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCountries;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM countries;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }
    }
}
