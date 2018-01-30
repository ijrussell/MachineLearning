using System;
using System.Collections.Generic;

namespace NaiveBayesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = GetRawData();

            // Split data into 24 items to train on 
            // and 6 items to test your algorithm.

            Console.WriteLine(data.Count);
            Console.ReadLine();
        }

        private static List<Person> GetRawData()
        {
            return new List<Person>
            {
                new Person { Role = "analyst", Gender = "male", Income = "high", Voted = "conservative" },
                new Person { Role = "barista", Gender = "female", Income = "low", Voted = "liberal" },
                new Person { Role = "cook", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "doctor", Gender = "female", Income = "medium", Voted = "conservative" },
                new Person { Role = "analyst", Gender = "female", Income = "low", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "analyst", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "cook", Gender = "female", Income = "low", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "female", Income = "medium", Voted = "liberal" },
                new Person { Role = "cook", Gender = "female", Income = "low", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "cook", Gender = "female", Income = "high", Voted = "liberal" },
                new Person { Role = "barista", Gender = "female", Income = "medium", Voted = "liberal" },
                new Person { Role = "analyst", Gender = "male", Income = "low", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "female", Income = "high", Voted = "conservative" },
                new Person { Role = "barista", Gender = "female", Income = "medium", Voted = "conservative" },
                new Person { Role = "doctor", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "barista", Gender = "male", Income = "high", Voted = "conservative" },
                new Person { Role = "doctor", Gender = "female", Income = "medium", Voted = "liberal" },
                new Person { Role = "analyst", Gender = "male", Income = "low", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "cook", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "doctor", Gender = "female", Income = "high", Voted = "conservative" },
                new Person { Role = "analyst", Gender = "male", Income = "high", Voted = "conservative" },
                new Person { Role = "barista", Gender = "female", Income = "medium", Voted = "liberal" },
                new Person { Role = "doctor", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "analyst", Gender = "female", Income = "medium", Voted = "conservative" },
                new Person { Role = "analyst", Gender = "male", Income = "medium", Voted = "conservative" },
                new Person { Role = "doctor", Gender = "female", Income = "medium", Voted = "liberal" },
                new Person { Role = "barista", Gender = "male", Income = "medium", Voted = "conservative" },
            };
        }
    }
}
