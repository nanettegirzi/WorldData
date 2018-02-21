using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace WorldData
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet("/allcountries")]
        public ActionResult AllCountries()
        {
            List<Country> allCountries = Country.GetAllCountries();
            return View("AllCountries", allCountries);
        }

        [HttpGet("/allcities")]
        public ActionResult AllCities()
        {
            List<City> allCities = City.GetAllCities();
            return View("AllCities", allCities);
        }

        [HttpPost("/continent/filter")]
        public ActionResult Continent()
        {
            List<Country> countries = new List<Country>();
            string continent = Request.Form["continent"];
            // Console.WriteLine(continent);
            countries = Country.Filter(continent);
            return View("Continent", countries);
        }
    }
}
