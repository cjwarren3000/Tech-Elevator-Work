using System;
using System.Collections.Generic;
using System.Text;
using WorldClient.APIServices;
using WorldClient.Models;

namespace WorldClient
{
    public class ConsoleService
    {
        private readonly CityAPIService cityAPIService = new CityAPIService();
        private readonly CountryAPIService countryAPIService = new CountryAPIService();
        private readonly LanguageAPIService languageAPIService = new LanguageAPIService();
        private readonly LoginAPIServcie loginAPIService = new LoginAPIServcie();

        public void Run()
        {
            Console.WriteLine("Welcome to World Client! Please make a selection:");
            RunCLI();
        }

        const string Command_GetCountries = "1";
        const string Command_GetCountry = "2";
        const string Command_CitiesByCountryCode = "3";
        const string Command_LanguagesByCountryCode = "4";
        //const string Command_AddNewLanguage = "5";
        //const string Command_RemoveLanguage = "6";
        const string Command_AddCity = "7";
        const string Command_Login_Logout = "8";
        const string Command_Register = "9";

        const string Command_Quit = "q";

        public ConsoleService()
        {

        }

        public void RunCLI()
        {
            PrintHeader();
            PrintMenu();

            while (true)
            {
                string command = Console.ReadLine();

                try
                {
                    switch (command.ToLower())
                    {
                        case Command_GetCountries:
                            GetCountries();
                            break;

                        case Command_GetCountry:
                            GetCountry();
                            break;

                        case Command_CitiesByCountryCode:
                            GetCitiesByCountryCode();
                            break;

                        //case Command_LanguagesByCountryCode:
                        //   // GetLanguagesForCountry();
                        //    break;

                        //case Command_AddNewLanguage:
                        //   // AddNewLanguage();
                        //    break;

                        //case Command_RemoveLanguage:
                        //   // RemoveLanguage();
                        //    break;

                        case Command_AddCity:
                            AddCity();
                            break;

                        case Command_Login_Logout:
                            LoginLogout();
                            break;

                        case Command_Register:
                            Register();
                            break;

                        case Command_Quit:
                            Console.WriteLine("Thank you for using the world geography cli app");
                            return;

                        default:
                            Console.WriteLine("The command provided was not a valid command, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to process request - " + ex.Message);
                    Console.WriteLine();
                }

                PrintMenu();
            }
        }

        private void PrintHeader()
        {
            Console.WriteLine(@" _    _  _____ ______  _     ______     ______   ___   _____   ___  ______   ___   _____  _____ ");
            Console.WriteLine(@"| |  | ||  _  || ___ \| |    |  _  \    |  _  \ / _ \ |_   _| / _ \ | ___ \ / _ \ /  ___||  ___|");
            Console.WriteLine(@"| |  | || | | || |_/ /| |    | | | |    | | | |/ /_\ \  | |  / /_\ \| |_/ // /_\ \\ `--. | |__  ");
            Console.WriteLine(@"| |/\| || | | ||    / | |    | | | |    | | | ||  _  |  | |  |  _  || ___ \|  _  | `--. \|  __| ");
            Console.WriteLine(@"\  /\  /\ \_/ /| |\ \ | |____| |/ /     | |/ / | | | |  | |  | | | || |_/ /| | | |/\__/ /| |___ ");
            Console.WriteLine(@" \/  \/  \___/ \_| \_|\_____/|___/      |___/  \_| |_/  \_/  \_| |_/\____/ \_| |_/\____/ \____/ ");
        }

        private void PrintMenu()
        {
            string logInOut = loginAPIService.LoggedIn ? "Log out" : "Log in";
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Main-Menu Type in a command");
            Console.WriteLine(" 1 - Get all of the countries");
            Console.WriteLine(" 2 - Get details about a country");
            Console.WriteLine(" 3 - Get a list of the cities by country code");
            Console.WriteLine(" 4 - Get a list of the languages by country code");
            //Console.WriteLine(" 5 - Add a new language");
            //Console.WriteLine(" 6 - Remove language");
            Console.WriteLine(" 7 - Add a city");
            Console.WriteLine(" 8 - " + logInOut);
            Console.WriteLine(" 9 - Register");
            Console.WriteLine(" Q - Quit");
        }

        private void GetCountries()
        {
            IList<Country> countries = countryAPIService.GetCountries();

            Console.WriteLine();
            Console.WriteLine("Printing all of the countries");

            Console.WriteLine(Country.StringHeader());
            for (int index = 0; index < countries.Count; index++)
            {
                Console.WriteLine(index + " - " + countries[index]);
            }
        }

        private void GetCountry()
        {
            try
            {
                string countryCode = ConsoleHelper.GetString("Enter the country code that you want to retrieve:");

                CountryDetail country = countryAPIService.GetCountry(countryCode);

                Console.WriteLine("Code: " + country.Code);
                Console.WriteLine("Name: " + country.Name);
                Console.WriteLine("Continent: " + country.Continent);
                Console.WriteLine("Region: " + country.Region);
                Console.WriteLine("Surface area: " + country.SurfaceArea);
                Console.WriteLine("Independence year: " + country.IndependenceYear);
                Console.WriteLine("Population: " + country.Population);
                Console.WriteLine("Life expectancy: " + country.LifeExpectancy); //<-- nullable property, it can have a value that is a double or NULL if there is no value
                Console.WriteLine("GNP: " + country.GNP); //<-- nullable property, it can have a value that is a decimal or NULL if there is no value
                Console.WriteLine("Local name: " + country.LocalName);
                Console.WriteLine("Government form: " + country.GovernmentForm);
                Console.WriteLine("Head of state: " + country.HeadOfState);
                Console.WriteLine("Capital ID : " + country.CapitalId); //<-- nullable property, it can have a value that is a int or NULL if there is no value
                Console.WriteLine("Codes: " + country.Code2);
                Console.WriteLine();

                foreach (string item in country.Stories)
                {
                    Console.WriteLine(item);
                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
            catch
            {

                Console.WriteLine("Unable to process request.");
                Console.WriteLine();
            }
        }

        private void GetCitiesByCountryCode()
        {
            string countryCode = ConsoleHelper.GetString("Enter the country code for the cities that you want to retrieve:");

            List<City> cities = cityAPIService.GetCitiesByCountryCode(countryCode);

            Console.WriteLine();
            Console.WriteLine($"Printing {cities.Count} cities for {countryCode}");

            foreach (var city in cities)
            {
                Console.WriteLine(city);
            }
        }

        private void AddCity()
        {
            string name = ConsoleHelper.GetString("Name of the city:");
            string code = ConsoleHelper.GetString("Country code:");
            string district = ConsoleHelper.GetString($"District {name} is in:");
            int population = ConsoleHelper.GetInteger($"Population of {name}:");

            City city = new City
            {
                CountryCode = code,
                Name = name,
                District = district,
                Population = population
            };

            cityAPIService.AddCity(city);

            Console.WriteLine("City added.");
        }

        private void LoginLogout()
        {
            if (loginAPIService.LoggedIn)
            {
                loginAPIService.Logout();
                Console.WriteLine("You are now logged out");
            }
            else
            {
                Console.Write("Please enter username: ");
                string username = Console.ReadLine();
                Console.Write("Please enter password: ");
                string password = Console.ReadLine();
                var login = loginAPIService.Login(username, password);
                if (login)
                {
                    Console.WriteLine("You are now logged in");
                }
            }
        }

        private void Register()
        {
            LoginUser registerUser = new LoginUser();
            Console.Write("Please enter username: ");
            registerUser.Username = Console.ReadLine();
            Console.Write("Please enter password: ");
            registerUser.Password = Console.ReadLine();
            
            bool isRegistered = loginAPIService.Register(registerUser);
            if (isRegistered)
            {
                Console.WriteLine("");
                Console.WriteLine("Registration successful. You can now log in.");
            }

        }

        private void GetLanguagesForCountry()
        {
            string countryCode = ConsoleHelper.GetString("Enter the country code you want to retrieve:");

            IList<Language> languages = languageAPIService.GetLanguages(countryCode);

            Console.WriteLine();
            Console.WriteLine($"Printing {languages.Count} languages for {countryCode}");

            foreach (var language in languages)
            {
                Console.WriteLine(language);
            }
        }

        //private void GetCountriesInNorthAmerica()
        //{
        //    string continent = ConsoleHelper.GetString("Continent to filter by:");

        //    IList<Country> northAmericanCountries = countryAPIService.GetCountries(continent);

        //    Console.WriteLine();
        //    Console.WriteLine("All North American Countries");

        //    foreach (var country in northAmericanCountries)
        //    {
        //        Console.WriteLine(country);
        //    }
        //}


        //private void AddNewLanguage()
        //{
        //    string countryCode = ConsoleHelper.GetString("Enter the country code the language is for:");
        //    bool officialOnly = ConsoleHelper.GetBool("Is it official only? True/False ");
        //    int percentage = ConsoleHelper.GetInteger("What percentage is it spoken by?");
        //    string name = ConsoleHelper.GetString("What is the name of the lanaguage?");

        //    Language lang = new Language
        //    {
        //        CountryCode = countryCode,
        //        IsOfficial = officialOnly,
        //        Percentage = percentage,
        //        Name = name
        //    };

        //    bool result = languageDAO.AddNewLanguage(lang);

        //    if (result)
        //    {
        //        Console.WriteLine("Success!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("The new language was not inserted");
        //    }
        //}

        //private void RemoveLanguage()
        //{
        //    string language = ConsoleHelper.GetString("Which language should be removed:");
        //    string countryCode = ConsoleHelper.GetString("For which country code:");

        //    Language lang = new Language
        //    {
        //        CountryCode = countryCode,
        //        Name = language
        //    };

        //    bool result = languageDAO.RemoveLanguage(lang);

        //    if (result)
        //    {
        //        Console.WriteLine("Success!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("The language was not found or removed.");
        //    }
        //}

        //private void GetLanguagesForCountry()
        //{
        //    string countryCode = ConsoleHelper.GetString("Enter the country code you want to retrieve:");

        //    IList<Language> languages = languageDAO.GetLanguages(countryCode);

        //    Console.WriteLine();
        //    Console.WriteLine($"Printing {languages.Count} languages for {countryCode}");

        //    foreach (var language in languages)
        //    {
        //        Console.WriteLine(language);
        //    }
        //}

    }
}




